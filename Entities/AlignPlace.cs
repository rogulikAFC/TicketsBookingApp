using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsBookingApp.Entities;

public partial class AlignPlace
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(16)]
    public string Value { get; set; } = null!;

    public virtual ICollection<Hall> Halls { get; set; } = new List<Hall>();
}
