using ClinicaVeterinaria.Models;

namespace ClinicaVeterinaria.Repository.Interfaces
{
    public interface IAnimalRepository
    {
        Task<List<AnimalModel>> BuscarAnimais();
        Task<AnimalModel> BuscarAnimalPorId(int idAnimal);
        Task<AnimalModel> CadastrarAnimal(AnimalModel animal);
        Task<bool> DeletarAnimal(int idAnimal);
        Task<AnimalModel> AtualizarAnimal(AnimalModel animalAtualizado, int idAnimal);
    }
}
