using Microsoft.EntityFrameworkCore.Migrations;

namespace Bandas_Tarea.Data.Migrations
{
    public partial class CreacionControlador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bandas",
                columns: table => new
                {
                    BandaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BandaNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BandaGenero = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bandas", x => x.BandaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bandas");
        }
    }
}
