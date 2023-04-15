using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.API.Models
{
    public class AtendimentoModel
    {
        public int AtendimentoId { get; set; }

        [Required]
        public string? Diagnostico { get; set; }

        [Required]
        public DateTime DataAtendimento { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        public int? VeterinarioId { get; set; }

        public VeterinarioModel? Veterinario { get; set; }
    }
}
