using System;
using System.Collections.Generic;

namespace TicketsBookingApp.Entities;

public partial class Cinema
{
    public int Id { get; set; }

    public string City { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Inn { get; set; } = null!;

    public virtual ICollection<Hall> Halls { get; set; } = new List<Hall>();

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
