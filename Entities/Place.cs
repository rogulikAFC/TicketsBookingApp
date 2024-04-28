using System;
using System.Collections.Generic;

namespace TicketsBookingApp.Entities;

public partial class Place
{
    public int Id { get; set; }

    public int Row { get; set; }

    public int Col { get; set; }

    public int? HallId { get; set; }

    public bool? IsTransparent { get; set; }

    public virtual Hall? Hall { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
