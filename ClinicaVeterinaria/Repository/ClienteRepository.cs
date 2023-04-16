using ClinicaVeterinaria.API.Data;
using ClinicaVeterinaria.API.Models;
using ClinicaVeterinaria.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClinicaVeterinariaDBContext _dbContext;
        public ClienteRepository(ClinicaVeterinariaDBContext clinicaVeterinariaDBContext)
        {
            _dbContext = clinicaVeterinariaDBContext;
        }

        public async Task<List<ClienteModel>> BuscarClientes()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        public async Task<ClienteModel> CadastrarCliente(ClienteModel cliente)
        {
            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<ClienteModel> AtualizarCliente(ClienteModel clienteAtualizado, string cpfCliente)
        {
            var clienteDoBanco = await BuscarClientePorCpf(cpfCliente);

            clienteDoBanco.CpfCliente = clienteAtualizado.CpfCliente;
            clienteDoBanco.DataCadastro = clienteAtualizado.DataCadastro;
            clienteDoBanco.ClienteId = clienteAtualizado.ClienteId;
            clienteDoBanco.NomeCliente = clienteAtualizado.NomeCliente;
            clienteDoBanco.Email = clienteAtualizado.Email;
            clienteDoBanco.Senha = clienteAtualizado.Senha;

            _dbContext.Clientes.Update(clienteDoBanco);
            await _dbContext.SaveChangesAsync();
            return clienteDoBanco;
        }

        public async Task<bool> DeletarCliente(string cpfCliente)
        {
            var clienteDoBanco = await BuscarClientePorCpf(cpfCliente);

            _dbContext.Clientes.Remove(clienteDoBanco);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ClienteModel> VerificaExistenciaDoCliente(string? cpf)
        {
            var retorno = await _dbContext.Clientes.FirstOrDefaultAsync(x => x.CpfCliente == cpf);
            return retorno;
        }

        public async Task<ClienteModel> BuscarClientePorCpf(string cpf)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.CpfCliente == cpf);
        }
    }
}
