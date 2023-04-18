using ClinicaVeterinaria.API.Models;
using ClinicaVeterinaria.API.Repository.Interfaces.Interf.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoService _agendamentoService;
        public AgendamentoController(IAgendamentoService agendamentoService)
        {
            _agendamentoService = agendamentoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AgendamentoModel>>> ListarHorariosDisponiveis()
        {
            List<AgendamentoModel> horariosDisponiveis = await _agendamentoService.ListarHorariosDisponiveis();
            return Ok(horariosDisponiveis);
        }

        [HttpPost]
        public async Task<ActionResult<AgendamentoModel>> AgendarConsulta([FromBody] AgendamentoModel agendamentoAtualizado)
        {
            var agendamento = await _agendamentoService.AgendarConsulta(agendamentoAtualizado);
            return Ok(agendamento);
        }

        [HttpGet("{agendamentoId}")]
        public async Task<ActionResult<List<AgendamentoModel>>> BuscarAgendamentoPorId(int agendamentoId)
        {
            AgendamentoModel agendamento = await _agendamentoService.BuscarAgendamentoPorId(agendamentoId);
            return Ok(agendamento);
        }


        //[HttpPut("{id}")]
        //public async Task<ActionResult<AgendamentoModel>> AtualizarAnimal([FromBody] AgendamentoModel agendamentoModel, int id)
        //{
        //    agendamentoModel.AgendamentoId = id;
        //    var agendamentoAtualizado = await _agendamentoRepository.AtualizarAgendamento(agendamentoModel, id);

        //    return Ok(agendamentoAtualizado);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<AgendamentoModel>> CancelarAgendamento(int id)
        //{
        //    bool apagado = await _agendamentoRepository.CancelarAgendamento(id);
        //    return Ok(apagado);
        //}
    }
}
