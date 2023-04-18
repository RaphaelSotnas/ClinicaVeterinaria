using ClinicaVeterinaria.API.Models;


namespace ClinicaVeterinaria.Repository.Interfaces
{
    public interface IAgendamentoRepository
    {
        Task<List<AgendamentoModel>> ListarHorariosDisponiveis();
        //Task<AgendamentoModel> AgendarConsulta(AgendamentoModel agendamento);
        Task<AgendamentoModel> BuscarAgendamentoPorId(int idAgendamento);
        //Task<bool> CancelarAgendamento(int idAgendamento);
        Task<AgendamentoModel> AgendarConsulta(AgendamentoModel agendamentoAtualizado);
    }
}
