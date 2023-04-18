using ClinicaVeterinaria.API.Models;


namespace ClinicaVeterinaria.API.Domain.Interfaces.InterfacesRepository
{
    public interface IAgendamentoRepository
    {
        Task<List<AgendamentoModel>> ListarHorariosDisponiveis();
        Task<AgendamentoModel> BuscarAgendamentoPorId(int idAgendamento);
        Task<AgendamentoModel> AgendarConsulta(AgendamentoModel agendamentoAtualizado);
        //Task<bool> CancelarAgendamento(int idAgendamento);
        //Task<AgendamentoModel> AgendarConsulta(AgendamentoModel agendamento);
    }
}
