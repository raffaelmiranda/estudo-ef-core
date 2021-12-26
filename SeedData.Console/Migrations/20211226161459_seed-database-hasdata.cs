using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeedData.Console.Migrations
{
    public partial class seeddatabasehasdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Animais",
                columns: new[] { "Id", "DataCadastro", "Idade", "Nome" },
                values: new object[] { 4, new DateTime(2021, 12, 26, 13, 14, 58, 989, DateTimeKind.Local).AddTicks(6372), 4, "animal 04" });

            migrationBuilder.InsertData(
                table: "Animais",
                columns: new[] { "Id", "DataCadastro", "Idade", "Nome" },
                values: new object[] { 5, new DateTime(2021, 12, 26, 13, 14, 58, 989, DateTimeKind.Local).AddTicks(6382), 9, "animal 05" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animais",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Animais",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
