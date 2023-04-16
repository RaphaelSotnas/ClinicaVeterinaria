using ClinicaVeterinaria.Web.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClinicaVeterinaria.Web.Controllers
{
    public class AnimalController : Controller
    {
        public readonly string endPoint = "https://localhost:7018/api/Animal";
        private readonly HttpClient _httpClient;
        public AnimalController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(endPoint);
        }

        public async Task<IActionResult> ListarMeusPets(int idCliente)
        {
            var responseListaAnimais = await _httpClient.GetStringAsync(endPoint + $"{idCliente}");
            var listaAnimaisDeserialize = JsonConvert.DeserializeObject<List<Animal>>(responseListaAnimais);

            return View(listaAnimaisDeserialize);
        }
    }
}
