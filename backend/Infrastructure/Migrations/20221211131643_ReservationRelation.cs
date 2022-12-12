using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class ReservationRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationTables_Reservations_ReservationId",
                table: "ReservationTables");

            migrationBuilder.DropIndex(
                name: "IX_ReservationTables_ReservationId",
                table: "ReservationTables");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "ReservationTables");

            migrationBuilder.AddColumn<int>(
                name: "ReservationTableId",
                table: "Reservations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationTableId",
                table: "Reservations",
                column: "ReservationTableId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationTables_ReservationTableId",
                table: "Reservations",
                column: "ReservationTableId",
                principalTable: "ReservationTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationTables_ReservationTableId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservationTableId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationTableId",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "ReservationTables",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReservationTables_ReservationId",
                table: "ReservationTables",
                column: "ReservationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationTables_Reservations_ReservationId",
                table: "ReservationTables",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
