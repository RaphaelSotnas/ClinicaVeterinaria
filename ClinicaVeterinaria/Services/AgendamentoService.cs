﻿using ClinicaVeterinaria.API.Models;
using ClinicaVeterinaria.API.Repository.Interfaces.Interf.Services;
using ClinicaVeterinaria.Repository.Interfaces;

namespace ClinicaVeterinaria.API.Services
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        public AgendamentoService(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        public async Task<AgendamentoModel> AgendarConsulta(AgendamentoModel agendamentoAtualizado)
        {
            var animalEhIdoso = agendamentoAtualizado.Animal.Geriatria;
            if (animalEhIdoso)
            {
                if(agendamentoAtualizado.VeterinarioGeriatrico == false)
                {
                    throw new Exception("O agendamento não pode ser realizado. Animais idosos só podem ser agendados com médicos que possuem especialização.");
                }
            }

            return await _agendamentoRepository.AgendarConsulta(agendamentoAtualizado);
        }

        public async Task<AgendamentoModel> BuscarAgendamentoPorId(int agendamentoId)
        {
            var agendamentoDoBanco = await _agendamentoRepository.BuscarAgendamentoPorId(agendamentoId);
            if (agendamentoDoBanco == null)
                return null;

            return agendamentoDoBanco;
        }

        public async Task<List<AgendamentoModel>> ListarHorariosDisponiveis()
        {
            var listaRetorno = await _agendamentoRepository.ListarHorariosDisponiveis();
            if (listaRetorno == null || listaRetorno.Count() == 0)
                return null;

            return listaRetorno;
        }
    }
}
