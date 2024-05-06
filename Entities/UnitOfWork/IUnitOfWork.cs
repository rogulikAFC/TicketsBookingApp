using TicketsBookingApp.Entities.Repositories;

namespace TicketsBookingApp.Entities.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICinemaRepository CinemaRepository { get; }

        IHallRepository HallRepository { get; }

        IPlaceRepository PlaceRepository { get; }

        public Task<bool> SaveChangesAsync();
    }
}
