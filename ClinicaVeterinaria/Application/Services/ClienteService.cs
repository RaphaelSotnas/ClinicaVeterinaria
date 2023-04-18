using ClinicaVeterinaria.API.Domain.Interfaces.InterfacesRepository;
using ClinicaVeterinaria.API.Models;
using ClinicaVeterinaria.API.Repository.Interfaces.Interf.Services;

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
                clienteModel.DataCadastro = DateTime.Now;
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

        public async Task<bool> IsCpf(string cpfCliente)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            if ((cpfCliente[0] == cpfCliente[1]) &&
                (cpfCliente[1] == cpfCliente[2]) &&
                (cpfCliente[2] == cpfCliente[3]) &&
                (cpfCliente[3] == cpfCliente[4]) &&
                (cpfCliente[4] == cpfCliente[5]) &&
                (cpfCliente[5] == cpfCliente[6]) &&
                (cpfCliente[6] == cpfCliente[7]) &&
                (cpfCliente[7] == cpfCliente[8]) &&
                (cpfCliente[8] == cpfCliente[9]) &&
                (cpfCliente[9] == cpfCliente[10]))
                return false;
            cpfCliente = cpfCliente.Trim();
            cpfCliente = cpfCliente.Replace(".", "").Replace("-", "");
            if (cpfCliente.Length != 11)
                return false;
            tempCpf = cpfCliente.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpfCliente.EndsWith(digito);
        }
    }
}
