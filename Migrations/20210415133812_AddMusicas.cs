using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoEstudoMVC.Migrations
{
    public partial class AddMusicas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musica_AspNetUsers_ArtistaId",
                table: "Musica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Musica",
                table: "Musica");

            migrationBuilder.RenameTable(
                name: "Musica",
                newName: "Musicas");

            migrationBuilder.RenameIndex(
                name: "IX_Musica_ArtistaId",
                table: "Musicas",
                newName: "IX_Musicas_ArtistaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Musicas",
                table: "Musicas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musicas_AspNetUsers_ArtistaId",
                table: "Musicas",
                column: "ArtistaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musicas_AspNetUsers_ArtistaId",
                table: "Musicas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Musicas",
                table: "Musicas");

            migrationBuilder.RenameTable(
                name: "Musicas",
                newName: "Musica");

            migrationBuilder.RenameIndex(
                name: "IX_Musicas_ArtistaId",
                table: "Musica",
                newName: "IX_Musica_ArtistaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Musica",
                table: "Musica",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musica_AspNetUsers_ArtistaId",
                table: "Musica",
                column: "ArtistaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
