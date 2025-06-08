using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Repositories
{
    public class CourtRepository : BaseRepository<Court>, ICourtRepository
    {
        private readonly ApplicationContext _context;

        public CourtRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Court>> GetAllCourts()
        {
            return await _context.Courts
                .Include(c => c.Reservations)
                .ToListAsync();
        }
    }
}
