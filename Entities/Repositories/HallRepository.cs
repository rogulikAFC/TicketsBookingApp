using Microsoft.EntityFrameworkCore;

namespace TicketsBookingApp.Entities.Repositories
{   

    public class HallRepository : IHallRepository
    {
        private readonly TicketsBookingAppDbContext _context;

        public HallRepository(TicketsBookingAppDbContext context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Hall entity)
        {
            _context.Halls.Add(entity);
        }

        public void Delete(Hall entity)
        {
            _context.Halls.Remove(entity);
        }

        public async Task<Hall?> GetByIdAsync(int id)
        {
            return await _context.Halls
                .Include(h => h.Places)
                .Include(h => h.Cinema)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<IEnumerable<Hall>> ListAsync(int pageNum, int pageSize)
        {
            return await _context.Halls
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .Include(h => h.Places)
                .Include(h => h.Cinema)
                .ToListAsync();
        }
    }
}
