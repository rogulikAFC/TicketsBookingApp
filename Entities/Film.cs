using System;
using System.Collections.Generic;

namespace TicketsBookingApp.Entities;

public partial class Film
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int? AgeLimitId { get; set; }

    public int? AgeOfRelease { get; set; }

    public virtual AgeLimit? AgeLimit { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
