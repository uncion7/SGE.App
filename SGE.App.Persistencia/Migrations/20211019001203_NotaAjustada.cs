using Microsoft.EntityFrameworkCore.Migrations;

namespace SGE.App.Persistencia.Migrations
{
    public partial class NotaAjustada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Calificaciones_CalificacionId",
                table: "Notas");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Notas",
                newName: "NotaDef");

            migrationBuilder.RenameColumn(
                name: "CalificacionId",
                table: "Notas",
                newName: "GrupoId");

            migrationBuilder.RenameIndex(
                name: "IX_Notas_CalificacionId",
                table: "Notas",
                newName: "IX_Notas_GrupoId");

            migrationBuilder.AddColumn<float>(
                name: "Nota1",
                table: "Notas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Nota2",
                table: "Notas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Nota3",
                table: "Notas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Nota4",
                table: "Notas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Nota5",
                table: "Notas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Grupos_GrupoId",
                table: "Notas",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Grupos_GrupoId",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "Nota1",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "Nota2",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "Nota3",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "Nota4",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "Nota5",
                table: "Notas");

            migrationBuilder.RenameColumn(
                name: "NotaDef",
                table: "Notas",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "GrupoId",
                table: "Notas",
                newName: "CalificacionId");

            migrationBuilder.RenameIndex(
                name: "IX_Notas_GrupoId",
                table: "Notas",
                newName: "IX_Notas_CalificacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Calificaciones_CalificacionId",
                table: "Notas",
                column: "CalificacionId",
                principalTable: "Calificaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
