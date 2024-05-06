using TicketsBookingApp.Models.Cinema;
using TicketsBookingApp.Models.Place;

namespace TicketsBookingApp.Models.Hall
{
    public class HallDto
    {
        public int Id { get; set; }

        public CinemaWithoutHallsDto? Cinema { get; set; }

        public string AlignPlaces { get; set; } = null!;

        public ICollection<PlaceDto> Places { get; set; } = new List<PlaceDto>();
    }
}
