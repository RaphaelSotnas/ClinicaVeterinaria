using ClinicaVeterinaria.API.Models;
using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.API.Models
{
    public class ClienteModel
    {
        public int ClienteId { get; set; }

        public string? NomeCliente { get; set; }

        [Required]
        public string? CpfCliente { get; set; }
        
        public string? Email { get; set; }

        public DateTime DataCadastro { get; set; }

        [Required]
        public string? Senha { get; set; }

        public bool Admin { get; set; }
    }
}
