using Microsoft.EntityFrameworkCore;

namespace TicketsBookingApp.Entities.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly TicketsBookingAppDbContext _context;

        public PlaceRepository(TicketsBookingAppDbContext context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Place entity)
        {
            _context.Places.Add(entity);
        }

        public void Delete(Place entity)
        {
            _context.Places.Remove(entity);
        }

        public async Task<Place?> GetByIdAsync(int id)
        {
            return await _context.Places
                .FirstOrDefaultAsync(place => place.Id == id);
        }

        public async Task<Place?> GetByIdAsync(int hallId, int Row, int Col)
        {
            return await _context.Places
                .FirstOrDefaultAsync(place => 
                    place.HallId == hallId
                    && place.Row == Row
                    && place.Col == Col);
        }

        public async Task<IEnumerable<Place>> ListAsync(int pageNum, int pageSize)
        {
            return await _context.Places
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Place>> PlacesWithStatusBySession(Session session)
        {
            var places = _context.Places
                .Where(p => p.HallId == session.HallId);

            await places.ForEachAsync(p => p.IsBooked = false);

            await places
                .Where(p => p.Tickets
                    .Where(t => t.SessionId == session.Id)
                    .Any())
                .ForEachAsync(p => p.IsBooked = true);

            return await places.ToListAsync();
        }
    }
}
