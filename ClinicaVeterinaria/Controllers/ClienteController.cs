using ClinicaVeterinaria.API;
using ClinicaVeterinaria.API.Models;
using ClinicaVeterinaria.API.Repository.Interfaces;
using ClinicaVeterinaria.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [Route("logar")]
        [HttpPost]
        public async Task<ActionResult> Logar([FromBody] ClienteModel clienteModel)
        {
            string retorno = await _clienteService.LogarCliente(clienteModel);

            if (retorno == "Cliente inexistente" || retorno == "Senha inválida")
                return BadRequest(new ResponseMessage { Mensagem = retorno });

            return Ok(new ResponseMessage { Mensagem = retorno });
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarCliente([FromBody] ClienteModel clienteModel)
        {
            var retorno = await _clienteService.CadastrarCliente(clienteModel);
            if (retorno == true)
                return Ok();

            return BadRequest(new ResponseMessage { Mensagem = "Cliente já cadastrado no banco de dados." });
        }

        [HttpGet("{cpfCliente}")]
        public async Task<ActionResult<List<ClienteModel>>> BuscarClientePorCpf(string cpfCliente)
        {
            ClienteModel cliente = await _clienteService.BuscarClientePorCpf(cpfCliente);
            return Ok(cliente);
        }


        //[HttpGet]
        //public async Task<ActionResult<List<ClienteModel>>> BuscarClientes()
        //{
        //    List<ClienteModel> clientes = await _clienteRepository.BuscarClientes();
        //    return Ok(clientes);
        //}



        //[HttpPut("{id}")]
        //public async Task<ActionResult<ClienteModel>> AtualizarCliente([FromBody] ClienteModel clienteModel, int id)
        //{
        //    clienteModel.ClienteId = id;
        //    var clienteAtualizado = await _clienteRepository.AtualizarCliente(clienteModel, id);
        //    return Ok(clienteAtualizado);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<ClienteModel>> DeletarCliente(int id)
        //{
        //    bool apagado = await _clienteRepository.DeletarCliente(id);
        //    return Ok(apagado);
        //}
    }
}
