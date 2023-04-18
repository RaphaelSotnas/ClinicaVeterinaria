using ClinicaVeterinaria.API;
using ClinicaVeterinaria.API.Models;
using ClinicaVeterinaria.API.Repository.Interfaces.Interf.Services;
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<AnimalModel>> DeletarAnimal(int id)
        {
            bool apagado = await _animalService.DeletarAnimal(id);
            return Ok(apagado);
        }

        [HttpPost]
        public async Task<ActionResult<AnimalModel>> CadastrarAnimal([FromBody] AnimalModel animalModel)
        {
            var animal = await _animalService.CadastrarAnimal(animalModel);
            return Ok(animal);
        }

        //[HttpGet]
        //public async Task<ActionResult<List<AnimalModel>>> ListarAnimais()
        //{
        //    List<AnimalModel> animais = await _animalRepository.BuscarAnimais();
        //    return Ok(animais);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<AnimalModel>> AtualizarAnimal([FromBody] AnimalModel animalModel, int id)
        //{
        //    animalModel.AnimalId = id;
        //    var animalAtualizado = await _animalRepository.AtualizarAnimal(animalModel, id);
        //    return Ok(animalAtualizado);
        //}
    }
}
