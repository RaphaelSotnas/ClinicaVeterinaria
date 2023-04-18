using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaVeterinaria.API.Migrations
{
    public partial class Atualizando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Clientes_ClienteId",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Atendimento");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Atendimento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Clientes_ClienteId",
                table: "Atendimento",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Clientes_ClienteId",
                table: "Atendimento");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Atendimento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Atendimento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Clientes_ClienteId",
                table: "Atendimento",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId");
        }
    }
}
