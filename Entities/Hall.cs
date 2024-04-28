using System;
using System.Collections.Generic;

namespace TicketsBookingApp.Entities;

public partial class Hall
{
    public int Id { get; set; }

    public int? CinemaId { get; set; }

    public int? AlignPlacesId { get; set; }

    public virtual AlignPlace? AlignPlaces { get; set; }

    public virtual Cinema? Cinema { get; set; }

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();
}
