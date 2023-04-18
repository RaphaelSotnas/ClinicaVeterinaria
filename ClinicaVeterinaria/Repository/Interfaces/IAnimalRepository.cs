using ClinicaVeterinaria.API.Models;


namespace ClinicaVeterinaria.Repository.Interfaces
{
    public interface IAnimalRepository
    {
        Task<bool> DeletarAnimal(int idAnimal);
        Task<List<AnimalModel>> BuscarAnimaisPorIdCliente(int idCliente);
        Task<AnimalModel> BuscarAnimalPorId(int idAnimal);
        Task<AnimalModel> CadastrarAnimal(AnimalModel animal);

        //Task<List<AnimalModel>> BuscarAnimais();
        //Task<AnimalModel> AtualizarAnimal(AnimalModel animalAtualizado, int idAnimal);
    }
}
