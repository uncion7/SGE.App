using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGE.App.Persistencia.Migrations
{
    public partial class HorarioTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Ciclo_CicloId",
                table: "Grupos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Rol_RolId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol",
                table: "Rol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ciclo",
                table: "Ciclo");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Ciclo",
                newName: "Ciclos");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HoraInicial",
                table: "Horarios",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HoraFinal",
                table: "Horarios",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ciclos",
                table: "Ciclos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_Ciclos_CicloId",
                table: "Grupos",
                column: "CicloId",
                principalTable: "Ciclos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Ciclos_CicloId",
                table: "Grupos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ciclos",
                table: "Ciclos");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Rol");

            migrationBuilder.RenameTable(
                name: "Ciclos",
                newName: "Ciclo");

            migrationBuilder.AlterColumn<string>(
                name: "HoraInicial",
                table: "Horarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<string>(
                name: "HoraFinal",
                table: "Horarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ciclo",
                table: "Ciclo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_Ciclo_CicloId",
                table: "Grupos",
                column: "CicloId",
                principalTable: "Ciclo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Rol_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
