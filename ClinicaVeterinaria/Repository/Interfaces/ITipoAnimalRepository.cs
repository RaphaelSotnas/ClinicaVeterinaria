using ClinicaVeterinaria.API.Models;


namespace ClinicaVeterinaria.API.Repository.Interfaces
{
    public interface ITipoAnimalRepository
    {
        Task<List<TipoAnimalModel>> ListarTiposDeAnimais();
        Task<TipoAnimalModel> BuscarTipoDeAnimalPorId(int idTipoAnimal);
        Task<TipoAnimalModel> CadastrarTipoAnimal(TipoAnimalModel tipoAnimal);
        Task<bool> DeletarTipoAnimal(int idTipoAnimal);
        Task<TipoAnimalModel> AtualizarTipoAnimal(TipoAnimalModel tipoAnimalAtualizado, int idTipoAnimal);
    }
}
