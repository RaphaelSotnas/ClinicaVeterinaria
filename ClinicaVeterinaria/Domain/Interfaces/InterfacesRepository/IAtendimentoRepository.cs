using ClinicaVeterinaria.API.Models;

namespace ClinicaVeterinaria.API.Domain.Interfaces.InterfacesRepository
{
    public interface IAtendimentoRepository
    {
        Task<List<AtendimentoModel>> AtendimentosTotais();
        Task<List<AtendimentoModel>> BuscarAtendimentoPorIdCliente(int idCliente);
        //Task<AtendimentoModel> CadastrarAtendimento(AtendimentoModel atendimento);
        //Task<bool> DeletarAtendimento(int idAtendimento);
        //Task<AtendimentoModel> AtualizarAtendimento(AtendimentoModel atendimentoAtualizado, int idAtendimento);
    }
}
