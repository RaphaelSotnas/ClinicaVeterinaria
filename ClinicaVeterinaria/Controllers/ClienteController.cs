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
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteRepository clienteRepository,
                                IClienteService clienteService)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteModel>>> BuscarClientes()
        {
            List<ClienteModel> clientes = await _clienteRepository.BuscarClientes();
            return Ok(clientes);
        }

        [HttpGet("{idCliente}")]
        public async Task<ActionResult<List<ClienteModel>>> BuscarClientePorId(int idCliente)
        {
            ClienteModel cliente = await _clienteRepository.BuscarClientePorId(idCliente);
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarCliente([FromBody] ClienteModel clienteModel)
        {
            var retorno = await _clienteService.CadastrarCliente(clienteModel);
            if(retorno == true)
                return Ok();

            return BadRequest(new ResponseTeste{Mensagem = "Cliente já cadastrado no banco de dados."});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteModel>> AtualizarCliente([FromBody] ClienteModel clienteModel, int id)
        {
            clienteModel.ClienteId = id;
            var clienteAtualizado = await _clienteRepository.AtualizarCliente(clienteModel, id);
            return Ok(clienteAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteModel>> DeletarCliente(int id)
        {
            bool apagado = await _clienteRepository.DeletarCliente(id);
            return Ok(apagado);
        }
    } 
}
