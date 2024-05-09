using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsBookingApp.Entities;

public partial class Cinema
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(64)]
    public string City { get; set; } = null!;

    [Required]
    [MaxLength(256)]
    public string Address { get; set; } = null!;

    [Required]
    [MaxLength(32)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(12)]
    public string Inn { get; set; } = null!;

    public virtual ICollection<Hall> Halls { get; set; } = new List<Hall>();

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
