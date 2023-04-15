
using ClinicaVeterinaria.MVC.Models.Entidades;

namespace ClinicaVeterinaria.Web.Helpers
{
    public interface ISessao
    {
        void CriarSessaoCliente(Cliente Cliente);

        void RemoverSessaoCliente(Cliente Cliente);

        Cliente BuscarSessaoCliente();
    }
}
