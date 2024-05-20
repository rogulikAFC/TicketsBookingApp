namespace TicketsBookingApp.Models.Place
{
    public class PlaceDto
    {
        public int Id { get; set; }

        public int Row {  get; set; }

        public int Col { get; set; }

        public bool IsTransparent { get; set; }

        public bool? IsBooked { get; set; }
    }
}
