using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ArriendosDeTemporada.data.Migrations
{
    public partial class UpdateUtils : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Utilidades",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MultaID",
                table: "Utilidades",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cantidad",
                table: "Utilidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "estado",
                table: "Utilidades",
                type: "varchar(40)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Multa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    valor = table.Column<int>(type: "integer", nullable: false),
                    IDFactura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Multa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Multa_Facturas_IDFactura",
                        column: x => x.IDFactura,
                        principalTable: "Facturas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Utilidades_MultaID",
                table: "Utilidades",
                column: "MultaID");

            migrationBuilder.CreateIndex(
                name: "IX_Multa_IDFactura",
                table: "Multa",
                column: "IDFactura",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Utilidades_Multa_MultaID",
                table: "Utilidades",
                column: "MultaID",
                principalTable: "Multa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilidades_Multa_MultaID",
                table: "Utilidades");

            migrationBuilder.DropTable(
                name: "Multa");

            migrationBuilder.DropIndex(
                name: "IX_Utilidades_MultaID",
                table: "Utilidades");

            migrationBuilder.DropColumn(
                name: "MultaID",
                table: "Utilidades");

            migrationBuilder.DropColumn(
                name: "cantidad",
                table: "Utilidades");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "Utilidades");

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Utilidades",
                type: "varchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);
        }
    }
}
