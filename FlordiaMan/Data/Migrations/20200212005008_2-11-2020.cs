using Microsoft.EntityFrameworkCore.Migrations;

namespace FlordiaMan.Data.Migrations
{
    public partial class _2112020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Qunatity",
                table: "Ticket",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qunatity",
                table: "Ticket");
        }
    }
}
