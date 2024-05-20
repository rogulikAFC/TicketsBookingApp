using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using TicketsBookingApp.Models.Place;
using TicketsBookingApp.Models.Session;

namespace TicketsBookingApp.Models.Tickets
{
    public class TicketDto
    {
        public int Id { get; set; }

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public DateTime BookDateAndTime { get; set; }

        public PlaceDto Place { get; set; } = null!;

        public SessionDto Session { get; set; } = null!;

        public bool IsUsed { get; set; }
    }
}
