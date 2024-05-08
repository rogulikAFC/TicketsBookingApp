﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TicketsBookingApp.Entities;

#nullable disable

namespace TicketsBookingApp.Migrations
{
    [DbContext(typeof(TicketsBookingAppDbContext))]
    [Migration("20240508161102_PlaceAlternativeKeyAdded")]
    partial class PlaceAlternativeKeyAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TicketsBookingApp.Entities.AgeLimit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Value")
                        .HasColumnType("integer")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("agelimits_pkey");

                    b.HasIndex(new[] { "Value" }, "agelimits_value_key")
                        .IsUnique();

                    b.ToTable("age_limits", (string)null);
                });

            modelBuilder.Entity("TicketsBookingApp.Entities.AlignPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("alignplaces_pkey");

                    b.ToTable("align_places", (string)null);
                });

            modelBuilder.Entity("TicketsBookingApp.Entities.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("city");

                    b.Property<string>("Inn")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)")
                        .HasColumnName("inn");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("cinema_pkey");

                    b.ToTable("cinemas", (string)null);
                });

            modelBuilder.Entity("TicketsBookingApp.Entities.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AgeLimitId")
                        .HasColumnType("integer")
                        .HasColumnName("age_limit_id");

                    b.Property<int?>("AgeOfRelease")
                        .HasColumnType("integer")
                        .HasColumnName("age_of_release");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("films_pkey");

                    b.HasIndex("AgeLimitId");

                    b.ToTable("films", (string)null);
                });

            modelBuilder.Entity("TicketsBookingApp.Entities.Hall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AlignPlacesId")
                        .HasColumnType("integer")
                        .HasColumnName("align_places_id");

                    b.Property<int>("CinemaId")
                        .HasColumnType("integer")
                        .HasColumnName("cinema_id");

                    b.HasKey("Id")
                        .HasName("halls_pkey");

                    b.HasIndex("AlignPlacesId");

                    b.HasIndex("CinemaId");

                    b.ToTable("halls", (string)null);
                });

            modelBuilder.Entity("TicketsBookingApp.Entities.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Col")
                        .HasColumnType("integer")
                        .HasColumnName("col");

                    b.Property<int?>("HallId")
                        .IsRequired()
                        .HasColumnType("integer")
                        .HasColumnName("hall_id");

                    b.Property<bool?>("IsTransparent")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_transparent");

                    b.Property<int>("Row")
                        .HasColumnType("integer")
                        .HasColumnName("row");

                    b.HasKey("Id")
                        .HasName("place_pkey");

                    b.HasAlternateKey("HallId", "Col", "Row");

                    b.ToTable("places", (string)null);
                });

            modelBuilder.Entity("TicketsBookingApp.Entities.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CinemaId")
                        .HasColumnType("integer")
                        .HasColumnName("cinema_id");

                    b.Property<DateTime?>("DateAndTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_and_time");

                    b.Property<int?>("FilmId")
                        .HasColumnType("integer")
                        .HasColumnName("film_id");

                    b.Property<int?>("Price")
                        .HasColumnType("integer")
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("sessions_pkey");

                    b.HasIndex("CinemaId");

                    b.HasIndex("FilmId");

                    b.ToTable("sessions", (string)null);
                });

            modelBuilder.Entity("TicketsBookingApp.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("BookDateAndTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("book_date_and_time");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("character varying(254)")
                        .HasColumnName("email");

                    b.Property<bool?>("IsUsed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_used");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)")
                        .HasColumnName("phone");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("integer")
                        .HasColumnName("place_id");

                    b.Property<int?>("SessionId")
                        .HasColumnType("integer")
                        .HasColumnName("session_id");

                    b.HasKey("Id")
                        .HasName("tickets_pkey");

                    b.HasIndex("PlaceId");

                    b.HasIndex("SessionId");

                    b.ToTable("tickets", (string)null);
                });

            modelBuilder.Entity("TicketsBookingApp.Entities.Film", b =>
                {
                    b.HasOne("TicketsBookingApp.Entities.AgeLimit", "AgeLimit")
                        .WithMany("Films")
                        .HasForeignKey("AgeLimitId")
                        .HasConstraintName("films_agelimitid_fkey");

                    b.Navigation("AgeLimit");
                });

            modelBuilder.Entity("TicketsBookingApp.Entities.Hall", b =>
                {
                    b.HasOne("TicketsBookingApp.Entities.AlignPlace", "AlignPlaces")
                        .WithMany("Halls")
                        .HasForeignKey("AlignPlacesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("hall_alignplacesid_fkey");

                    b.HasOne("TicketsBookingApp.Entities.Cinema", "Cinema")
                        .WithMany("Halls")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("hall_cinemaid_fkey");

                    b.Navigation("AlignPlaces");

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("TicketsBookingApp.Entities.Place", b =>
                {
                    b.HasOne("TicketsBookingApp.Entities.Hall", "Hall")
                        .WithMany("Places")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("place_hallid_fkey");

                    b.Navigation("Hall");
                });

            modelBuilder.Entity("TicketsBookingApp.Entities.Session", b =>
                {
                    b.HasOne("TicketsBookingApp.Entities.Cinema", "Cinema")
                        .WithMany("Sessions")
                        .HasForeignKey("CinemaId")
                        .HasConstraintName("sessions_cinemaid_fkey");

                    b.HasOne("TicketsBookingApp.Entities.Film", "Film")
                        .WithMany("Sessions")
                        .HasForeignKey("FilmId")
                        .HasConstraintName("sessions_filmid_fkey");

                    b.Navigation("Cinema");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("TicketsBookingApp.Entities.Ticket", b =>
                {
                    b.HasOne("TicketsBookingApp.Entities.Place", "Place")
                        .WithMany("Tickets")
                        .HasForeignKey("PlaceId")
                        .HasConstraintName("tickets_placeid_fkey");

                    b.HasOne("TicketsBookingApp.Entities.Session", "Session")
                        .WithMany("Tickets")
                        .HasForeignKey("SessionId")
                        .HasConstraintName("tickets_sessionid_fkey");

                    b.Navigation("Place");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("TicketsBookingApp.Entities.AgeLimit", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("TicketsBookingApp.Entities.AlignPlace", b =>
                {
                    b.Navigation("Halls");
                });

            modelBuilder.Entity("TicketsBookingApp.Entities.Cinema", b =>
                {
                    b.Navigation("Halls");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("TicketsBookingApp.Entities.Film", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("TicketsBookingApp.Entities.Hall", b =>
                {
                    b.Navigation("Places");
                });

            modelBuilder.Entity("TicketsBookingApp.Entities.Place", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("TicketsBookingApp.Entities.Session", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
