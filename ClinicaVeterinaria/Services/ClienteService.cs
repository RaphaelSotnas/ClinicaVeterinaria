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

        public async Task<string> LogarCliente(ClienteModel clienteModel)
        {
            ResponseMessage mensagemRetorno = new ResponseMessage();

            var cliente = await _clienteRepository.BuscarClientePorCpf(clienteModel.CpfCliente);
            if (cliente == null)
                return mensagemRetorno.Mensagem = "Cliente inexistente";

            if (clienteModel.Senha != cliente.Senha)
                return mensagemRetorno.Mensagem = "Senha inválida";
                
            mensagemRetorno.Mensagem = $"{cliente.NomeCliente}";
            return mensagemRetorno.Mensagem;
        }

        public async Task<ClienteModel> BuscarClientePorCpf(string cpfCliente)
        {
            var clienteDoBanco = await _clienteRepository.BuscarClientePorCpf(cpfCliente);
            if (clienteDoBanco == null)
                return null;

            return clienteDoBanco;
        }
    }
}
