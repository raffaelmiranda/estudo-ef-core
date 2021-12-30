using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultaDados.Console.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    LivroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AnoLancamento = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.LivroId);
                    table.ForeignKey(
                        name: "FK_Livros_Autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "Id", "Email", "Nome", "Pais" },
                values: new object[,]
                {
                    { 1, "agaha@email.com", "Agatha Christie", "Inglaterra" },
                    { 2, "hermann@email.com", "Hermann Hesse ", "Alemanha" },
                    { 3, "tolstoy@email.com", "Leon Tolstoy", "Russia" },
                    { 4, "coelho@email.com", "Paulo Coelho", "Brasil" },
                    { 5, "lewis@email.com", "C.S.Lewis", "Inglaterra" },
                    { 6, "stephen@email.com", "Stephen King", "USA" },
                    { 7, "lewis@email.com", "Lewis Carrol", "Irlanda" },
                    { 8, "ian@email.com", "Ian Fleming", "Inglaterra" },
                    { 9, "masashi@email.com", "Masashi Kshimoto", "Japão" },
                    { 10, "tolkien@email.com", "J R. R. Tolkien", "Inglaterra" },
                    { 11, "dan@email.com", "Dan Brown", "USA" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Categoria", "Estoque", "Nome" },
                values: new object[,]
                {
                    { 1, "Material Escolar", 10, "Caneta" },
                    { 2, "Material Escolar", 15, "Borracha" },
                    { 3, "Material Escolar", 20, "Estojo" }
                });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "LivroId", "AnoLancamento", "AutorId", "Preco", "Tipo", "Titulo", "Url" },
                values: new object[,]
                {
                    { 1, 1934, 1, 35.4m, "Misterio", "Assasinato no Oriente Express", "http://www.livro.agathachristie.com" },
                    { 2, 1941, 1, 25.2m, "Ficção", "Os cincos porquinhos", "http://www.livro.agathachristie.com" },
                    { 3, 1922, 2, 12.5m, "Romance", "Sidarta", "http://www.livro.hemanhese.com" },
                    { 4, 1919, 2, 20.0m, "Ficção", "Demian", "http://www.livro.hemanhese.com" },
                    { 5, 1927, 2, 15.8m, "Romance", "O Lobo da estepe", "http://www.livro.hemanhese.com" },
                    { 6, 1867, 3, 35.2m, "Romance", "Guerra e Paz", "http://www.livro.leontolstoy.com" },
                    { 7, 1877, 3, 18.9m, "Romance", "Anna Karenina", "http://www.livro.leontolstoy.com" },
                    { 8, 1988, 4, 30.25m, "Ficção", "O Alquimista", "http://www.livro.paulocoelho.com" },
                    { 9, 1987, 4, 16.8m, "Ficção", "O diário de um mago", "http://www.livro.paulocoelho.com" },
                    { 10, 2001, 4, 17.0m, "Ficção", "Onze Minutos", "http://www.livro.paulocoelho.com" },
                    { 11, 1960, 5, 18.45m, "Filosofia", "Os quatro amores", "http://www.livro.cslewis.com" },
                    { 12, 1961, 5, 19.2m, "Filosofia", "A anatomia de uma dor", "http://www.livro.cslewis.com" },
                    { 13, 1974, 6, 12.5m, "Terror", "Carrie", "http://www.livro.stephen.com" },
                    { 14, 1865, 7, 13.9m, "Fantasia", "Alice no pais das maravilhas", "http://www.livro.carrol.com" },
                    { 15, 1953, 8, 20.25m, "Romance", "Cassino Royale", "http://www.livro.ian.com" },
                    { 16, 2000, 9, 10m, "Fantasia", "Naruto", "http://www.livro.naruto.com" },
                    { 17, 1937, 10, 25.25m, "Ficção", "O Hobit", "http://www.livro.hobbit.com" },
                    { 18, 1954, 10, 40.5m, "Fantasia", "O senhor dos anéis", "http://www.livro.aneis.com" },
                    { 19, 2017, 11, 12.6m, "Ficção", "Origem", "http://www.livro.dan.com" },
                    { 20, 2009, 11, 11.4m, "Ficção", "O Simbolo perdido", "http://www.livro.dan.com" },
                    { 21, 2003, 11, 30.8m, "Ficção", "O Código da Vinci", "http://www.livro.dan.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livros_AutorId",
                table: "Livros",
                column: "AutorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Autores");
        }
    }
}
