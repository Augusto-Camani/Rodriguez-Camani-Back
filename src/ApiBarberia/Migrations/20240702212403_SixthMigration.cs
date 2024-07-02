using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBarberia.Migrations
{
    /// <inheritdoc />
    public partial class SixthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Reviews_AppointmentId",
                table: "Appointments");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Appointments_ReviewId",
                table: "Reviews",
                column: "ReviewId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Appointments_ReviewId",
                table: "Reviews");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Reviews_AppointmentId",
                table: "Appointments",
                column: "AppointmentId",
                principalTable: "Reviews",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
