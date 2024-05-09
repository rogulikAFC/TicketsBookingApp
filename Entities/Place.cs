using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsBookingApp.Entities;

[Index(nameof(Row), nameof(Col), nameof(HallId), IsUnique = true)]
public class Place
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int Row { get; set; }

    [Required]
    public int Col { get; set; }

    [Required]
    public int HallId { get; set; }

    [Required]
    public bool IsTransparent { get; set; } = false;

    [ForeignKey(nameof(HallId))]
    public virtual Hall Hall { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
