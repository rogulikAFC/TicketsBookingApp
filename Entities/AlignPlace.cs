using System;
using System.Collections.Generic;

namespace TicketsBookingApp.Entities;

public partial class AlignPlace
{
    public int Id { get; set; }

    public string Value { get; set; } = null!;

    public virtual ICollection<Hall> Halls { get; set; } = new List<Hall>();
}
