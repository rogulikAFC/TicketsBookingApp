
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

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
                .ThenInclude(h => h.Cinema)
                .Include(s => s.Film)
                .ThenInclude(f => f.AgeLimit)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Session>> ListAsync(int pageNum, int pageSize)
        {
            return await _context.Sessions
                .Include(s => s.Hall)
                .ThenInclude(h => h.Cinema)
                .Include(s => s.Film)
                .ThenInclude(f => f.AgeLimit)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Session>> ListAsync(
            int pageNum, int pageSize, int cinemaId)
        {
            return await _context.Sessions
                .Include(s => s.Hall)
                .ThenInclude(h => h.Cinema)
                .Include(s => s.Film)
                .ThenInclude(f => f.AgeLimit)
                .Join(
                    _context.Halls,
                    s => s.HallId,
                    h => h.Id,
                    (s, h) => new 
                    {
                        s.Id,
                        s.FilmId,
                        s.HallId,
                        s.DateAndTime,
                        s.Price,
                        s.Film,
                        s.Hall,
                        s.Tickets,
                        h.CinemaId,
                        h.Cinema
                    })
                .Where(s => s.CinemaId == cinemaId)
                .Select(s => new Session()
                {
                    Id = s.Id,
                    FilmId = s.FilmId,
                    HallId = s.HallId,
                    DateAndTime = s.DateAndTime,
                    Price = s.Price,
                    Film = s.Film,
                    Hall = s.Hall,
                    Tickets = s.Tickets,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<Session>> ListCinemaSessions(
            Cinema cinema, int pageNum, int pageSize)
        {
            var hallIds = cinema.Halls.Select(h => h.Id);

            return await _context.Sessions
                .Where(s => hallIds.Contains(s.Id))
                .Skip((pageNum - 1) * pageSize)
                .ToListAsync();
        }
    }
}
