using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaVeterinaria.API.Migrations
{
    public partial class AtualizandoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CategoriaAnimal",
                table: "Animais",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CategoriaAnimal",
                table: "Animais",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
