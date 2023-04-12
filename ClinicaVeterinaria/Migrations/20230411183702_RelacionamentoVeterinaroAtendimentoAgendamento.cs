using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaVeterinaria.Migrations
{
    public partial class RelacionamentoVeterinaroAtendimentoAgendamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VeterinarioId",
                table: "Atendimento",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VeterinarioId",
                table: "Agendamento",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VeterinarioNome",
                table: "Agendamento",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_VeterinarioId",
                table: "Atendimento",
                column: "VeterinarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_VeterinarioId",
                table: "Agendamento",
                column: "VeterinarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Veterinarios_VeterinarioId",
                table: "Agendamento",
                column: "VeterinarioId",
                principalTable: "Veterinarios",
                principalColumn: "VeterinarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Veterinarios_VeterinarioId",
                table: "Atendimento",
                column: "VeterinarioId",
                principalTable: "Veterinarios",
                principalColumn: "VeterinarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Veterinarios_VeterinarioId",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Veterinarios_VeterinarioId",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_VeterinarioId",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_VeterinarioId",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "VeterinarioId",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "VeterinarioId",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "VeterinarioNome",
                table: "Agendamento");
        }
    }
}
