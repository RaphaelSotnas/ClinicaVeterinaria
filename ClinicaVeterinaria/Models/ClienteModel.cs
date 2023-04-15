using ClinicaVeterinaria.API.Models;
using ClinicaVeterinaria.Web.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.API.Models
{
    public class ClienteModel
    {
        public int ClienteId { get; set; }

        [Required]
        public string? NomeCliente { get; set; }

        [Required]
        public string? CpfCliente { get; set; }
        
        [Required]
        public string? Email { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        public string? Senha { get; set; }
    }
}
