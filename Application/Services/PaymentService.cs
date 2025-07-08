using Application.Interfaces;
using Domain.Constants;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;
using Application.Models.Responses;

namespace Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IReservationRepository _reservationRepository;

        public PaymentService(IPaymentRepository paymentRepository, IReservationRepository reservationRepository)
        {
            _paymentRepository = paymentRepository;
            _reservationRepository = reservationRepository;
        }

        public async Task SaveIntentAsync(Payment intent)
        {
            await _paymentRepository.CreateAsync(intent);
        }

        //public async Task ProcessWebhookAsync(string externalReference, MercadoPagoPaymentDto payment)
        //{

        //    // Buscar el intento de pago que habías guardado al crear la preferencia
        //    var intent = await _paymentRepository.GetByExternalReferenceAsync(externalReference);

        //    if (intent == null)
        //        throw new Exception("No se encontró el intento de pago.");

        //    // Validar que el pago esté aprobado
        //    if (payment.Status != "approved")
        //        throw new Exception("El pago no fue aprobado.");

        //    // Verificar si ya existe una reserva para esa fecha y horario
        //    //var yaExiste = await _reservationRepository.ExistsAsync(intent.CourtId, intent.Date, intent.Time);
        //    //if (yaExiste)
        //    //    throw new Exception("Ya existe una reserva para esa fecha y hora.");

        //    // Crear la reserva
        //    var reservation = new Reservation
        //    {
        //        CourtId = intent.CourtId,
        //        ClientId = intent.ClientId,
        //        Date = intent.Date,
        //        Time = intent.Time,
        //        TotalPrice = 60000,
        //        PaidAmount = payment.Amount,
        //        MercadoPagoPaymentId = payment.Id,
        //        CreatedAt = DateTime.UtcNow,
        //    };

        //    await _reservationRepository.Create(reservation);

        //    // (opcional) Podés eliminar el intento de pago si ya no lo necesitás
        //    //await _paymentIntentRepository.DeleteAsync(intent.Id);




        //    //payment.
        //    //if (status.ToLower() == "approved")
        //    //{
        //    //    pending.Status = "Approved";
        //    //    await _paymentRepository.UpdateAsync(pending);

        //    //    var reservation = new Reservation
        //    //    {
        //    //        ClientId = pending.ClientId,
        //    //        CourtId = pending.CourtId,
        //    //        Date = pending.Date,
        //    //        Time = pending.Time,
        //    //        Status = StatusEnum.Success
        //    //    };

        //    //    await _reservationRepository.Create(reservation);
        //    //}
        //}

        public async Task ProcessApprovedPaymentAsync(string externalReference)
        {
            try
            {
                // Buscar el intento de pago
                var intent = await _paymentRepository.GetByExternalReferenceAsync(externalReference);
                if (intent == null || intent.Status != "approved")
                    return;

                // Verificar si ya existe una reserva
                //var existingReservation = await _reservationRepository.GetByPaymentReferenceAsync(externalReference);
                //if (existingReservation != null)
                //{
                //    Console.WriteLine($"Ya existe una reserva para la referencia: {externalReference}");
                //    return;
                //}

                // Crear la reserva
                var reservation = new Reservation
                {
                    CourtId = intent.CourtId,
                    ClientId = intent.ClientId,
                    Date = intent.Date,
                    Time = intent.Time,
                    TotalPrice = intent.Amount,
                    PaidAmount = intent.Amount,
                    CreatedAt = DateTime.UtcNow,
                    Status = StatusEnum.Success
                };

                await _reservationRepository.Create(reservation);
                Console.WriteLine($"Reserva creada exitosamente para referencia: {externalReference}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error procesando pago aprobado: {ex.Message}");
            }
        }
    }
}
