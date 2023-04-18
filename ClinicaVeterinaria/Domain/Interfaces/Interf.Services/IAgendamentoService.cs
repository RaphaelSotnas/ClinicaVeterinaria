using ClinicaVeterinaria.API.Models;

namespace ClinicaVeterinaria.API.Repository.Interfaces.Interf.Services
{
    public interface IAgendamentoService
    {
        public Task<List<AgendamentoModel>> ListarHorariosDisponiveis();

        public Task<AgendamentoModel> AgendarConsulta(AgendamentoModel agendamentoAtualizado);
        public Task<AgendamentoModel> BuscarAgendamentoPorId(int agendamentoId);
        //public Task<AgendamentoModel> AgendarConsulta(AgendamentoModel agendamentoModel);
    }
}
