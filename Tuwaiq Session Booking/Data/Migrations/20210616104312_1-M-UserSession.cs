using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuwaiq_Session_Booking.Data.Migrations
{
    public partial class _1MUserSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Sessions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ApplicationUserId",
                table: "Sessions",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_AspNetUsers_ApplicationUserId",
                table: "Sessions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_AspNetUsers_ApplicationUserId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_ApplicationUserId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Sessions");
        }
    }
}
