using ClinicaVeterinaria.API.Models;
using ClinicaVeterinaria.API.Repository.Interfaces.Interf.Services;
using ClinicaVeterinaria.Repository.Interfaces;

namespace ClinicaVeterinaria.API.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<List<AnimalModel>> ListarMeusPets(int idCliente)
        {
            var listaRetorno = await _animalRepository.BuscarAnimaisPorIdCliente(idCliente);
            if (listaRetorno == null || listaRetorno.Count() == 0)
                return null;

            return listaRetorno;
        }

        public async Task<bool> DeletarAnimal(int idAnimal)
        {
            var animalApagado = await _animalRepository.DeletarAnimal(idAnimal);

            return animalApagado;
        }

        public async Task<AnimalModel> CadastrarAnimal(AnimalModel animal)
        {
            animal.Geriatria = (animal.CategoriaAnimal == Web.Enum.CategoriaAnimal.Cachorro ||
            animal.CategoriaAnimal == Web.Enum.CategoriaAnimal.Gato) ?
            (animal.IdadeAnimal >= 7 ?
            true : false) :
            (animal.IdadeAnimal >= 2 ?
            true : false);

            animal.DataCadastro = DateTime.Now;

            return await _animalRepository.CadastrarAnimal(animal);
        }
    }
}
