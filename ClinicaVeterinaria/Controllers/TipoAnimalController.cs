using ClinicaVeterinaria.Models;
using ClinicaVeterinaria.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoAnimalController : ControllerBase
    {
        private readonly ITipoAnimalRepository _tipoAnimalRepository;
        public TipoAnimalController(ITipoAnimalRepository tipoAnimalRepository)
        {
            _tipoAnimalRepository = tipoAnimalRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoAnimalModel>>> ListarTiposDeAnimais()
        {
            List<TipoAnimalModel> tiposDeAnimal = await _tipoAnimalRepository.ListarTiposDeAnimais();
            return Ok(tiposDeAnimal);
        }

        [HttpGet("{tipoAnimalId}")]
        public async Task<ActionResult<List<TipoAnimalModel>>> BuscarTipoAnimalPorId(int tipoAnimalId)
        {
            TipoAnimalModel tipoAnimal = await _tipoAnimalRepository.BuscarTipoDeAnimalPorId(tipoAnimalId);
            return Ok(tipoAnimal);
        }

        [HttpPost]
        public async Task<ActionResult<TipoAnimalModel>> CadastrarTipoAnimal([FromBody] TipoAnimalModel tipoAnimalModel)
        {
            var tipoAnimal = await _tipoAnimalRepository.CadastrarTipoAnimal(tipoAnimalModel);
            return Ok(tipoAnimal);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TipoAnimalModel>> AtualizarTipoAnimal([FromBody] TipoAnimalModel tipoAnimalModel, int id)
        {
            tipoAnimalModel.TipoAnimalId = id;
            var tipoAnimalAtualizado = await _tipoAnimalRepository.AtualizarTipoAnimal(tipoAnimalModel, id);

            return Ok(tipoAnimalAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoAnimalModel>> DeletarTipoAnimal(int id)
        {
            bool apagado = await _tipoAnimalRepository.DeletarTipoAnimal(id);
            return Ok(apagado);
        }
    }
}
