using TicketsBookingApp.Entities.Repositories;

namespace TicketsBookingApp.Entities.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICinemaRepository CinemaRepository { get; }

        public Task<bool> SaveChangesAsync();
    }
}
