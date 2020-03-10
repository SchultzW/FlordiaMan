using Microsoft.EntityFrameworkCore.Migrations;

namespace FlordiaMan.Data.Migrations
{
    public partial class _382020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Placement",
                table: "Match",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Placement",
                table: "Match");
        }
    }
}
