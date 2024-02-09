using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expectativas_de_Mercado.Migrations.Migrations
{
    public partial class RemovendoRequiredModelMappnigExpectativasMercado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pesquisa_Indicador_IndicadorId",
                table: "Pesquisa");

            migrationBuilder.AlterColumn<int>(
                name: "IndicadorId",
                table: "Pesquisa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pesquisa_Indicador_IndicadorId",
                table: "Pesquisa",
                column: "IndicadorId",
                principalTable: "Indicador",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pesquisa_Indicador_IndicadorId",
                table: "Pesquisa");

            migrationBuilder.AlterColumn<int>(
                name: "IndicadorId",
                table: "Pesquisa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pesquisa_Indicador_IndicadorId",
                table: "Pesquisa",
                column: "IndicadorId",
                principalTable: "Indicador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
