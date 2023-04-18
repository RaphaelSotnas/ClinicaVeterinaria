
using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaria.MVC.Models.Entidades
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string? NomeCliente { get; set; }

        [Required(ErrorMessage =("Digite seu CPF"))]
        public string? CpfCliente { get; set; }

        [EmailAddress(ErrorMessage = ("Informe o seu melhor e-mail"))]
        public string? Email { get; set; }

        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = ("Digite sua senha"))]
        public string? Senha { get; set; }

        public bool Admin { get; set; }
    }
}
