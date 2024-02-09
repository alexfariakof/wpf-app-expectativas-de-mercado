using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expectativas_de_Mercado.Migrations.Migrations
{
    public partial class AddPesquisaModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PesquisaId",
                table: "ExpectativasMercado",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pesquisa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndicadorId = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodoInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodoFinal = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pesquisa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pesquisa_Indicador_IndicadorId",
                        column: x => x.IndicadorId,
                        principalTable: "Indicador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpectativasMercado_PesquisaId",
                table: "ExpectativasMercado",
                column: "PesquisaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pesquisa_IndicadorId",
                table: "Pesquisa",
                column: "IndicadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpectativasMercado_Pesquisa_PesquisaId",
                table: "ExpectativasMercado",
                column: "PesquisaId",
                principalTable: "Pesquisa",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpectativasMercado_Pesquisa_PesquisaId",
                table: "ExpectativasMercado");

            migrationBuilder.DropTable(
                name: "Pesquisa");

            migrationBuilder.DropIndex(
                name: "IX_ExpectativasMercado_PesquisaId",
                table: "ExpectativasMercado");

            migrationBuilder.DropColumn(
                name: "PesquisaId",
                table: "ExpectativasMercado");
        }
    }
}
