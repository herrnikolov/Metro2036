using Microsoft.EntityFrameworkCore.Migrations;

namespace Metro2036.Web.Data.Migrations
{
    public partial class Update_TravelLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StationName",
                table: "TravelLogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "TravelLogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StationName",
                table: "TravelLogs");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "TravelLogs");
        }
    }
}
