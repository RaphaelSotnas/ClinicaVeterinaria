using ClinicaVeterinaria.API.Domain.Interfaces.InterfacesRepository;
using ClinicaVeterinaria.API.Models;
using ClinicaVeterinaria.API.Repository.Interfaces.Interf.Services;

namespace ClinicaVeterinaria.API.Services
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly IAtendimentoRepository _atendimentoRepository;
        public AtendimentoService(IAtendimentoRepository atendimentoRepository)
        {
            _atendimentoRepository = atendimentoRepository;
        }

        public async Task<List<AtendimentoModel>> AtendimentosTotais()
        {
            var listaRetorno = await _atendimentoRepository.AtendimentosTotais();
            if (listaRetorno == null || listaRetorno.Count() == 0)
                return null;

            return listaRetorno;
        }

        public async Task<List<AtendimentoModel>> BuscarAtendimentoPorId(int idCliente)
        {
            var listaDeAtendimento = await _atendimentoRepository.BuscarAtendimentoPorIdCliente(idCliente);
            if (listaDeAtendimento == null || listaDeAtendimento.Count() == 0)
                return null;

            return listaDeAtendimento;
        }
    }
}
