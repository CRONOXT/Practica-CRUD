using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practica_CRUD.Migrations
{
    public partial class CuartaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "RolUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RolUser",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
