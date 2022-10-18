using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practica_CRUD.Migrations
{
    public partial class SegundaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolUser_Rol_RolsId",
                table: "RolUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolUser",
                table: "RolUser");

            migrationBuilder.DropIndex(
                name: "IX_RolUser_UserId",
                table: "RolUser");

            migrationBuilder.RenameColumn(
                name: "RolsId",
                table: "RolUser",
                newName: "RolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolUser",
                table: "RolUser",
                columns: new[] { "UserId", "RolId" });

            migrationBuilder.CreateIndex(
                name: "IX_RolUser_RolId",
                table: "RolUser",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolUser_Rol_RolId",
                table: "RolUser",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolUser_Rol_RolId",
                table: "RolUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolUser",
                table: "RolUser");

            migrationBuilder.DropIndex(
                name: "IX_RolUser_RolId",
                table: "RolUser");

            migrationBuilder.RenameColumn(
                name: "RolId",
                table: "RolUser",
                newName: "RolsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolUser",
                table: "RolUser",
                columns: new[] { "RolsId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_RolUser_UserId",
                table: "RolUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolUser_Rol_RolsId",
                table: "RolUser",
                column: "RolsId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
