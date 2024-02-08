using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expectativas_de_Mercado.Migrations.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Indicador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpectativasMercado",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndicadorId1 = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    DataReferencia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Reuniao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Media = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Mediana = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DesvioPadrao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Minimo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Maximo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumeroRespondentes = table.Column<int>(type: "int", nullable: false),
                    BaseCalculo = table.Column<int>(type: "int", nullable: false),
                    IndicadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpectativasMercado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpectativasMercado_Indicador_IndicadorId",
                        column: x => x.IndicadorId,
                        principalTable: "Indicador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpectativasMercado_Indicador_IndicadorId1",
                        column: x => x.IndicadorId1,
                        principalTable: "Indicador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Indicador",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 1, "IPCA" });

            migrationBuilder.InsertData(
                table: "Indicador",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 2, "IGP-M" });

            migrationBuilder.InsertData(
                table: "Indicador",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 3, "Selic" });

            migrationBuilder.CreateIndex(
                name: "IX_ExpectativasMercado_IndicadorId",
                table: "ExpectativasMercado",
                column: "IndicadorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpectativasMercado_IndicadorId1",
                table: "ExpectativasMercado",
                column: "IndicadorId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpectativasMercado");

            migrationBuilder.DropTable(
                name: "Indicador");
        }
    }
}
