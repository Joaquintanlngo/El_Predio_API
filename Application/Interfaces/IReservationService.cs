using Application.Models.Request;
using Application.Models.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IReservationService
    {
        Task<List<ReservationDto>> GetAllReservation();
        Task<List<ReservationDto>> GetAllReservationForToDay();
        Task<List<ReservationDto>> GetAllReservationForDay(DateOnly date);
        Task<List<ReservationDto>> GetAllReservationForCourt(string courtName);
        Task<List<GetReservationDto>> GetAllReservationForCourtOfDay(int courtId, string date);
        Task<Reservation> CreateReservation(ReservationRequest request);
        Task<Reservation> DeleteReservation(int reservationId);
    }
}
