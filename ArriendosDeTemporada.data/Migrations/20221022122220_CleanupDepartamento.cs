using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArriendosDeTemporada.data.Migrations
{
    public partial class CleanupDepartamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fechaHora",
                table: "Facturas",
                newName: "fechaHoraGeneracion");

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaHoraCheckIn",
                table: "Facturas",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaHoraCheckOut",
                table: "Facturas",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "descripcionDepartamento",
                table: "Departamentos",
                type: "varchar(40)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<List<string>>(
                name: "fotografias",
                table: "Departamentos",
                type: "varchar(100)[]",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "regionDepartamento",
                table: "Departamentos",
                type: "varchar(40)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fechaHoraCheckIn",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "fechaHoraCheckOut",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "descripcionDepartamento",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "fotografias",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "regionDepartamento",
                table: "Departamentos");

            migrationBuilder.RenameColumn(
                name: "fechaHoraGeneracion",
                table: "Facturas",
                newName: "fechaHora");
        }
    }
}
