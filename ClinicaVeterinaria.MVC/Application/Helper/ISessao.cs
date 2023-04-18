using ClinicaVeterinaria.MVC.Models.Entidades;

namespace ClinicaVeterinaria.Web.Helper
{
    public interface ISessao
    {
        void CriarSessaoCliente(Cliente cliente);
        void RemoverSessaoUsuario();
        Cliente BuscarSessaoCliente();
    }
}
