using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.Models
{
    public class AgendamentoModel
    {
        public int AgendamentoId { get; set; }

        [Required]
        public DateTime DataConsulta { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        public string? VeterinarioNome { get; set; }

        public VeterinarioModel? Veterinario { get; set; }
    }
}
