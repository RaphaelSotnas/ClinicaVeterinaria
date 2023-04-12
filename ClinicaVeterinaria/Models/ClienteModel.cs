using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.Models
{
    public class ClienteModel
    {
        public int ClienteId { get; set; }

        [Required]
        public string? NomeCliente { get; set; }

        [Required]
        public string? CpfCliente { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }
    } 
}
