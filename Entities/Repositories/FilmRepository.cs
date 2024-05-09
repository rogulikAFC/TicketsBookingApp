
using Microsoft.EntityFrameworkCore;

namespace TicketsBookingApp.Entities.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly TicketsBookingAppDbContext _dbContext;

        public FilmRepository(TicketsBookingAppDbContext dbContext)
        {
            _dbContext = dbContext
                ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Add(Film entity)
        {
            _dbContext.Films.Add(entity);
        }

        public void Delete(Film entity)
        {
            _dbContext.Films.Remove(entity);
        }

        public async Task<Film?> GetByIdAsync(int id)
        {
            return await _dbContext.Films
                .Include(f => f.AgeLimit)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Film>> ListAsync(int pageNum, int pageSize)
        {
            return await _dbContext.Films
                .Include(f => f.AgeLimit)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
