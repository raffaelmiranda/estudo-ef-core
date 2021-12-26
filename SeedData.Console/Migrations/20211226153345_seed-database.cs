using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeedData.Console.Migrations
{
    public partial class seeddatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into animais (nome, idade, datacadastro) values ('animal 01', 3, getdate())");
            migrationBuilder.Sql("insert into animais (nome, idade, datacadastro) values ('animal 02', 6, getdate())");
            migrationBuilder.Sql("insert into animais (nome, idade, datacadastro) values ('animal 03', 9, getdate())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
