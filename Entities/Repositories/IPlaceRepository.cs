namespace TicketsBookingApp.Entities.Repositories
{
    public interface IPlaceRepository : ICRUDRepository<Place>
    {
        Task<Place?> GetByIdAsync(int hallId, int Col, int Row);
    }
}
