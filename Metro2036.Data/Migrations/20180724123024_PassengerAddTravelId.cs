using Microsoft.EntityFrameworkCore.Migrations;

namespace Metro2036.Data.Migrations
{
    public partial class PassengerAddTravelId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TravelId",
                table: "Passengers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Passengers_TravelId",
                table: "Passengers",
                column: "TravelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Passengers_TravelId",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "TravelId",
                table: "Passengers");
        }
    }
}
