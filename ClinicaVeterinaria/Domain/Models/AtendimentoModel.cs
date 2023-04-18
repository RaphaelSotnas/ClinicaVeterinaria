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

        public string? VeterinarioNome { get; set; }

        public VeterinarioModel? Veterinario { get; set; }

        public int ClienteId { get; set; }

        public ClienteModel? Cliente { get; set; }

        public string? AnimalNome { get; set; }
        public AnimalModel? Animal { get; set; }
    }
}
