namespace TicketsBookingApp.Entities.Repositories
{
    public interface ITicketRepository : ICRUDRepository<Ticket>
    {
        Task<IEnumerable<Ticket>> ListAsync(
            string? phone, string? email, bool? isUsed);

        Task<Ticket?> GetByPhoneOrEmailAndSessionId(
            string? phone, string? email, int sessionId);
    }
}
