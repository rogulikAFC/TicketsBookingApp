using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketsBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class CinemaNameAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "cinemas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "cinemas");
        }
    }
}
