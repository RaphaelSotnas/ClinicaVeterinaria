using ClinicaVeterinaria.API.Models;
using ClinicaVeterinaria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using ClinicaVeterinaria.API.Data;

namespace ClinicaVeterinaria.API.Repository
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly ClinicaVeterinariaDBContext _dbContext;
         
        public AgendamentoRepository(ClinicaVeterinariaDBContext clinicaVeterinariaDBContext)
        {
            _dbContext = clinicaVeterinariaDBContext;
        }

        public async Task<List<AgendamentoModel>> ListarHorariosDisponiveis()
        {
            return await _dbContext.Agendamento.ToListAsync();
        }

        //public async Task<AgendamentoModel> AgendarConsulta(AgendamentoModel agendamento)
        //{
        //    await _dbContext.Agendamento.AddAsync(agendamento);
        //    await _dbContext.SaveChangesAsync();
        //    return agendamento;
        //}

        public async Task<AgendamentoModel> BuscarAgendamentoPorId(int idAgendamento)
        {
            var agendamento = await _dbContext.Agendamento.FirstOrDefaultAsync(x => x.AgendamentoId == idAgendamento);
            if (agendamento == null)
                throw new Exception($"Nenhum agendamento foi encontrado para o Id: {agendamento} informado.");

            return agendamento;
        }

        public async Task<AgendamentoModel> AgendarConsulta(AgendamentoModel agendamentoAtualizado)
        {
            var agendamentoDoBanco = await BuscarAgendamentoPorId(agendamentoAtualizado.AgendamentoId);

            agendamentoDoBanco.DataConsulta = agendamentoAtualizado.DataConsulta;
            agendamentoDoBanco.DataCadastro = agendamentoAtualizado.DataCadastro;
            agendamentoDoBanco.Veterinario = agendamentoAtualizado.Veterinario;
            agendamentoDoBanco.VeterinarioNome = agendamentoAtualizado.VeterinarioNome;
            agendamentoDoBanco.VeterinarioId = agendamentoAtualizado.VeterinarioId;
            agendamentoDoBanco.VeterinarioGeriatrico = agendamentoAtualizado.VeterinarioGeriatrico;
            agendamentoDoBanco.Animal = agendamentoAtualizado.Animal;
            agendamentoDoBanco.AnimalId = agendamentoAtualizado.AnimalId;
            agendamentoDoBanco.Disponivel = agendamentoAtualizado.Disponivel;

            _dbContext.Agendamento.Update(agendamentoDoBanco);
            await _dbContext.SaveChangesAsync();
            return agendamentoDoBanco;
        }

        //    public async Task<bool> CancelarAgendamento(int idAgendamento)
        //    {
        //        var agendamentoDoBanco = await BuscarAgendamentoPorId(idAgendamento);

        //        _dbContext.Agendamento.Remove(agendamentoDoBanco);
        //        await _dbContext.SaveChangesAsync();
        //        return true;
        //    }
    }
}
