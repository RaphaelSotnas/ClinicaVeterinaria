using ClinicaVeterinaria.API.Models;


namespace ClinicaVeterinaria.Repository.Interfaces
{
    public interface IAgendamentoRepository
    {
        Task<List<AgendamentoModel>> ListarAgendamentos();
        Task<AgendamentoModel> BuscarAgendamentoPorId(int idAgendamento);
        Task<AgendamentoModel> CadastrarConsulta(AgendamentoModel agendamento);
        Task<bool> CancelarAgendamento(int idAgendamento);
        Task<AgendamentoModel> AtualizarAgendamento(AgendamentoModel agendamentoAtualizado, int idAgendamento);
    }
}
