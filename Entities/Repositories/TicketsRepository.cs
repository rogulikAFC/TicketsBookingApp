using Microsoft.EntityFrameworkCore;

namespace TicketsBookingApp.Entities.Repositories
{
    public class TicketsRepository : ITicketRepository
    {
        private readonly TicketsBookingAppDbContext _context;

        public TicketsRepository(TicketsBookingAppDbContext context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Ticket entity)
        {
            _context.Add(entity);
        }

        public void Delete(Ticket entity)
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<Ticket>> ListAsync(string? phone, string? email, bool? isUsed)
        {
            return await _context.Tickets
                .Where(t => 
                    (t.Phone == phone || t.Email == email)
                    & t.IsUsed == isUsed)
                .ToListAsync();
        }

        public async Task<Ticket?> GetByIdAsync(int id)
        {
            return await _context.Tickets
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Ticket?> GetByPhoneOrEmailAndSessionId(string? phone, string? email, int sessionId)
        {
            return await _context.Tickets
                .FirstOrDefaultAsync(t =>
                    (t.Phone == phone || t.Email == email)
                    && t.SessionId == sessionId);
        }

        public async Task<IEnumerable<Ticket>> ListAsync(int pageNum, int pageSize)
        {
            return await _context.Tickets
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
