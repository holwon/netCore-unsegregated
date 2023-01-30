using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEFCore.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Fruits",
                newName: "FruitName");

            migrationBuilder.AlterColumn<string>(
                name: "FruitName",
                table: "Fruits",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FruitName",
                table: "Fruits",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Fruits",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);
        }
    }
}
