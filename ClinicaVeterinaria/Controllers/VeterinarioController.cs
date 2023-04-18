using ClinicaVeterinaria.API.Models;
using ClinicaVeterinaria.API.Repository.Interfaces.Interf.Services;
using ClinicaVeterinaria.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinarioController : ControllerBase
    {
        private readonly IVeterinarioService _veterinarioService;
        public VeterinarioController(IVeterinarioService veterinarioService)
        {
            _veterinarioService = veterinarioService;
        }

        [HttpGet]
        public async Task<ActionResult<List<VeterinarioModel>>> ListarVeterinarios()
        {
            List<VeterinarioModel> veterinarios = await _veterinarioService.ListarVeterinarios();
            return Ok(veterinarios);
        }

        [HttpPost]
        public async Task<ActionResult<VeterinarioModel>> CadastrarVeterinario([FromBody] VeterinarioModel veterinarioModel)
        {
            var veterinario = await _veterinarioService.CadastrarVeterinario(veterinarioModel);
            return Ok(veterinario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VeterinarioModel>> DeletarVeterinario(int id)
        {
            bool apagado = await _veterinarioService.DeletarVeterinario(id);
            return Ok(apagado);
        }

        [HttpGet("{veterinarioId}")]
        public async Task<ActionResult<VeterinarioModel>> BuscarVeterinarioPorId(int veterinarioId)
        {
            VeterinarioModel veterinario = await _veterinarioService.BuscarVeterinarioPorId(veterinarioId);
            return Ok(veterinario);
        }

        //[HttpGet("{nomeVeterinario}")]
        //public async Task<ActionResult<VeterinarioModel>> BuscarVeterinarioPeloNome(string nomeVeterinario)
        //{
        //    VeterinarioModel veterinario = await _veterinarioService.BuscarVeterinarioPeloNome(nomeVeterinario);
        //    return Ok(veterinario);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<VeterinarioModel>> AtualizarVeterinario([FromBody] VeterinarioModel veterinarioModel, int id)
        //{
        //    veterinarioModel.VeterinarioId = id;
        //    var veterinarioAtualizado = await _veterinarioRepository.AtualizarVeterinario(veterinarioModel, id);
        //    return Ok(veterinarioAtualizado);
        //}
    }
}
