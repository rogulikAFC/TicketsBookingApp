namespace TicketsBookingApp.Entities.Repositories
{
    public interface ICRUDRepository<T>
    {
        Task<IEnumerable<T>> ListAsync(int pageNum, int pageSize);
        Task<T?> GetByIdAsync(int id);
        void Add(T entity);
        void Delete(T entity);
    }
}
