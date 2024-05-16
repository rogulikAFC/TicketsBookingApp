namespace TicketsBookingApp.Entities.Repositories
{
    public interface ISessionRepository : ICRUDRepository<Session> 
    {
        //Task<IEnumerable<Session>> ListCinemaSessions(Cinema cinema, int pageNum, int pageSize);
        Task<IEnumerable<Session>> ListAsync(int pageNum, int pageSize, int cinemaId);
    }
}
