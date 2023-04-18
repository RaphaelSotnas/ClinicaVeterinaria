using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaVeterinaria.API.Migrations
{
    public partial class AdicionandoAnimalId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Animais_AnimalId",
                table: "Agendamento");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "Agendamento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Animais_AnimalId",
                table: "Agendamento",
                column: "AnimalId",
                principalTable: "Animais",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Animais_AnimalId",
                table: "Agendamento");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "Agendamento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Animais_AnimalId",
                table: "Agendamento",
                column: "AnimalId",
                principalTable: "Animais",
                principalColumn: "AnimalId");
        }
    }
}
