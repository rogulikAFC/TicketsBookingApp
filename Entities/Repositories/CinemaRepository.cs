using Microsoft.EntityFrameworkCore;

namespace TicketsBookingApp.Entities.Repositories
{
    public class CinemaRepository: ICinemaRepository
    {
        private readonly TicketsBookingAppDbContext _context;

        public CinemaRepository(TicketsBookingAppDbContext context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Cinema>> ListAsync(
            int pageNum = 1, int pageSize = 3)
        {
            if (pageNum == 0) pageNum = 1;
            if (pageSize == 0) pageSize = 3;

            return await _context.Cinemas
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Cinema?> GetByIdAsync(int id)
        {
            return await _context.Cinemas
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Add(Cinema entity)
        {
            _context.Cinemas.Add(entity);
        }

        public void Delete(Cinema entity)
        {
            _context.Remove(entity);
        }
    }
}
