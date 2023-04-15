using ClinicaVeterinaria.API.Models;
using ClinicaVeterinaria.API.Repository.Interfaces;

namespace ClinicaVeterinaria.API.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        private async Task<bool> VerificaClienteJaCadastrado(ClienteModel cliente)
        {
            var clienteDoBanco = await _clienteRepository.VerificaExistenciaDoCliente(cliente.CpfCliente);
            if (clienteDoBanco == null)
                return false;

            return true;
        }

        public async Task<bool> CadastrarCliente(ClienteModel clienteModel)
        {
            var clienteDoBanco = await VerificaClienteJaCadastrado(clienteModel);
            if (clienteDoBanco == false)
            {
                await _clienteRepository.CadastrarCliente(clienteModel);
                return true;
            }
            return false;
        }
    }
}
