using ClinicaVeterinaria.Models;

namespace ClinicaVeterinaria.Repository.Interfaces
{
    public interface IAtendimentoRepository
    {
        Task<List<AtendimentoModel>> AtendimentosTotais();
        Task<AtendimentoModel> BuscarAtendimentoPorId(int idAtendimento);
        Task<AtendimentoModel> CadastrarAtendimento(AtendimentoModel atendimento);
        Task<bool> DeletarAtendimento(int idAtendimento);
        Task<AtendimentoModel> AtualizarAtendimento(AtendimentoModel atendimentoAtualizado, int idAtendimento);
    }
}
