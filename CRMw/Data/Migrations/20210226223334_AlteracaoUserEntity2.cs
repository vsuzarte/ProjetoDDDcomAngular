using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AlteracaoUserEntity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_VisualCode",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "VisualCode",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "CodigoVisual",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deletado",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Desativado",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "User",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "User",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "User",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_User_CodigoVisual",
                table: "User",
                column: "CodigoVisual",
                unique: true,
                filter: "[CodigoVisual] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_CodigoVisual",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CodigoVisual",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Deletado",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Desativado",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "User");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatAt",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "User",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VisualCode",
                table: "User",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_VisualCode",
                table: "User",
                column: "VisualCode",
                unique: true,
                filter: "[VisualCode] IS NOT NULL");
        }
    }
}
