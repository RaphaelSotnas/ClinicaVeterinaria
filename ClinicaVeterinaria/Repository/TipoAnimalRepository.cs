using ClinicaVeterinaria.Data;
using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Repository
{
    public class TipoAnimalRepository : ITipoAnimalRepository
    {
        private readonly ClinicaVeterinariaDBContext _dbContext;
        public TipoAnimalRepository(ClinicaVeterinariaDBContext clinicaVeterinariaDBContext)
        {
            _dbContext = clinicaVeterinariaDBContext;
        }
       
        public async Task<List<TipoAnimalModel>> ListarTiposDeAnimais()
        {
            return await _dbContext.TiposDeAnimais.ToListAsync();
        }

        public async Task<TipoAnimalModel> BuscarTipoDeAnimalPorId(int idTipoAnimal)
        {
            var tipoAnimal = await _dbContext.TiposDeAnimais.FirstOrDefaultAsync(x => x.TipoAnimalId == idTipoAnimal);
            if (tipoAnimal == null)
                throw new Exception($"O Tipo de animal de ID: {idTipoAnimal} não existe no banco de dados.");

            return tipoAnimal;
        }

        public async Task<TipoAnimalModel> CadastrarTipoAnimal(TipoAnimalModel tipoAnimal)
        {
            await _dbContext.TiposDeAnimais.AddAsync(tipoAnimal);
            await _dbContext.SaveChangesAsync();
            return tipoAnimal;
        }

        public async Task<TipoAnimalModel> AtualizarTipoAnimal(TipoAnimalModel tipoAnimalAtualizado, int idTipoAnimal)
        {
            var tipoAnimalDoBanco = await BuscarTipoDeAnimalPorId(idTipoAnimal);

            tipoAnimalDoBanco.TipoAnimalId = tipoAnimalAtualizado.TipoAnimalId;
            tipoAnimalDoBanco.CategoriaAnimal = tipoAnimalAtualizado.CategoriaAnimal;
            tipoAnimalDoBanco.DataCadastro = tipoAnimalAtualizado.DataCadastro;

            _dbContext.TiposDeAnimais.Update(tipoAnimalDoBanco);
            await _dbContext.SaveChangesAsync();
            return tipoAnimalDoBanco;
        }
        public async Task<bool> DeletarTipoAnimal(int idTipoAnimal)
        {
            var tipoAnimalDoBanco = await BuscarTipoDeAnimalPorId(idTipoAnimal);

            _dbContext.TiposDeAnimais.Remove(tipoAnimalDoBanco);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
