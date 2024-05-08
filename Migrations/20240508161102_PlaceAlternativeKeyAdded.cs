using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketsBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class PlaceAlternativeKeyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_places_hall_id",
                table: "places");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_places_hall_id_col_row",
                table: "places",
                columns: new[] { "hall_id", "col", "row" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_places_hall_id_col_row",
                table: "places");

            migrationBuilder.CreateIndex(
                name: "IX_places_hall_id",
                table: "places",
                column: "hall_id");
        }
    }
}
