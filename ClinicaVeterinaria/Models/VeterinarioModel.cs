using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.Models
{
    public class VeterinarioModel
    {
        public int VeterinarioId { get; set; }

        [Required]
        public string? NomeVeterinario { get; set; }

        [Required]
        public bool Geriatria { get; set; }

        public DateTime DataContratacao { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }
    }
}
