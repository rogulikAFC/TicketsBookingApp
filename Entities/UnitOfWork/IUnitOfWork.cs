using TicketsBookingApp.Entities.Repositories;

namespace TicketsBookingApp.Entities.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICinemaRepository CinemaRepository { get; }

        IHallRepository HallRepository { get; }

        IPlaceRepository PlaceRepository { get; }

        IFilmRepository FilmRepository { get; }

        ISessionRepository SessionRepository { get; }

        ITicketRepository TicketRepository { get; }

        public Task<bool> SaveChangesAsync();
    }
}
