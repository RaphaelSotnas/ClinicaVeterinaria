using ClinicaVeterinaria.API.Data;
using ClinicaVeterinaria.API.Models;
using ClinicaVeterinaria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly ClinicaVeterinariaDBContext _dbContext;
        public AnimalRepository(ClinicaVeterinariaDBContext clinicaVeterinariaDBContext)
        {
            _dbContext = clinicaVeterinariaDBContext;
        }

        public async Task<List<AnimalModel>> BuscarAnimaisPorIdCliente(int idCliente)
        {
            List<AnimalModel> listaAnimais = await _dbContext.Animais.Where(x => x.ClienteId == idCliente).ToListAsync();

            return listaAnimais;
        }
        public async Task<bool> DeletarAnimal(int idAnimal)
        {
            var animalDoBanco = await BuscarAnimalPorId(idAnimal);

            _dbContext.Animais.Remove(animalDoBanco);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<AnimalModel> BuscarAnimalPorId(int idAnimal)
        {
            var animal = await _dbContext.Animais.FirstOrDefaultAsync(x => x.AnimalId == idAnimal);
            if (animal == null)
                throw new Exception($"O animal para o ID informado: {idAnimal} não existe no banco de dados.");

            return animal;
        }

        public async Task<AnimalModel> CadastrarAnimal(AnimalModel animal)
        {
            await _dbContext.Animais.AddAsync(animal);
            await _dbContext.SaveChangesAsync();
            return animal;
        }

        //public async Task<List<AnimalModel>> BuscarAnimais()
        //{
        //    return await _dbContext.Animais.ToListAsync();
        //}

        //public async Task<AnimalModel> AtualizarAnimal(AnimalModel animalAtualizado, int idAnimal)
        //{
        //    var animalDoBanco = await BuscarAnimalPorId(idAnimal);

        //    animalDoBanco.Geriatria = animalAtualizado.Geriatria;
        //    animalDoBanco.DataCadastro = animalAtualizado.DataCadastro;
        //    animalDoBanco.AnimalId = animalAtualizado.AnimalId;
        //    animalDoBanco.NomeAnimal = animalAtualizado.NomeAnimal;
        //    animalDoBanco.CategoriaAnimal = animalAtualizado.CategoriaAnimal;
        //    animalDoBanco.IdadeAnimal = animalAtualizado.IdadeAnimal;

        //    _dbContext.Animais.Update(animalDoBanco);
        //    await _dbContext.SaveChangesAsync();
        //    return animalDoBanco;
        //}
    }
}
