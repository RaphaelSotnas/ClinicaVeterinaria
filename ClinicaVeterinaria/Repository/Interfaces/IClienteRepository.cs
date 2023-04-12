using ClinicaVeterinaria.Models;

namespace ClinicaVeterinaria.Repository.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<ClienteModel>> BuscarClientes();
        Task<ClienteModel> BuscarClientePorId(int idCliente);
        Task<ClienteModel> CadastrarCliente(ClienteModel cliente);
        Task<bool> DeletarCliente(int idCliente);
        Task<ClienteModel> AtualizarCliente(ClienteModel clienteAtualizado, int idCliente);
    }
}
