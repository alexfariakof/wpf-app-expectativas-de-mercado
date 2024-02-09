using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expectativas_de_Mercado.Migrations.Migrations
{
    public partial class hotfixPersistenciaFK_IndicadorModelExpectativasMercado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpectativasMercado_Indicador_IndicadorId",
                table: "ExpectativasMercado");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpectativasMercado_Pesquisa_PesquisaId",
                table: "ExpectativasMercado");

            migrationBuilder.AlterColumn<Guid>(
                name: "PesquisaId",
                table: "ExpectativasMercado",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IndicadorId",
                table: "ExpectativasMercado",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpectativasMercado_Indicador_IndicadorId",
                table: "ExpectativasMercado",
                column: "IndicadorId",
                principalTable: "Indicador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpectativasMercado_Pesquisa_PesquisaId",
                table: "ExpectativasMercado",
                column: "PesquisaId",
                principalTable: "Pesquisa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpectativasMercado_Indicador_IndicadorId",
                table: "ExpectativasMercado");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpectativasMercado_Pesquisa_PesquisaId",
                table: "ExpectativasMercado");

            migrationBuilder.AlterColumn<Guid>(
                name: "PesquisaId",
                table: "ExpectativasMercado",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "IndicadorId",
                table: "ExpectativasMercado",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpectativasMercado_Indicador_IndicadorId",
                table: "ExpectativasMercado",
                column: "IndicadorId",
                principalTable: "Indicador",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpectativasMercado_Pesquisa_PesquisaId",
                table: "ExpectativasMercado",
                column: "PesquisaId",
                principalTable: "Pesquisa",
                principalColumn: "Id");
        }
    }
}
