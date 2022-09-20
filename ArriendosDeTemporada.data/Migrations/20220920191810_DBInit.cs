using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ArriendosDeTemporada.data.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    idDepartamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ubicacionDepartamento = table.Column<string>(type: "varchar(40)", nullable: false),
                    tamañoDepartamento = table.Column<string>(type: "varchar(40)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(40)", nullable: false),
                    estadoLogico = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.idDepartamento);
                });

            migrationBuilder.CreateTable(
                name: "ServiciosExtra",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "varchar(40)", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(40)", nullable: false),
                    fechaContrato = table.Column<DateTime>(type: "date", nullable: false),
                    fechaUltimaRenovacion = table.Column<DateTime>(type: "date", nullable: true),
                    fechaExpiracion = table.Column<DateTime>(type: "date", nullable: false),
                    estadoLogico = table.Column<bool>(type: "boolean", nullable: false),
                    costoServicio = table.Column<int>(type: "int", nullable: false),
                    servicioUnitario = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UID = table.Column<string>(type: "varchar(40)", nullable: false),
                    Email = table.Column<string>(type: "varchar(40)", nullable: false),
                    Rol = table.Column<string>(type: "varchar(40)", nullable: false),
                    nombreUsuario = table.Column<string>(type: "varchar(40)", nullable: false),
                    fechaRegistroUsuario = table.Column<DateTime>(type: "date", nullable: false),
                    lastLogOn = table.Column<DateTime>(type: "timestamp", nullable: false),
                    estadoLogico = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Utilidades",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "varchar(40)", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(40)", nullable: true),
                    valor = table.Column<int>(type: "int", nullable: false),
                    departamentoidDepartamento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilidad", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Utilidades_Departamentos_departamentoidDepartamento",
                        column: x => x.departamentoidDepartamento,
                        principalTable: "Departamentos",
                        principalColumn: "idDepartamento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fechaHora = table.Column<DateTime>(type: "timestamp", nullable: false),
                    valorIVA = table.Column<int>(type: "int", nullable: false),
                    cantidadClientes = table.Column<int>(type: "integer", nullable: false),
                    usuarioID = table.Column<int>(type: "int", nullable: true),
                    departamentoidDepartamento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Facturas_Departamentos_departamentoidDepartamento",
                        column: x => x.departamentoidDepartamento,
                        principalTable: "Departamentos",
                        principalColumn: "idDepartamento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facturas_Usuarios_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServicioFactura",
                columns: table => new
                {
                    IDServicio = table.Column<int>(type: "int", nullable: false),
                    IDFactura = table.Column<int>(type: "int", nullable: false),
                    valorServicio = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioFactura", x => new { x.IDServicio, x.IDFactura });
                    table.ForeignKey(
                        name: "FK_ServicioFactura_Facturas_IDFactura",
                        column: x => x.IDFactura,
                        principalTable: "Facturas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicioFactura_ServiciosExtra_IDServicio",
                        column: x => x.IDServicio,
                        principalTable: "ServiciosExtra",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_departamentoidDepartamento",
                table: "Facturas",
                column: "departamentoidDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_usuarioID",
                table: "Facturas",
                column: "usuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioFactura_IDFactura",
                table: "ServicioFactura",
                column: "IDFactura");

            migrationBuilder.CreateIndex(
                name: "IX_Utilidades_departamentoidDepartamento",
                table: "Utilidades",
                column: "departamentoidDepartamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicioFactura");

            migrationBuilder.DropTable(
                name: "Utilidades");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "ServiciosExtra");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
