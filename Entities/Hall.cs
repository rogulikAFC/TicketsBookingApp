using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsBookingApp.Entities;

public class Hall
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int CinemaId { get; set; }

    [Required]
    public int AlignPlacesId { get; set; }

    [ForeignKey(nameof(AlignPlacesId))]
    public virtual AlignPlace AlignPlaces { get; set; } = null!;

    [ForeignKey(nameof(CinemaId))]
    public virtual Cinema Cinema { get; set; } = null!;

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
