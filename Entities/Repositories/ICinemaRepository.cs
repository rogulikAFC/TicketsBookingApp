namespace TicketsBookingApp.Entities.Repositories
{
    public interface ICinemaRepository
    {
        Task<IEnumerable<Cinema>> ListAsync(int pageNum, int pageSize);
        Task<Cinema?> GetByIdAsync(int id);
        void Add(Cinema cinema);
        void Delete(Cinema cinema);
    }
}
