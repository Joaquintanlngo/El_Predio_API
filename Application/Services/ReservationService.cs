﻿using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Responses;
using Domain.Constants;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ICourtRepository _courtRepository;

        public ReservationService(IReservationRepository reservationRepository, ICourtRepository courtRepository)
        {
            _reservationRepository = reservationRepository;
            _courtRepository = courtRepository;
        }

        public async Task<List<ReservationDto>> GetAllReservation()
        {
            var reservations = await _reservationRepository.GetAllAsync();
            return reservations.Select(ReservationDto.Create).ToList();
        }

        public async Task<Reservation> GetReservationByCourtDayTime(int courtId, DateOnly date, TimeSpan time)
        {
            return await _reservationRepository.GetReservationByCourtDayTime(courtId, date, time);
        }

        public async Task<List<ReservationDto>> GetAllReservationForToDay()
        {
            var date = DateOnly.FromDateTime(DateTime.Now);
            var reservations = await _reservationRepository.GetAllReservationForToDay(date);


            if (reservations == null)
                throw new Exception("No hay reservas para ese dia");

            return reservations.Select(ReservationDto.Create).ToList();
        }

        public async Task<List<ReservationDto>> GetAllReservationForDay(DateOnly date)
        {
            var reservations = await _reservationRepository.GetAllReservationForDay(date);

            if (reservations == null) 
                throw new Exception("No hay reservas para ese dia");

            return reservations.Select(ReservationDto.Create).ToList();
        } 

        public async Task<List<ReservationDto>> GetAllReservationForCourt(string courtName)
        {
            var reservations = await _reservationRepository.GetAllReservationForCourt(courtName.ToUpper());

            if (reservations == null)
                throw new Exception("No hay reservas para ese dia");

            return reservations.Select(ReservationDto.Create).ToList();
        }
        
        public async Task<List<GetReservationDto>> GetAllReservationForCourtOfDay(int courtId, string date)
        {
            
            var reservations = await _reservationRepository.GetAllReservationForCourtOfDay(courtId, DateOnly.Parse(date));

            if (reservations == null)
                throw new Exception("No hay reservas para ese dia");

            return reservations.Select(GetReservationDto.Create).ToList();
        }

        public async Task<List<MyReservationsDto>> GetMyReservation(int userId, string status)
        {
            var reservations = await _reservationRepository.GetMyReservation(userId, status);

            if (reservations == null)
                throw new Exception("No hay reservas aun");

            return reservations.Select(MyReservationsDto.Create).ToList();
        }

        public async Task<Reservation> CreateReservation(ReservationRequest request)
        {
            if (request == null) throw new Exception("Complete todos los campos");

            var court = await _courtRepository.GetById(request.CourtId);

            if (court == null) throw new Exception("Court not exist");

            var reservation = new Reservation()
            {
                Date = DateOnly.Parse(request.Date),
                Time = TimeSpan.Parse(request.Time),
                Status = StatusEnum.Pending,
                TotalPrice = (decimal)court.Price,
                ClientId = request.ClientId,
                CourtId = request.CourtId,
                CreatedAt = DateTime.UtcNow,
                PreferenceId = request.PreferenceId ?? ""
            };

            return await _reservationRepository.Create(reservation);
        }

        public async Task<Reservation> DeleteReservation(int reservationId)
        {
            var reservation = await _reservationRepository.GetById(reservationId);
            if (reservation == null)
                throw new Exception("Esta reserva no existe");

            await _reservationRepository.Delete(reservation);

            return reservation;
        }


        public async Task DeleteReservationPending(int courtId, DateOnly date, TimeSpan time)
        {
            var reservation = await _reservationRepository.GetReservationByCourtDayTime(courtId, date, time);
            if (reservation == null) throw new Exception("Reservation not exist");
            await _reservationRepository.Delete(reservation);
        }
    }
}
