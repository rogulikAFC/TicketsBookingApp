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

        public async Task<IEnumerable<Place>> ListAsync(int pageNum, int pageSize)
        {
            return await _context.Places
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
