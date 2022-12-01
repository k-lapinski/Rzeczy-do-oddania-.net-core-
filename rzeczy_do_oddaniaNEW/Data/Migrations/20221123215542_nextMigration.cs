using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rzeczy_do_oddaniaNEW.Data.Migrations
{
    public partial class nextMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Categories",
                newName: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Categories",
                newName: "ID");
        }
    }
}
