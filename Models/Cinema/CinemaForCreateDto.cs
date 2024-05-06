using System.ComponentModel.DataAnnotations;

namespace TicketsBookingApp.Models.Cinema
{
    public class CinemaForCreateDto
    {
        [Required]
        public string City { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required]
        public string Inn { get; set; } = null!;

        [Required]
        public string Name { get; set; } = null!;
    }
}
