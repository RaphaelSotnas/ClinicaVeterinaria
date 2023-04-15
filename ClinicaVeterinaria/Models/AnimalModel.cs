
using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.API.Models
{
    public class AnimalModel
    {
        public int AnimalId { get; set; }

        [Required]
        public string? NomeAnimal { get; set; }

        [Required]
        public int IdadeAnimal { get; set; }

        [Required]
        public string? CategoriaAnimal { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        [Required]
        public bool Geriatria { get; set; }

        public int? ClienteId { get; set; }

        public ClienteModel? Cliente { get; set; }
    }
}
