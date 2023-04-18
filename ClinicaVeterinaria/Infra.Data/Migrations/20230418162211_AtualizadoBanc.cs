using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaVeterinaria.API.Migrations
{
    public partial class AtualizadoBanc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "Atendimento",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnimalNome",
                table: "Atendimento",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_AnimalId",
                table: "Atendimento",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Animais_AnimalId",
                table: "Atendimento",
                column: "AnimalId",
                principalTable: "Animais",
                principalColumn: "AnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Animais_AnimalId",
                table: "Atendimento");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_AnimalId",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "AnimalNome",
                table: "Atendimento");
        }
    }
}
