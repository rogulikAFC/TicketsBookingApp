using System;
using System.Collections.Generic;

namespace TicketsBookingApp.Entities;

public partial class AgeLimit
{
    public int Id { get; set; }

    public int Value { get; set; }

    public virtual ICollection<Film> Films { get; set; } = new List<Film>();
}
