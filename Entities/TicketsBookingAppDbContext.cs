using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TicketsBookingApp.Entities;

public partial class TicketsBookingAppDbContext : DbContext
{
    public TicketsBookingAppDbContext()
    {
    }

    public TicketsBookingAppDbContext(DbContextOptions<TicketsBookingAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgeLimit> AgeLimits { get; set; }

    public virtual DbSet<AlignPlace> AlignPlaces { get; set; }

    public virtual DbSet<Cinema> Cinemas { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Hall> Halls { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Place>()
            .Ignore(p => p.IsBooked);
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
