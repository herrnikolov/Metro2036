using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Metro2036.Web.Data.Migrations
{
    public partial class BaseLine : Migration
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

            migrationBuilder.RenameColumn(
                name: "TravelId",
                table: "AspNetUsers",
                newName: "TravelCardId");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Trains",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Trains",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TravelLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    StationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelLogs_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelLogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelLogs_StationId",
                table: "TravelLogs",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelLogs_UserId",
                table: "TravelLogs",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelLogs");

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

            migrationBuilder.RenameColumn(
                name: "TravelCardId",
                table: "AspNetUsers",
                newName: "TravelId");

            migrationBuilder.AddColumn<int>(
                name: "OperationalSpeed",
                table: "Trains",
                nullable: false,
                defaultValue: 0);
        }
    }
}
