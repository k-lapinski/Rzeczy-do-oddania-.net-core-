using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rzeczy_do_oddaniaNEW.Data.Migrations
{
    public partial class nextMigration123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Categories_CategoryID",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Item",
                newName: "CategoryFk");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Item",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_CategoryID",
                table: "Item",
                newName: "IX_Item_CategoryFk");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Categories_CategoryFk",
                table: "Item",
                column: "CategoryFk",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Categories_CategoryFk",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "CategoryFk",
                table: "Item",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Item",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Item_CategoryFk",
                table: "Item",
                newName: "IX_Item_CategoryID");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Categories_CategoryID",
                table: "Item",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
