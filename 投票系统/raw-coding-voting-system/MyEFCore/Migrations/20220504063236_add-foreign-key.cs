using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEFCore.Migrations
{
    public partial class addforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Fruits",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fruits_AddressId",
                table: "Fruits",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fruits_Addresses_AddressId",
                table: "Fruits",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fruits_Addresses_AddressId",
                table: "Fruits");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Fruits_AddressId",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Fruits");
        }
    }
}
