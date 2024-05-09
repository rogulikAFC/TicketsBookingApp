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
        modelBuilder.Entity<AgeLimit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("agelimits_pkey");

            entity.ToTable("age_limits");

            entity.HasIndex(e => e.Value, "agelimits_value_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<AlignPlace>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("alignplaces_pkey");

            entity.ToTable("align_places");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Value)
                .HasMaxLength(16)
                .HasColumnName("value");
        });

        modelBuilder.Entity<Cinema>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cinema_pkey");

            entity.ToTable("cinemas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Address)
                .HasMaxLength(256)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(64)
                .HasColumnName("city");
            entity.Property(e => e.Inn)
                .HasMaxLength(12)
                .HasColumnName("inn");
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("films_pkey");

            entity.ToTable("films");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AgeLimitId).HasColumnName("age_limit_id");
            entity.Property(e => e.AgeOfRelease).HasColumnName("age_of_release");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(128)
                .HasColumnName("title");

            entity.HasOne(d => d.AgeLimit).WithMany(p => p.Films)
                .HasForeignKey(d => d.AgeLimitId)
                .HasConstraintName("films_agelimitid_fkey");
        });

        modelBuilder.Entity<Hall>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("halls_pkey");

            entity.ToTable("halls");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlignPlacesId).HasColumnName("align_places_id");
            entity.Property(e => e.CinemaId).HasColumnName("cinema_id");

            entity.HasOne(d => d.AlignPlaces).WithMany(p => p.Halls)
                .HasForeignKey(d => d.AlignPlacesId)
                .HasConstraintName("hall_alignplacesid_fkey");

            entity.HasOne(d => d.Cinema).WithMany(p => p.Halls)
                .HasForeignKey(d => d.CinemaId)
                .HasConstraintName("hall_cinemaid_fkey");
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("place_pkey");

            entity.ToTable("places");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Col).HasColumnName("col");
            entity.Property(e => e.HallId).HasColumnName("hall_id");
            entity.Property(e => e.IsTransparent)
                .HasDefaultValue(false)
                .HasColumnName("is_transparent");
            entity.Property(e => e.Row).HasColumnName("row");

            entity.HasOne(d => d.Hall).WithMany(p => p.Places)
                .HasForeignKey(d => d.HallId)
                .HasConstraintName("place_hallid_fkey");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sessions_pkey");

            entity.ToTable("sessions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CinemaId).HasColumnName("cinema_id");
            entity.Property(e => e.DateAndTime).HasColumnName("date_and_time");
            entity.Property(e => e.FilmId).HasColumnName("film_id");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Cinema).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.CinemaId)
                .HasConstraintName("sessions_cinemaid_fkey");

            entity.HasOne(d => d.Film).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.FilmId)
                .HasConstraintName("sessions_filmid_fkey");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tickets_pkey");

            entity.ToTable("tickets");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookDateAndTime).HasColumnName("book_date_and_time");
            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .HasColumnName("email");
            entity.Property(e => e.IsUsed)
                .HasDefaultValue(false)
                .HasColumnName("is_used");
            entity.Property(e => e.Phone)
                .HasMaxLength(13)
                .HasColumnName("phone");
            entity.Property(e => e.PlaceId).HasColumnName("place_id");
            entity.Property(e => e.SessionId).HasColumnName("session_id");

            entity.HasOne(d => d.Place).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.PlaceId)
                .HasConstraintName("tickets_placeid_fkey");

            entity.HasOne(d => d.Session).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("tickets_sessionid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
