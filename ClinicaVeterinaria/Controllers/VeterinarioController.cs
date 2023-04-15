using ClinicaVeterinaria.API.Models;
using ClinicaVeterinaria.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinarioController : ControllerBase
    {
        private readonly IVeterinarioRepository _veterinarioRepository;
        public VeterinarioController(IVeterinarioRepository veterinarioRepository)
        {
            _veterinarioRepository = veterinarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<VeterinarioModel>>> ListarVeterinarios()
        {
            List<VeterinarioModel> veterinarios = await _veterinarioRepository.BuscarVeterinarios();
            return Ok(veterinarios);
        }

        [HttpGet("{veterinarioId}")]
        public async Task<ActionResult<List<VeterinarioModel>>> BuscarVeterinarioPorId(int veterinarioId)
        {
            VeterinarioModel veterinario = await _veterinarioRepository.BuscarVeterinarioPorId(veterinarioId);
            return Ok(veterinario);
        }

        [HttpPost]
        public async Task<ActionResult<VeterinarioModel>> CadastrarVeterinario([FromBody] VeterinarioModel veterinarioModel)
        {
            var veterinario = await _veterinarioRepository.CadastrarVeterinario(veterinarioModel);
            return Ok(veterinario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VeterinarioModel>> AtualizarVeterinario([FromBody] VeterinarioModel veterinarioModel, int id)
        {
            veterinarioModel.VeterinarioId = id;
            var veterinarioAtualizado = await _veterinarioRepository.AtualizarVeterinario(veterinarioModel, id);
            return Ok(veterinarioAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VeterinarioModel>> DeletarVeterinario(int id)
        {
            bool apagado = await _veterinarioRepository.DeletarVeterinario(id);
            return Ok(apagado);
        }


    }
}
