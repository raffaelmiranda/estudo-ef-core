using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntidadesDesconectadas.Console.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.AlunoId);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                    table.ForeignKey(
                        name: "FK_Cursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.EnderecoId);
                    table.ForeignKey(
                        name: "FK_Enderecos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "Nome" },
                values: new object[,]
                {
                    { 1, "Maria" },
                    { 2, "Janice" },
                    { 3, "Jefferson" },
                    { 4, "Jessica" },
                    { 5, "Pedro" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "AlunoId", "Nome" },
                values: new object[,]
                {
                    { 1, 1, "Matematica" },
                    { 2, 4, "Moda" },
                    { 3, 2, "Web Design" },
                    { 4, 3, "Engenharia" },
                    { 5, 4, "Musica" }
                });

            migrationBuilder.InsertData(
                table: "Enderecos",
                columns: new[] { "EnderecoId", "AlunoId", "Cidade", "Pais" },
                values: new object[,]
                {
                    { 1, 4, "Goiânia", "Brasil" },
                    { 2, 2, "São Paulo", "Brasil" },
                    { 3, 1, "Santos", "Brasil" },
                    { 4, 3, "Toronto", "Canada" },
                    { 5, 5, "Lins", "Brasil" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_AlunoId",
                table: "Cursos",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_AlunoId",
                table: "Enderecos",
                column: "AlunoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Alunos");
        }
    }
}
