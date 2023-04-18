using ClinicaVeterinaria.API.Data;
using ClinicaVeterinaria.API.Models;
using ClinicaVeterinaria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Repository
{
    public class VeterinarioRepository : IVeterinarioRepository
    {
        private readonly ClinicaVeterinariaDBContext _dbContext; 
        public VeterinarioRepository(ClinicaVeterinariaDBContext clinicaVeterinariaDBContext)
        {
            _dbContext = clinicaVeterinariaDBContext;
        }

        public async Task<List<VeterinarioModel>> BuscarVeterinarios()
        {
            return await _dbContext.Veterinarios.ToListAsync();
        }

        //public async Task<VeterinarioModel> BuscarVeterinarioPeloNome(string nomeVeterinario)
        //{
        //    var veterinario = await _dbContext.Veterinarios.FirstOrDefaultAsync(x => x.NomeVeterinario == nomeVeterinario);
        //    if (veterinario == null)
        //        throw new Exception($"O Veterinário informado: {nomeVeterinario} não existe no banco de dados.");

        //    return veterinario;
        //}

        public async Task<VeterinarioModel> BuscarVeterinarioPorId(int idVeterinario)
        {
            var veterinario = await _dbContext.Veterinarios.FirstOrDefaultAsync(x => x.VeterinarioId == idVeterinario);
            if (veterinario == null)
                throw new Exception($"O Veterinário para o ID informado: {idVeterinario} não existe no banco de dados.");

            return veterinario;
        }

        public async Task<VeterinarioModel> CadastrarVeterinario(VeterinarioModel veterinario)
        {
            await _dbContext.Veterinarios.AddAsync(veterinario);
            await _dbContext.SaveChangesAsync();
            return veterinario;
        }
        public async Task<bool> DeletarVeterinario(int idVeterinario)
        {
            var veterinarioDoBanco = await BuscarVeterinarioPorId(idVeterinario);

            _dbContext.Veterinarios.Remove(veterinarioDoBanco);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        //public async Task<VeterinarioModel> AtualizarVeterinario(VeterinarioModel veterinarioAtualizado, int idVeterinario)
        //{
        //    var veterinarioDoBanco = await BuscarVeterinarioPorId(idVeterinario);

        //    veterinarioDoBanco.DataCadastro = veterinarioAtualizado.DataCadastro;
        //    veterinarioDoBanco.DataContratacao = veterinarioAtualizado.DataContratacao;
        //    veterinarioDoBanco.NomeVeterinario = veterinarioAtualizado.NomeVeterinario;
        //    veterinarioDoBanco.Geriatria = veterinarioAtualizado.Geriatria;
        //    veterinarioDoBanco.VeterinarioId = veterinarioAtualizado.VeterinarioId;

        //    _dbContext.Veterinarios.Update(veterinarioDoBanco);
        //    await _dbContext.SaveChangesAsync();
        //    return veterinarioDoBanco;
        //}

    }
}
