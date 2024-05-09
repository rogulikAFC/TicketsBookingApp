namespace TicketsBookingApp.Models.Film
{
    public class FilmDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public int? AgeLimit { get; set; } 

        public int? AgeOfRelease { get; set; }
    }
}
