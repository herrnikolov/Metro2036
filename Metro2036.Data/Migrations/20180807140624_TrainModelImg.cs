using Microsoft.EntityFrameworkCore.Migrations;

namespace Metro2036.Web.Data.Migrations
{
    public partial class TrainModelImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperationalSpeed",
                table: "Trains");

            migrationBuilder.RenameColumn(
                name: "YearOfManufacturing",
                table: "Trains",
                newName: "Speed");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Trains",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Trains",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Trains");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Trains");

            migrationBuilder.RenameColumn(
                name: "Speed",
                table: "Trains",
                newName: "YearOfManufacturing");

            migrationBuilder.AddColumn<int>(
                name: "OperationalSpeed",
                table: "Trains",
                nullable: false,
                defaultValue: 0);
        }
    }
}
