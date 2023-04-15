using ClinicaVeterinaria.API.Models;


namespace ClinicaVeterinaria.API.Repository.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<ClienteModel>> BuscarClientes();
        Task<ClienteModel> BuscarClientePorId(int idCliente);
        Task<ClienteModel> CadastrarCliente(ClienteModel cliente);
        Task<bool> DeletarCliente(int idCliente);
        Task<ClienteModel> AtualizarCliente(ClienteModel clienteAtualizado, int idCliente);
        Task<ClienteModel> VerificaExistenciaDoCliente(string? cpf);
    }
}
