using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly IAtendimentoRepository _atendimentoRepository;
        public AtendimentoController(IAtendimentoRepository atendimentoRepository)
        {
            _atendimentoRepository = atendimentoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AtendimentoModel>>> ListarTodosAtendimentos()
        {
            List<AtendimentoModel> animais = await _atendimentoRepository.AtendimentosTotais();
            return Ok(animais);
        }

        [HttpGet("{atendimentoId}")]
        public async Task<ActionResult<List<AtendimentoModel>>> BuscarAtendimentoPorId(int atendimentoId)
        {
            AtendimentoModel atendimento = await _atendimentoRepository.BuscarAtendimentoPorId(atendimentoId);
            return Ok(atendimento);
        }

        [HttpPost]
        public async Task<ActionResult<AtendimentoModel>> CadastrarAtendimento([FromBody] AtendimentoModel atendimentoModel)
        {
            var atendimento = await _atendimentoRepository.CadastrarAtendimento(atendimentoModel);
            return Ok(atendimento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AtendimentoModel>> AtualizarAtendimento([FromBody] AtendimentoModel atendimentoModel, int id)
        {
            atendimentoModel.AtendimentoId = id;
            var atendimentoAtualizado = await _atendimentoRepository.AtualizarAtendimento(atendimentoModel, id);
            return Ok(atendimentoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AtendimentoModel>> DeletarAtendimento(int id)
        {
            bool apagado = await _atendimentoRepository.DeletarAtendimento(id);
            return Ok(apagado);
        }
    }
}
