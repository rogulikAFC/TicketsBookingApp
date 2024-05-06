using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketsBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class AlterHallCinemaAndAlignPlacesNotNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "hall_alignplacesid_fkey",
                table: "halls");

            migrationBuilder.DropForeignKey(
                name: "hall_cinemaid_fkey",
                table: "halls");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "cinemas",
                newName: "name");

            migrationBuilder.AlterColumn<int>(
                name: "cinema_id",
                table: "halls",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "align_places_id",
                table: "halls",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "inn",
                table: "cinemas",
                type: "character varying(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(12)",
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "hall_alignplacesid_fkey",
                table: "halls",
                column: "align_places_id",
                principalTable: "align_places",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "hall_cinemaid_fkey",
                table: "halls",
                column: "cinema_id",
                principalTable: "cinemas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "hall_alignplacesid_fkey",
                table: "halls");

            migrationBuilder.DropForeignKey(
                name: "hall_cinemaid_fkey",
                table: "halls");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "cinemas",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "cinema_id",
                table: "halls",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "align_places_id",
                table: "halls",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "inn",
                table: "cinemas",
                type: "character varying(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(12)",
                oldMaxLength: 12);

            migrationBuilder.AddForeignKey(
                name: "hall_alignplacesid_fkey",
                table: "halls",
                column: "align_places_id",
                principalTable: "align_places",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "hall_cinemaid_fkey",
                table: "halls",
                column: "cinema_id",
                principalTable: "cinemas",
                principalColumn: "id");
        }
    }
}
