using Microsoft.EntityFrameworkCore.Migrations;

namespace SGE.App.Persistencia.Migrations
{
    public partial class Matricula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Usuarios_EstudianteId",
                table: "Notas");

            migrationBuilder.AddColumn<bool>(
                name: "Entro",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrupoId = table.Column<int>(type: "int", nullable: true),
                    EstudianteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matricula_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matricula_Usuarios_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_EstudianteId",
                table: "Matricula",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_GrupoId",
                table: "Matricula",
                column: "GrupoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Matricula_EstudianteId",
                table: "Notas",
                column: "EstudianteId",
                principalTable: "Matricula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Matricula_EstudianteId",
                table: "Notas");

            migrationBuilder.DropTable(
                name: "Matricula");

            migrationBuilder.DropColumn(
                name: "Entro",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Usuarios");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Usuarios_EstudianteId",
                table: "Notas",
                column: "EstudianteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
