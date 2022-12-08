using Microsoft.EntityFrameworkCore.Migrations;

namespace ArriendosDeTemporada.data.Migrations
{
    public partial class BreakdownValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "valor",
                table: "Facturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "valorDeposito",
                table: "Facturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "valorServicios",
                table: "Facturas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "valor",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "valorDeposito",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "valorServicios",
                table: "Facturas");
        }
    }
}
