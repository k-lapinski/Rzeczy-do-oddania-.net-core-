using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rzeczy_do_oddaniaNEW.Data.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.AddColumn<string>(
                name: "Reservation",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reservation",
                table: "Item");

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    UsersID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => new { x.ItemId, x.UsersID });
                    table.ForeignKey(
                        name: "FK_Reservation_AspNetUsers_UsersID",
                        column: x => x.UsersID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UsersID",
                table: "Reservation",
                column: "UsersID");
        }
    }
}
