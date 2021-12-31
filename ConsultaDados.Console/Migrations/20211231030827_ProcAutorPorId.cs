using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultaDados.Console.Migrations
{
    public partial class ProcAutorPorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[AutorPorId] @Id int
                    AS
                    BEGIN
                        select id, nome, email, pais from Autores where id= @id
                    END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE [dbo].[AutorPorId]";

            migrationBuilder.Sql(sp);
        }
    }
}
