namespace TicketsBookingApp.Models.Film
{
    public class FilmForCreateDto
    {
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public int AgeLimit { get; set; }

        public int? AgeOfRelease { get; set; }
    }
}
