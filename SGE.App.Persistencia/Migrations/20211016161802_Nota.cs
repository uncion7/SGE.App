using Microsoft.EntityFrameworkCore.Migrations;

namespace SGE.App.Persistencia.Migrations
{
    public partial class Nota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Matricula_EstudianteId",
                table: "Notas");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Usuarios_EstudianteId",
                table: "Notas",
                column: "EstudianteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Usuarios_EstudianteId",
                table: "Notas");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Matricula_EstudianteId",
                table: "Notas",
                column: "EstudianteId",
                principalTable: "Matricula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
