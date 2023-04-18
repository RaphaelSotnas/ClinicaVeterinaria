using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.Web.Models.Entidades
{
    public class Agendamento
    {
        public int AgendamentoId { get; set; }
        [Required(ErrorMessage = ("Qual o dia da Consulta?"))]
        public DateTime DataConsulta { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool VeterinarioGeriatrico { get; set; }
        public string? VeterinarioNome { get; set; }
        public int VeterinarioId { get; set; }
        public Veterinario? Veterinario { get; set; }
        [Required(ErrorMessage = ("Esse dia está disponível?"))]
        public bool Disponivel { get; set; }
        public int AnimalId { get; set; }
        public Animal? Animal { get; set; }
    }
}
