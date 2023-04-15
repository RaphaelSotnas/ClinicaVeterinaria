
namespace ClinicaVeterinaria.MVC.Models.Entidades
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string? NomeCliente { get; set; }

        public string? CpfCliente { get; set; }

        public string? Email { get; set; }

        public DateTime DataCadastro { get; set; }

        public string? Senha { get; set; }
    }
}
