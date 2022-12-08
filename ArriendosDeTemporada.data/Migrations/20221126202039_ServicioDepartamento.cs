using Microsoft.EntityFrameworkCore.Migrations;

namespace ArriendosDeTemporada.data.Migrations
{
    public partial class ServicioDepartamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServicioDepartamento",
                columns: table => new
                {
                    IDServicio = table.Column<int>(type: "int", nullable: false),
                    IDDepartamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioDepartamento", x => new { x.IDServicio, x.IDDepartamento });
                    table.ForeignKey(
                        name: "FK_ServicioDepartamento_Departamentos_IDDepartamento",
                        column: x => x.IDDepartamento,
                        principalTable: "Departamentos",
                        principalColumn: "idDepartamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicioDepartamento_ServiciosExtra_IDServicio",
                        column: x => x.IDServicio,
                        principalTable: "ServiciosExtra",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicioDepartamento_IDDepartamento",
                table: "ServicioDepartamento",
                column: "IDDepartamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicioDepartamento");
        }
    }
}
