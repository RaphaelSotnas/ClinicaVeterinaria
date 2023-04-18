using ClinicaVeterinaria.API.Models;

namespace ClinicaVeterinaria.API.Repository.Interfaces.Interf.Services
{
    public interface IAtendimentoService
    {
        Task<List<AtendimentoModel>> AtendimentosTotais();

        Task<List<AtendimentoModel>> BuscarAtendimentoPorId(int idCliente);
    }
}
