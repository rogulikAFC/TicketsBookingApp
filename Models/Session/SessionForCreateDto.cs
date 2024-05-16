using System.ComponentModel.DataAnnotations;

namespace TicketsBookingApp.Models.Session
{
    public class SessionForCreateDto
    {
        public int HallId { get; set; }

        public int FilmId { get; set; }

        public DateTime DateAndTime { get; set; }

        public int Price { get; set; }
    }
}
