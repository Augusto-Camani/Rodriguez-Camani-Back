using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBarberia.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Reviwes_ReviewId",
                table: "Replies");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviwes_Appointments_ReviewId",
                table: "Reviwes");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviwes_Users_UserId",
                table: "Reviwes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviwes",
                table: "Reviwes");

            migrationBuilder.RenameTable(
                name: "Reviwes",
                newName: "Reviews");

            migrationBuilder.RenameIndex(
                name: "IX_Reviwes_UserId",
                table: "Reviews",
                newName: "IX_Reviews_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Reviews_ReviewId",
                table: "Replies",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Appointments_ReviewId",
                table: "Reviews",
                column: "ReviewId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Reviews_ReviewId",
                table: "Replies");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Appointments_ReviewId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Reviwes");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserId",
                table: "Reviwes",
                newName: "IX_Reviwes_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviwes",
                table: "Reviwes",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Reviwes_ReviewId",
                table: "Replies",
                column: "ReviewId",
                principalTable: "Reviwes",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviwes_Appointments_ReviewId",
                table: "Reviwes",
                column: "ReviewId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviwes_Users_UserId",
                table: "Reviwes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
