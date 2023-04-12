using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;
        public AnimalController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AnimalModel>>> ListarAnimais()
        {
            List<AnimalModel> animais = await _animalRepository.BuscarAnimais();
            return Ok(animais);
        }

        [HttpGet("{animalId}")]
        public async Task<ActionResult<List<AnimalModel>>> BuscarAnimalPorId(int animalId)
        {
            AnimalModel animal = await _animalRepository.BuscarAnimalPorId(animalId);
            return Ok(animal);
        }

        [HttpPost]
        public async Task<ActionResult<AnimalModel>> CadastrarAnimal([FromBody] AnimalModel animalModel)
        {
            var animal = await _animalRepository.CadastrarAnimal(animalModel);
            return Ok(animal);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AnimalModel>> AtualizarAnimal([FromBody] AnimalModel animalModel, int id)
        {
            animalModel.AnimalId = id;
            var animalAtualizado = await _animalRepository.AtualizarAnimal(animalModel, id);
            return Ok(animalAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AnimalModel>> DeletarAnimal(int id)
        {
            bool apagado = await _animalRepository.DeletarAnimal(id);
            return Ok(apagado);
        }

    }
}
