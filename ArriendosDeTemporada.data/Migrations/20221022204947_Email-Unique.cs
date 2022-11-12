using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArriendosDeTemporada.data.Migrations
{
    public partial class EmailUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<List<string>>(
                name: "fotografias",
                table: "Departamentos",
                type: "varchar(100)[]",
                nullable: true,
                oldClrType: typeof(List<string>),
                oldType: "varchar(100)[]");

            migrationBuilder.AddColumn<int>(
                name: "cantidadDormitorios",
                table: "Departamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaRegistroDepartamento",
                table: "Departamentos",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaUltimaMantencion",
                table: "Departamentos",
                type: "timestamp",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaUltimaReserva",
                table: "Departamentos",
                type: "timestamp",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "valorBase",
                table: "Departamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "cantidadDormitorios",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "fechaRegistroDepartamento",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "fechaUltimaMantencion",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "fechaUltimaReserva",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "valorBase",
                table: "Departamentos");

            migrationBuilder.AlterColumn<List<string>>(
                name: "fotografias",
                table: "Departamentos",
                type: "varchar(100)[]",
                nullable: false,
                oldClrType: typeof(List<string>),
                oldType: "varchar(100)[]",
                oldNullable: true);
        }
    }
}
