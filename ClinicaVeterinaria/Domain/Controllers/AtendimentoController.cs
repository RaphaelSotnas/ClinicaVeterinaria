using ClinicaVeterinaria.API.Models;
using ClinicaVeterinaria.API.Repository.Interfaces.Interf.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly IAtendimentoService _atendimentoService;
        public AtendimentoController(IAtendimentoService atendimentoService)
        {
            _atendimentoService = atendimentoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AtendimentoModel>>> ListarTodosAtendimentos()
        {
            List<AtendimentoModel> animais = await _atendimentoService.AtendimentosTotais();
            return Ok(animais);
        }

        [HttpGet("{idCliente}")]
        public async Task<ActionResult<List<AtendimentoModel>>> BuscarAtendimentoPorIdCliente(int idCliente)
        {
            List<AtendimentoModel> listaDeAtendimento = await _atendimentoService.BuscarAtendimentoPorId(idCliente);
            return Ok(listaDeAtendimento);
        }

        //[HttpPost]
        //public async Task<ActionResult<AtendimentoModel>> CadastrarAtendimento([FromBody] AtendimentoModel atendimentoModel)
        //{
        //    var atendimento = await _atendimentoRepository.CadastrarAtendimento(atendimentoModel);
        //    return Ok(atendimento);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<AtendimentoModel>> AtualizarAtendimento([FromBody] AtendimentoModel atendimentoModel, int id)
        //{
        //    atendimentoModel.AtendimentoId = id;
        //    var atendimentoAtualizado = await _atendimentoRepository.AtualizarAtendimento(atendimentoModel, id);
        //    return Ok(atendimentoAtualizado);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<AtendimentoModel>> DeletarAtendimento(int id)
        //{
        //    bool apagado = await _atendimentoRepository.DeletarAtendimento(id);
        //    return Ok(apagado);
        //}
    }
}
