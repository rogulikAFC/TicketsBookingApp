using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketsBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class PlacesIsTransparentAndHallIdIsRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "place_hallid_fkey",
                table: "places");

            migrationBuilder.AlterColumn<bool>(
                name: "is_transparent",
                table: "places",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "hall_id",
                table: "places",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "place_hallid_fkey",
                table: "places",
                column: "hall_id",
                principalTable: "halls",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "place_hallid_fkey",
                table: "places");

            migrationBuilder.AlterColumn<bool>(
                name: "is_transparent",
                table: "places",
                type: "boolean",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "hall_id",
                table: "places",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "place_hallid_fkey",
                table: "places",
                column: "hall_id",
                principalTable: "halls",
                principalColumn: "id");
        }
    }
}
