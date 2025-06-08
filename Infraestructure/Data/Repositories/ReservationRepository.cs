using Application.Models.Responses;
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

namespace Infrastructure.Data.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        private readonly ApplicationContext _context;

        public ReservationRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Reservation>> GetAllReservationForToDay(DateOnly date)
        {
            return await _context.Reservations
                .Include(c => c.Client)
                .Include(c => c.Court)
                .Where(c => c.Date == date)
                .ToListAsync();
        }
        public async Task<List<Reservation>> GetAllReservationForDay(DateOnly date)
        {
            return await _context.Reservations
                .Include(c => c.Client)
                .Include(c => c.Court)
                .Where(c => c.Date == date)
                .ToListAsync();
        }
        public async Task<List<Reservation>> GetAllReservationForCourt(int courtId)
        {
            return await _context.Reservations
                .Include(c => c.Client)
                .Include(c => c.Court)
                .Where(c => c.Court.Id == courtId)
                .ToListAsync();
        }
        
        public async Task<List<Reservation>> GetAllReservationForCourtOfToday(int courtId, DateOnly date)
        {
            return await _context.Reservations
                .Include(c => c.Client)
                .Include(c => c.Court)
                .Where(c => c.Court.Id == courtId && c.Date == date)
                .ToListAsync();
        }
    }
}
