using Microsoft.EntityFrameworkCore.Migrations;

namespace Tuwaiq_Session_Booking.Data.Migrations
{
    public partial class BoolConfirmedSessionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "Sessions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "Sessions");
        }
    }
}
