using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuwaiq_Session_Booking.Data.Migrations
{
    public partial class ApplicationUserIdToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_AspNetUsers_ApplicationUserId1",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ApplicationUserId1",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Profiles");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Profiles",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ApplicationUserId",
                table: "Profiles",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_AspNetUsers_ApplicationUserId",
                table: "Profiles",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_AspNetUsers_ApplicationUserId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ApplicationUserId",
                table: "Profiles");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Profiles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ApplicationUserId1",
                table: "Profiles",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_AspNetUsers_ApplicationUserId1",
                table: "Profiles",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
