using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
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
        public async Task<ActionResult<ClienteModel>> CadastrarCliente([FromBody] ClienteModel clienteModel)
        {
            var cliente = await _clienteRepository.CadastrarCliente(clienteModel);
            return Ok(cliente);
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
