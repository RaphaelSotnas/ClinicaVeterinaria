using ClinicaVeterinaria.API.Models;
using ClinicaVeterinaria.API.Repository.Interfaces;
using ClinicaVeterinaria.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;
        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet("{idCliente}")]
        public async Task<ActionResult<List<AnimalModel>>> BuscarAnimaisPorIdCliente(int idCliente)
        {
            List<AnimalModel> listaDeAnimais = await _animalService.ListarMeusPets(idCliente);
            return Ok(listaDeAnimais);
        }

        //[HttpGet]
        //public async Task<ActionResult<List<AnimalModel>>> ListarAnimais()
        //{
        //    List<AnimalModel> animais = await _animalRepository.BuscarAnimais();
        //    return Ok(animais);
        //}


        //[HttpPost]
        //public async Task<ActionResult<AnimalModel>> CadastrarAnimal([FromBody] AnimalModel animalModel)
        //{
        //    var animal = await _animalRepository.CadastrarAnimal(animalModel);
        //    return Ok(animal);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<AnimalModel>> AtualizarAnimal([FromBody] AnimalModel animalModel, int id)
        //{
        //    animalModel.AnimalId = id;
        //    var animalAtualizado = await _animalRepository.AtualizarAnimal(animalModel, id);
        //    return Ok(animalAtualizado);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<AnimalModel>> DeletarAnimal(int id)
        //{
        //    bool apagado = await _animalRepository.DeletarAnimal(id);
        //    return Ok(apagado);
        //}

    }
}
