using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaVeterinaria.API.Migrations
{
    public partial class Agendamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiposDeAnimais");

            migrationBuilder.DropColumn(
                name: "AnimalNome",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "VeterinarioGeriatria",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "VeterinarioNome",
                table: "Agendamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnimalNome",
                table: "Agendamento",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "VeterinarioGeriatria",
                table: "Agendamento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "VeterinarioNome",
                table: "Agendamento",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TiposDeAnimais",
                columns: table => new
                {
                    TipoAnimalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaAnimal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDeAnimais", x => x.TipoAnimalId);
                });
        }
    }
}
