using ClinicaVeterinaria.Web.Enum;
using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.Web.Models.Entidades
{
    public class Animal
    {
        public int AnimalId { get; set; }

        [Required(ErrorMessage = ("Digite o nome do seu PET"))]
        public string? NomeAnimal { get; set; }

        [Required(ErrorMessage = ("Qual a idade dele/a ?"))]
        public int IdadeAnimal { get; set; }

        public CategoriaAnimal CategoriaAnimal { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Geriatria { get; set; }
    }
}
