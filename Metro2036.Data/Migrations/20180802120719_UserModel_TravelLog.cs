using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Metro2036.Web.Data.Migrations
{
    public partial class UserModel_TravelLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TravelId",
                table: "AspNetUsers",
                newName: "TravelCardId");

            migrationBuilder.CreateTable(
                name: "TravelLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TravelCardId = table.Column<string>(nullable: false),
                    StationId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.RenameColumn(
                name: "TravelCardId",
                table: "AspNetUsers",
                newName: "TravelId");
        }
    }
}
