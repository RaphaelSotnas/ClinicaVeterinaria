using ClinicaVeterinaria.API.Models;

namespace ClinicaVeterinaria.API.Repository.Interfaces
{
    public interface IAnimalService
    {
        public Task<List<AnimalModel>> ListarMeusPets(int idCliente);
    }
}
