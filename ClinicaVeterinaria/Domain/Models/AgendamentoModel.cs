using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.API.Models
{
    public class AgendamentoModel
    {
        public int AgendamentoId { get; set; }
        [Required]
        public DateTime DataConsulta { get; set; }
        [Required]
        public DateTime DataCadastro { get; set; }
        public bool VeterinarioGeriatrico { get; set; }
        public string? VeterinarioNome { get; set; }
        public int VeterinarioId { get; set; }
        public VeterinarioModel? Veterinario { get; set; }
        [Required]
        public bool Disponivel { get; set; }
        public int AnimalId { get; set; }
        public AnimalModel? Animal { get; set; }
    }
}
