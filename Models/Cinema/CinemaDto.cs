using TicketsBookingApp.Entities;

namespace TicketsBookingApp.Models.Cinema
{
    public class CinemaDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string FullAddress { get; set; } = null!;

        public string Inn { get; set; } = null!;

        public virtual IEnumerable<Hall> Halls { get; set; } = new List<Hall>();

        public virtual IEnumerable<Session> Sessions { get; set; } = new List<Session>();
    }
}
