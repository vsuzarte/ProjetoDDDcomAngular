using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UsuarioUsuarioUnico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_Usuario",
                table: "User",
                column: "Usuario",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Usuario",
                table: "User");
        }
    }
}
