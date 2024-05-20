using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsBookingApp.Entities;

[Index(nameof(SessionId), nameof(PlaceId), IsUnique = true)]
public partial class Ticket
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [Phone]
    public string Phone { get; set; } = null!;

    [Required]
    public DateTime BookDateAndTime { get; set; } = DateTime.Now;

    [Required]
    public int SessionId { get; set; }

    [Required]
    public int PlaceId { get; set; }

    [Required]
    public bool IsUsed { get; set; } = false;

    [ForeignKey(nameof(PlaceId))]
    public virtual Place Place { get; set; } = null!;

    [ForeignKey(nameof(SessionId))]
    public virtual Session Session { get; set; } = null!;
}
