using Application.Interfaces;
using Application.Models.Request;
using Application.Services;
using Domain.Constants;
using Domain.Interfaces;
using MercadoPago.Client.MerchantOrder;
using MercadoPago.Client.Payment;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class WebhookService : IWebhookService
    {
        private readonly IConfiguration _config;
        private readonly IReservationRepository _reservationRepository;

        public WebhookService(IConfiguration config, IReservationRepository reservationRepository)
        {
            _config = config;
            _reservationRepository = reservationRepository;
        }

        public async Task HandlePaymentNotificationAsync(string json, Dictionary<string, string> queryParams, Dictionary<string, string> headers)
        {
            var secret = _config["MercadoPago:WebhookSecret"];
            var signature = headers.GetValueOrDefault("x-signature");
            var requestId = headers.GetValueOrDefault("x-request-id");

            Console.WriteLine("Pase 0");
            Console.WriteLine("📥 Webhook recibido:");
            Console.WriteLine($"🔸 Body: {json}");

            string dataId = queryParams.GetValueOrDefault("data.id");
            string action = null;

            if (string.IsNullOrEmpty(dataId))
            {
                try
                {
                    using var doc = JsonDocument.Parse(json);
                    if (doc.RootElement.TryGetProperty("data", out var dataProp) &&
                        dataProp.TryGetProperty("id", out var idProp))
                    {
                        dataId = idProp.GetString();
                    }

                    // Extraemos el tipo de acción si viene
                    if (doc.RootElement.TryGetProperty("action", out var actionProp))
                    {
                        action = actionProp.GetString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error parseando el JSON: {ex.Message}");
                    return;
                }
            }

            Console.WriteLine("Pase 0.5");
            Console.WriteLine($"🔸 dataId: {dataId}");
            if (string.IsNullOrEmpty(dataId))
            {
                Console.WriteLine("❌ data.id vacío. Ignorando.");
                return;
            }

            Console.WriteLine("Pase 1");

            // Validación de firma
            if (!string.IsNullOrEmpty(signature))
            {
                var parts = signature.Split(',');
                var ts = parts.FirstOrDefault(p => p.StartsWith("ts="))?.Split("=")[1];
                var v1 = parts.FirstOrDefault(p => p.StartsWith("v1="))?.Split("=")[1];
                var manifest = $"id:{dataId};request-id:{requestId};ts:{ts};";
                var hash = ComputeHmacSHA256(manifest, secret);

                if (hash != v1)
                {
                    Console.WriteLine("⚠️ Firma inválida, ignorando.");
                    return;
                }
            }

            Console.WriteLine("Pase 4");

            MercadoPagoConfig.AccessToken = _config["MercadoPago:AccessToken"];
            var client = new PaymentClient();
            var payment = await client.GetAsync(long.Parse(dataId));

            Console.WriteLine($"Pago recibido: ID={payment.Id}, Estado={payment.Status}, Monto={payment.TransactionAmount}");

            Console.WriteLine("Pase 5");

            if (payment.Status == "approved")
            {
                Console.WriteLine($"✅ Pago aprobado: {payment.Id}");

                // Obtener la orden de compra (merchant order)
                var merchantOrderId = payment.Order?.Id;
                if (merchantOrderId == null)
                {
                    Console.WriteLine("❌ No se pudo obtener el MerchantOrder ID");
                    return;
                }

                var moClient = new MerchantOrderClient();
                var merchantOrder = await moClient.GetAsync(merchantOrderId.Value);

                // Obtener la preferencia y la metadata
                var preferenceClient = new PreferenceClient();
                var preference = await preferenceClient.GetAsync(merchantOrder.PreferenceId);

                if (merchantOrder.PreferenceId == null)
                {
                    Console.WriteLine("❌ No se pudo obtener el PreferenceId");
                    return;
                }

                if (preference.ExpirationDateTo.HasValue && payment.DateApproved.HasValue)
                {
                    if (payment.DateApproved.Value > preference.ExpirationDateTo.Value)
                    {
                        Console.WriteLine($"⚠️ Pago aprobado después de la expiración. Ignorando. PaymentDate: {payment.DateApproved}, ExpirationDateTo: {preference.ExpirationDateTo}");
                        return;
                    }
                }

                var preferenceId = merchantOrder.PreferenceId;

                var reservation = await _reservationRepository.GetByPreferenceId(preferenceId);
                if (reservation != null)
                {
                    reservation.Status = StatusEnum.Success;
                    reservation.PaidAmount = payment.TransactionAmount ?? 0;

                    await _reservationRepository.Update(reservation);
                    Console.WriteLine($"✅ Reserva actualizada a Success para PreferenceId: {preferenceId}");
                }
                else
                {
                    Console.WriteLine($"❌ No se encontró ninguna reserva con PreferenceId: {preferenceId}");
                }

                Console.WriteLine($"✅ Reserva creada con ID: {reservation.Id}");
            }

            Console.WriteLine("Pase 7");
        }


        private string ComputeHmacSHA256(string message, string key)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var messageBytes = Encoding.UTF8.GetBytes(message);
            using var hmac = new HMACSHA256(keyBytes);
            var hashBytes = hmac.ComputeHash(messageBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
