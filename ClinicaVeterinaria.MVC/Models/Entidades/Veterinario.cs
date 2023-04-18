using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.Web.Models.Entidades
{
    public class Veterinario
    {
        public int VeterinarioId { get; set; }

        [Required(ErrorMessage = ("Digite o nome do veterinário"))]
        public string? NomeVeterinario { get; set; }

        [Required(ErrorMessage = ("Este profissional é especialista?"))]
        public bool Geriatria { get; set; }

        public DateTime DataContratacao { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
