using ClinicaVeterinaria.API.Models;


namespace ClinicaVeterinaria.API.Domain.Interfaces.InterfacesRepository
{
    public interface IClienteRepository
    {
        Task<List<ClienteModel>> BuscarClientes();
        Task<ClienteModel> CadastrarCliente(ClienteModel cliente);
        Task<bool> DeletarCliente(string cpfCliente);
        Task<ClienteModel> AtualizarCliente(ClienteModel clienteAtualizado, string cpfCliente);
        Task<ClienteModel> VerificaExistenciaDoCliente(string? cpf);
        Task<ClienteModel> BuscarClientePorCpf(string cpf);
    }
}
