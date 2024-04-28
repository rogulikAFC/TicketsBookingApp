using System;
using System.Collections.Generic;

namespace TicketsBookingApp.Entities;

public partial class Session
{
    public int Id { get; set; }

    public int? CinemaId { get; set; }

    public int? FilmId { get; set; }

    public DateTime? DateAndTime { get; set; }

    public int? Price { get; set; }

    public virtual Cinema? Cinema { get; set; }

    public virtual Film? Film { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
