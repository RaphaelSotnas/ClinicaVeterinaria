using ClinicaVeterinaria.API.Models;

namespace ClinicaVeterinaria.API.Repository.Interfaces
{
    public interface IClienteService
    {
        public Task<bool> CadastrarCliente(ClienteModel clienteModel);
    }
}
