using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntidadesRelacionadas.Console.Migrations
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
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Biografias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BiografiaAutor = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nacionalidade = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biografias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biografias_Autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AnoLancamento = table.Column<int>(type: "int", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false),
                    EditorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livros_Autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livros_Editores_EditorId",
                        column: x => x.EditorId,
                        principalTable: "Editores",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "Id", "Email", "Nome" },
                values: new object[,]
                {
                    { 1, "hermann@email.com", "Hermann Hesse " },
                    { 2, "agaha@email.com", "Agatha Christie" },
                    { 3, "coelho@email.com", "Paulo Coelho" },
                    { 4, "tolstoy@email.com", "Leon Tolstoy" },
                    { 5, "fernando@email.com", "Fernando Pessoa" }
                });

            migrationBuilder.InsertData(
                table: "Editores",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Amazon" },
                    { 2, "Americanas" },
                    { 3, "Saraiva" }
                });

            migrationBuilder.InsertData(
                table: "Biografias",
                columns: new[] { "Id", "AutorId", "BiografiaAutor", "DataNascimento", "Nacionalidade" },
                values: new object[,]
                {
                    { 1, 1, "Herman Hesse", new DateTime(1877, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alemanha" },
                    { 2, 2, "Agatha Christie", new DateTime(1890, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inglaterra" },
                    { 3, 3, "Paulo Coelho", new DateTime(1847, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brasil" },
                    { 4, 4, "Leon Tolstoy", new DateTime(1828, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Russia" },
                    { 5, 5, "Fernando Pessoa", new DateTime(1900, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Portugal" }
                });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "AnoLancamento", "AutorId", "EditorId", "Tipo", "Titulo" },
                values: new object[,]
                {
                    { 1, 1922, 1, 1, "Romance", "Sidarta" },
                    { 2, 1919, 1, 1, "Romance", "Demain" },
                    { 3, 1934, 2, 1, "Romance", "Assassinato no Oriente Express" },
                    { 4, 1968, 2, 1, "Romance", "O caso dos dez negrinhos" },
                    { 5, 1988, 3, 1, "Romance", "O Alquimista" },
                    { 6, 1977, 4, 2, "Romance", "Ana Karenina" },
                    { 7, 1967, 4, 2, "Romance", "Guerra e Paz" },
                    { 8, 1925, 5, 1, "Poesias", "O Guardador de rebanhos" },
                    { 9, 1930, 5, 3, "Poesias", "Poesias" },
                    { 10, 1939, 4, 3, "Ficção", "E não sobrou nenhum" },
                    { 11, 1927, 1, 3, "Romance", "O lobo da estepe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biografias_AutorId",
                table: "Biografias",
                column: "AutorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Livros_AutorId",
                table: "Livros",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_EditorId",
                table: "Livros",
                column: "EditorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biografias");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Editores");
        }
    }
}
