using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChangeTracker.Console.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estoque = table.Column<int>(type: "int", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Categoria", "Estoque", "Nome" },
                values: new object[] { 1, "Material Escolar", 10, "Caneta" });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Categoria", "Estoque", "Nome" },
                values: new object[] { 2, "Material Escolar", 15, "Borracha" });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Categoria", "Estoque", "Nome" },
                values: new object[] { 3, "Material Escolar", 20, "Estojo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
