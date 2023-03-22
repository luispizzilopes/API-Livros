using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiLivros.Migrations
{
    /// <inheritdoc />
    public partial class atualizacaomodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "DataLancamento",
                table: "ListaDesejos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Livros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataLancamento",
                table: "ListaDesejos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
