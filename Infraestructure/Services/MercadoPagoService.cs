using Application.Interfaces;
using Application.Models.Request;
using Domain.Constants;
using Domain.Entities;
using Domain.Interfaces;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Preference;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Services
{
    public class MercadoPagoService : IMercadoPagoService
    {
        private readonly string _accessToken;
        private readonly IReservationService _reservationService;
        private readonly IReservationRepository _reservationRepository;

        public MercadoPagoService(IConfiguration configuration, IReservationService reservationService, IReservationRepository reservationRepository)
        {
            _accessToken = configuration["MercadoPago:AccessToken"];
            MercadoPagoConfig.AccessToken = _accessToken;
            _reservationService = reservationService;
            _reservationRepository = reservationRepository;
        }
        public async Task<string> CreatePaymentAsync(decimal price, string title, string successUrl, string date, string time, int clientId, int courtId)
        {
            var reservation = await _reservationRepository.GetReservationByCourtDayTime(courtId, DateOnly.Parse(date), TimeSpan.Parse(time));

            if (reservation != null) throw new Exception("La reserva ya está ocupada");

            var client = new PreferenceClient();
            var now = DateTime.UtcNow;

            var request = new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest> {
                    new PreferenceItemRequest {
                        Title = title,
                        Quantity = 1,
                        UnitPrice = price,
                    }
                },
                BackUrls = new PreferenceBackUrlsRequest { Success = successUrl },
                AutoReturn = "approved",
                NotificationUrl = "https://0a6988147d34.ngrok-free.app/api/MercadoPago",
                ExpirationDateFrom = now,
                ExpirationDateTo = now.AddMinutes(5)
            };

            // ✅ Primero se crea la preferencia
            var preference = await client.CreateAsync(request);

            // ✅ Luego se crea la reserva pendiente, con el PreferenceId
            var newReservation = new ReservationRequest
            {
                Date = date,
                Time = time,
                ClientId = clientId,
                CourtId = courtId,
                PreferenceId = preference.Id // importante!
            };

            await _reservationService.CreateReservation(newReservation);

            return preference.InitPoint;
        }
    }
}
