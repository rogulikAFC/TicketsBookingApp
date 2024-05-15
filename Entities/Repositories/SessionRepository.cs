
using Microsoft.EntityFrameworkCore;

namespace TicketsBookingApp.Entities.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly TicketsBookingAppDbContext _context;

        public SessionRepository(TicketsBookingAppDbContext context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Session entity)
        {
            _context.Sessions.Add(entity);
        }

        public void Delete(Session entity)
        {
            _context.Sessions.Remove(entity);
        }

        public async Task<Session?> GetByIdAsync(int id)
        {
            return await _context.Sessions
                .Include(s => s.Hall)
                .Include(s => s.Film)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Session>> ListAsync(int pageNum, int pageSize)
        {
            return await _context.Sessions
                .Include(s => s.Hall)
                .Include(s => s.Film)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
