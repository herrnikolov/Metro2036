using Microsoft.EntityFrameworkCore.Migrations;

namespace Metro2036.Data.Migrations
{
    public partial class PointModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StopName",
                table: "Points",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StopName",
                table: "Points",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
