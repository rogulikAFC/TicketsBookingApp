namespace TicketsBookingApp.Models.Tickets
{
    public class TicketForCreateDto
    {
        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public int SessionId { get; set; }

        public int PlaceId { get; set; }
    }
}
