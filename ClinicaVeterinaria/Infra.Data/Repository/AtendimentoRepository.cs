using ClinicaVeterinaria.API.Data;
using ClinicaVeterinaria.API.Domain.Interfaces.InterfacesRepository;
using ClinicaVeterinaria.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Repository
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly ClinicaVeterinariaDBContext _dbContext;
        public AtendimentoRepository(ClinicaVeterinariaDBContext clinicaVeterinariaDBContext)
        {
            _dbContext = clinicaVeterinariaDBContext;
        }

        public async Task<List<AtendimentoModel>> AtendimentosTotais()
        {
            return await _dbContext.Atendimento.ToListAsync();
        }

        public async Task<List<AtendimentoModel>> BuscarAtendimentoPorIdCliente(int idCliente)
        {
            return await _dbContext.Atendimento.Where(x => x.ClienteId == idCliente).ToListAsync();
        }

        //public async Task<AtendimentoModel> CadastrarAtendimento(AtendimentoModel atendimento)
        //{
        //    await _dbContext.Atendimento.AddAsync(atendimento);
        //    await _dbContext.SaveChangesAsync();
        //    return atendimento;
        //}

        //public async Task<AtendimentoModel> AtualizarAtendimento(AtendimentoModel atendimentoAtualizado, int idAtendimento)
        //{
        //    var atendimentoDoBanco = await BuscarAtendimentoPorId(idAtendimento);

        //    atendimentoDoBanco.AtendimentoId = atendimentoAtualizado.AtendimentoId;
        //    atendimentoDoBanco.Veterinario = atendimentoAtualizado.Veterinario;
        //    atendimentoDoBanco.VeterinarioId = atendimentoAtualizado.VeterinarioId;
        //    atendimentoDoBanco.DataAtendimento = atendimentoAtualizado.DataAtendimento;
        //    atendimentoDoBanco.DataCadastro = atendimentoAtualizado.DataCadastro;
        //    atendimentoDoBanco.Diagnostico = atendimentoAtualizado.Diagnostico;

        //    _dbContext.Atendimento.Update(atendimentoDoBanco);
        //    await _dbContext.SaveChangesAsync();
        //    return atendimentoDoBanco;
        //}

        //public async Task<bool> DeletarAtendimento(int idAtendimento)
        //{
        //    var atendimentoDoBanco = await BuscarAtendimentoPorId(idAtendimento);

        //    _dbContext.Atendimento.Remove(atendimentoDoBanco);
        //    await _dbContext.SaveChangesAsync();
        //    return true;
        //}
    }
}

