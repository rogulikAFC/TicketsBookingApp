using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsBookingApp.Entities;

public partial class Session
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int CinemaId { get; set; }

    [Required]
    public int FilmId { get; set; }

    [Required]
    public DateTime DateAndTime { get; set; }

    [Required]
    public int Price { get; set; }

    [ForeignKey(nameof(CinemaId))]
    public virtual Cinema Cinema { get; set; } = null!;

    [ForeignKey(nameof(FilmId))]
    public virtual Film Film { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
