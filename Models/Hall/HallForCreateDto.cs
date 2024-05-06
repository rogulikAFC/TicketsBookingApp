using TicketsBookingApp.Entities;
using TicketsBookingApp.Models.Place;

namespace TicketsBookingApp.Models.Hall
{
    public class HallForCreateDto
    {
        public int CinemaId { get; set; }

        public string AlignPlaces { get; set; } = null!;

        public ICollection<PlaceForCreateDto> Places { get; set; }
           = new List<PlaceForCreateDto>(); 
    }
}
