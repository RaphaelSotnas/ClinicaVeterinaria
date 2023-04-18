using ClinicaVeterinaria.API.Models;

namespace ClinicaVeterinaria.API.Repository.Interfaces.Interf.Services
{
    public interface IClienteService
    {
        public Task<bool> CadastrarCliente(ClienteModel clienteModel);

        public Task<string> LogarCliente(ClienteModel clienteModel);

        public Task<ClienteModel> BuscarClientePorCpf(string cpfCliente);

        public Task<bool> IsCpf(string cpfCliente);
    }
}
