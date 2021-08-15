using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCPizza1.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TextoOrden = table.Column<string>(type: "TEXT", nullable: true),
                    TipoTamano = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoMasa = table.Column<int>(type: "INTEGER", nullable: false),
                    Ingredientes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordenes");
        }
    }
}
