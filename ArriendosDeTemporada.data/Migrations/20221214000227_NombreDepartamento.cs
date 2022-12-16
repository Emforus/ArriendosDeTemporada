using Microsoft.EntityFrameworkCore.Migrations;

namespace ArriendosDeTemporada.data.Migrations
{
    public partial class NombreDepartamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nombreDepartamento",
                table: "Departamentos",
                type: "varchar(40)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nombreDepartamento",
                table: "Departamentos");
        }
    }
}
