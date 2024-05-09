using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsBookingApp.Entities;

public partial class Film
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(128)]
    public string Title { get; set; } = null!;

    [MaxLength(2048)]
    public string? Description { get; set; }

    [Required]
    public int AgeLimitId { get; set; }

    public int? AgeOfRelease { get; set; }

    public virtual AgeLimit AgeLimit { get; set; } = null!;

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
