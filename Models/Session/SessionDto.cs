using TicketsBookingApp.Entities;
using TicketsBookingApp.Models.Cinema;
using TicketsBookingApp.Models.Film;
using TicketsBookingApp.Models.Hall;

namespace TicketsBookingApp.Models.Session
{
    public class SessionDto
    {
        public int Id { get; set; }

        public DateTime DateAndTime { get; set; }

        public int? Price { get; set; }

        public HallDto Hall { get; set; } = null!;

        public FilmDto Film { get; set; } = null!;
    }
}
