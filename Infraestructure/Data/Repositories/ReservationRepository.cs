using Application.Models.Responses;
using Domain.Constants;
using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Data.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        private readonly ApplicationContext _context;

        public ReservationRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _context.Reservations
                .Include(c => c.Client)
                .Include(c => c.Court)
                .Where(c => c.Date >= DateOnly.FromDateTime(DateTime.Today))
                .OrderBy(c => c.Date)
                .ToListAsync();
        }

        public async Task<Reservation> GetByPreferenceId(string preferenceId)
        {
            return await _context.Reservations
                .FirstOrDefaultAsync(r => r.PreferenceId == preferenceId);
        }
        public async Task<List<Reservation>> GetAllReservationForToDay(DateOnly date)
        {
            return (await _context.Reservations
                .Include(c => c.Client)
                .Include(c => c.Court)
                .Where(c => c.Date == date)
                .ToListAsync())
                .OrderBy(c => c.Time)
                .ToList();
        }
        public async Task<List<Reservation>> GetAllReservationForDay(DateOnly date)
        {
            return (await _context.Reservations
                .Include(c => c.Client)
                .Include(c => c.Court)
                .Where(c => c.Date == date)
                .ToListAsync())
                .OrderBy(c => c.Time)
                .ToList();
        }
        public async Task<List<Reservation>> GetAllReservationForCourt(string courtName)
        {
            return await _context.Reservations
                .Include(c => c.Client)
                .Include(c => c.Court)
                .Where(c => c.Court.Name == courtName)
                .Where(c => c.Date >= DateOnly.FromDateTime(DateTime.Today))
                .OrderBy(c => c.Date)
                .ToListAsync();
        }
        
        public async Task<List<Reservation>> GetAllReservationForCourtOfDay(int courtId, DateOnly date)
        {
            return await _context.Reservations
                .Include(c => c.Client)
                .Include(c => c.Court)
                .Where(c => c.Court.Id == courtId && c.Date == date)
                .ToListAsync();
        }


        public async Task<Reservation> GetReservationByCourtDayTime(int courtId, DateOnly date, TimeSpan time)
        {
            return await _context.Reservations
                .Include(c => c.Client)
                .Include(c => c.Court)
                .FirstOrDefaultAsync(c => c.CourtId == courtId && c.Date == date && c.Time == time);
        }
        public async Task<List<Reservation>> GetMyReservation(int userId, string status)
        {
            var currentTime = DateTime.Now.TimeOfDay;
            var currentDay = DateOnly.FromDateTime(DateTime.Now);


            var query = _context.Reservations
                .Include(c => c.Client)
                .Include(c => c.Court)
                .Where(c => c.ClientId == userId)
                .AsEnumerable();

            if (status == "Activas")
            {
                query = query.Where(c =>
                    c.Date > currentDay || (c.Date == currentDay && c.Time >= currentTime)
                );
            }
            else if (status == "Pasadas")
            {
                query = query.Where(c =>
                    c.Date < currentDay || (c.Date == currentDay && c.Time < currentTime)
                );
            }

            var result = query
                .OrderBy(c => c.Date)
                .ThenBy(c => c.Time)
                .ToList();

            return await Task.FromResult(result);
        }

        public async Task DeleteExpiredPendingReservations()
        {
            var now = DateTime.UtcNow;
            var expired = await _context.Reservations
                .Where(r => r.Status == StatusEnum.Pending && r.CreatedAt < now.AddMinutes(-5))
                .ToListAsync();

            if (expired.Any())
            {
                _context.Reservations.RemoveRange(expired);
                await _context.SaveChangesAsync();
            }
        }
    }
}
