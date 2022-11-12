using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ArriendosDeTemporada.data.Migrations
{
    public partial class Include_GenericServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "ServiciosGenericos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idDepartamento = table.Column<int>(type: "int", nullable: false),
                    HasWifi = table.Column<bool>(type: "boolean", nullable: false),
                    AllowsPets = table.Column<bool>(type: "boolean", nullable: false),
                    HasAC = table.Column<bool>(type: "boolean", nullable: false),
                    HasElevator = table.Column<bool>(type: "boolean", nullable: false),
                    HasParking = table.Column<bool>(type: "boolean", nullable: false),
                    IsWheelchairAccessible = table.Column<bool>(type: "boolean", nullable: false),
                    HasPool = table.Column<bool>(type: "boolean", nullable: false),
                    AllowsChildren = table.Column<bool>(type: "boolean", nullable: false),
                    OtherServices = table.Column<List<string>>(type: "varchar(100)[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serv_Generico", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServiciosGenericos_Departamentos_idDepartamento",
                        column: x => x.idDepartamento,
                        principalTable: "Departamentos",
                        principalColumn: "idDepartamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosGenericos_idDepartamento",
                table: "ServiciosGenericos",
                column: "idDepartamento",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiciosGenericos");

            migrationBuilder.AlterColumn<string>(
                name: "tamañoDepartamento",
                table: "Departamentos",
                type: "varchar(40)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
