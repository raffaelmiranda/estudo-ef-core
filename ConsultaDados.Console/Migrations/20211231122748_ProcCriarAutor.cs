using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultaDados.Console.Migrations
{
    public partial class ProcCriarAutor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var sp = @"CREATE PROCEDURE [dbo].[CriarAutor] 
                    @nome varchar(100),
                    @email varchar(100),
                    @pais varchar(100)
                    AS
                    BEGIN
                        insert into autores(nome, email, pais) values (@nome, @email, @pais)
                    END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE [dbo].[CriarAutor]";

            migrationBuilder.Sql(sp);
        }
    }
}
