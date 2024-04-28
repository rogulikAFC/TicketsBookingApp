using System;
using System.Collections.Generic;

namespace TicketsBookingApp.Entities;

public partial class Ticket
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateTime? BookDateAndTime { get; set; }

    public int? SessionId { get; set; }

    public int? PlaceId { get; set; }

    public bool? IsUsed { get; set; }

    public virtual Place? Place { get; set; }

    public virtual Session? Session { get; set; }
}
