using ClinicaVeterinaria.Data;
using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Repository.Interfaces;
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

        public async Task<ClienteModel> BuscarClientePorId(int idCliente)
        {
            var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(x => x.ClienteId == idCliente);
            if(cliente == null)
                throw new Exception($"O Cliente para o ID informado: {idCliente} não existe no banco de dados.");

            return cliente;
        }

        public async Task<ClienteModel> CadastrarCliente(ClienteModel cliente)
        {
            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<ClienteModel> AtualizarCliente(ClienteModel clienteAtualizado, int idCliente)
        {
            var clienteDoBanco = await BuscarClientePorId(idCliente);

            clienteDoBanco.CpfCliente = clienteAtualizado.CpfCliente;
            clienteDoBanco.DataCadastro = clienteAtualizado.DataCadastro;
            clienteDoBanco.ClienteId = clienteAtualizado.ClienteId;
            clienteDoBanco.NomeCliente = clienteAtualizado.NomeCliente;

            _dbContext.Clientes.Update(clienteDoBanco);
            await _dbContext.SaveChangesAsync();
            return clienteDoBanco;
        }

        public async Task<bool> DeletarCliente(int idCliente)
        {
            var clienteDoBanco = await BuscarClientePorId(idCliente);

            _dbContext.Clientes.Remove(clienteDoBanco);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
