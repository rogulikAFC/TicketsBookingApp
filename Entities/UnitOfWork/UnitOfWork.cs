using TicketsBookingApp.Entities.Repositories;

namespace TicketsBookingApp.Entities.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TicketsBookingAppDbContext _context;

        public UnitOfWork(TicketsBookingAppDbContext context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
            
            CinemaRepository = new CinemaRepository(_context);

            HallRepository = new HallRepository(_context);

            PlaceRepository = new PlaceRepository(_context);
        }

        public ICinemaRepository CinemaRepository { get; }
        
        public IHallRepository HallRepository { get; }

        public IPlaceRepository PlaceRepository { get; }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) == 1;
        }
    }
}
