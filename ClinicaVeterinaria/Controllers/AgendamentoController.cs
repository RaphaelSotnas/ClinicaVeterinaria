using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        public AgendamentoController(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AgendamentoModel>>> ListarAgendamentos()
        {
            List<AgendamentoModel> agendamentos = await _agendamentoRepository.ListarAgendamentos();
            return Ok(agendamentos);
        }

        [HttpGet("{agendamentoId}")]
        public async Task<ActionResult<List<AgendamentoModel>>> BuscarAgendamentoPorId(int agendamentoId)
        {
            AgendamentoModel agendamento = await _agendamentoRepository.BuscarAgendamentoPorId(agendamentoId);
            return Ok(agendamento);
        }

        [HttpPost]
        public async Task<ActionResult<AgendamentoModel>> CadastrarConsulta([FromBody] AgendamentoModel agendamentoModel)
        {
            var agendamento = await _agendamentoRepository.CadastrarConsulta(agendamentoModel);
            return Ok(agendamento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AgendamentoModel>> AtualizarAnimal([FromBody] AgendamentoModel agendamentoModel, int id)
        {
            agendamentoModel.AgendamentoId = id;
            var agendamentoAtualizado = await _agendamentoRepository.AtualizarAgendamento(agendamentoModel, id);

            return Ok(agendamentoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AgendamentoModel>> CancelarAgendamento(int id)
        {
            bool apagado = await _agendamentoRepository.CancelarAgendamento(id);
            return Ok(apagado);
        }
    }
}
