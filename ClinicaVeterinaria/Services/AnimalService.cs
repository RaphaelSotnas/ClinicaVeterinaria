using ClinicaVeterinaria.API.Models;
using ClinicaVeterinaria.API.Repository.Interfaces;
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
                return null; // Melhorar validação para retornar uma mensagem: "Você ainda não possui PETs cadastrados em nosso site."

            return listaRetorno;
        }
    }
}
