using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TicketsBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "age_limits",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("agelimits_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "align_places",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    value = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("alignplaces_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cinemas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    city = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    address = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    inn = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cinema_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "films",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    age_limit_id = table.Column<int>(type: "integer", nullable: true),
                    age_of_release = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("films_pkey", x => x.id);
                    table.ForeignKey(
                        name: "films_agelimitid_fkey",
                        column: x => x.age_limit_id,
                        principalTable: "age_limits",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "halls",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cinema_id = table.Column<int>(type: "integer", nullable: true),
                    align_places_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("halls_pkey", x => x.id);
                    table.ForeignKey(
                        name: "hall_alignplacesid_fkey",
                        column: x => x.align_places_id,
                        principalTable: "align_places",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "hall_cinemaid_fkey",
                        column: x => x.cinema_id,
                        principalTable: "cinemas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "sessions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cinema_id = table.Column<int>(type: "integer", nullable: true),
                    film_id = table.Column<int>(type: "integer", nullable: true),
                    date_and_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    price = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sessions_pkey", x => x.id);
                    table.ForeignKey(
                        name: "sessions_cinemaid_fkey",
                        column: x => x.cinema_id,
                        principalTable: "cinemas",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "sessions_filmid_fkey",
                        column: x => x.film_id,
                        principalTable: "films",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "places",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    row = table.Column<int>(type: "integer", nullable: false),
                    col = table.Column<int>(type: "integer", nullable: false),
                    hall_id = table.Column<int>(type: "integer", nullable: true),
                    is_transparent = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("place_pkey", x => x.id);
                    table.ForeignKey(
                        name: "place_hallid_fkey",
                        column: x => x.hall_id,
                        principalTable: "halls",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: false),
                    phone = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    book_date_and_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    session_id = table.Column<int>(type: "integer", nullable: true),
                    place_id = table.Column<int>(type: "integer", nullable: true),
                    is_used = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tickets_pkey", x => x.id);
                    table.ForeignKey(
                        name: "tickets_placeid_fkey",
                        column: x => x.place_id,
                        principalTable: "places",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "tickets_sessionid_fkey",
                        column: x => x.session_id,
                        principalTable: "sessions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "agelimits_value_key",
                table: "age_limits",
                column: "value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_films_age_limit_id",
                table: "films",
                column: "age_limit_id");

            migrationBuilder.CreateIndex(
                name: "IX_halls_align_places_id",
                table: "halls",
                column: "align_places_id");

            migrationBuilder.CreateIndex(
                name: "IX_halls_cinema_id",
                table: "halls",
                column: "cinema_id");

            migrationBuilder.CreateIndex(
                name: "IX_places_hall_id",
                table: "places",
                column: "hall_id");

            migrationBuilder.CreateIndex(
                name: "IX_sessions_cinema_id",
                table: "sessions",
                column: "cinema_id");

            migrationBuilder.CreateIndex(
                name: "IX_sessions_film_id",
                table: "sessions",
                column: "film_id");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_place_id",
                table: "tickets",
                column: "place_id");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_session_id",
                table: "tickets",
                column: "session_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "places");

            migrationBuilder.DropTable(
                name: "sessions");

            migrationBuilder.DropTable(
                name: "halls");

            migrationBuilder.DropTable(
                name: "films");

            migrationBuilder.DropTable(
                name: "align_places");

            migrationBuilder.DropTable(
                name: "cinemas");

            migrationBuilder.DropTable(
                name: "age_limits");
        }
    }
}
