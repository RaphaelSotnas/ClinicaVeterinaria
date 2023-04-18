using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaVeterinaria.API.Migrations
{
    public partial class AtualizandoTabelaAtendiento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Atendimento",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Atendimento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_ClienteId",
                table: "Atendimento",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Clientes_ClienteId",
                table: "Atendimento",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Clientes_ClienteId",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_ClienteId",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Atendimento");
        }
    }
}
