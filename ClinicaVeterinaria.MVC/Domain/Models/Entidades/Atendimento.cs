using ClinicaVeterinaria.MVC.Models.Entidades;
using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.Web.Models.Entidades
{
    public class Atendimento
    {
        public int AtendimentoId { get; set; }

        [Required(ErrorMessage = ("Diagnóstico do animal"))]
        public string? Diagnostico { get; set; }

        [Required(ErrorMessage = ("Qual foi a data do atendimento?"))]
        public DateTime DataAtendimento { get; set; }

        [Required(ErrorMessage = ("Dia em que foi marcado"))]
        public DateTime DataCadastro { get; set; }

        public int? VeterinarioId { get; set; }
        public string? VeterinarioNome { get; set; }

        public Veterinario? Veterinario { get; set; }

        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        public string? AnimalNome { get; set; }
        public Animal? Animal { get; set; }
    }
}
