using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IReservationRepository : IBaseRepository<Reservation>
    {
        Task<List<Reservation>> GetAllAsync();
        Task<Reservation> GetByPreferenceId(string preferenceId);
        Task<List<Reservation>> GetAllReservationForToDay(DateOnly date);
        Task<List<Reservation>> GetAllReservationForDay(DateOnly date);
        Task<List<Reservation>> GetAllReservationForCourt(string courtName);
        Task<List<Reservation>> GetAllReservationForCourtOfDay(int courtId, DateOnly date);
        Task<Reservation> GetReservationByCourtDayTime(int courtId, DateOnly date, TimeSpan time);
        Task DeleteExpiredPendingReservations();
    }
}
