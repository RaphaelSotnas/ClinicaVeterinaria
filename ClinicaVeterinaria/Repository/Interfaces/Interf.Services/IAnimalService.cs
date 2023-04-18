using ClinicaVeterinaria.API.Models;

namespace ClinicaVeterinaria.API.Repository.Interfaces.Interf.Services
{
    public interface IAnimalService
    {
        public Task<List<AnimalModel>> ListarMeusPets(int idCliente);
        public Task<bool> DeletarAnimal(int idAnimal);
        public Task<AnimalModel> CadastrarAnimal(AnimalModel animal);
    }
}
