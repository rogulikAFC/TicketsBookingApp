using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketsBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class SessionHallIdAddedAndCinemaIdRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Cinemas_CinemaId",
                table: "Sessions");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Sessions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "HallId",
                table: "Sessions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_HallId",
                table: "Sessions",
                column: "HallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Cinemas_CinemaId",
                table: "Sessions",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Halls_HallId",
                table: "Sessions",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Cinemas_CinemaId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Halls_HallId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_HallId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "HallId",
                table: "Sessions");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Sessions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Cinemas_CinemaId",
                table: "Sessions",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
