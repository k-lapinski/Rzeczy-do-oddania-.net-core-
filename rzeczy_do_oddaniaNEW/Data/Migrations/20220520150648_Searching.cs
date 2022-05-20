using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rzeczy_do_oddaniaNEW.Data.Migrations
{
    public partial class Searching : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Item");
        }
    }
}
