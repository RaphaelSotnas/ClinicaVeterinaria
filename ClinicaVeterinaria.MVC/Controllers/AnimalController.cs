using ClinicaVeterinaria.API;
using ClinicaVeterinaria.MVC.Models.Entidades;
using ClinicaVeterinaria.Web.Helper;
using ClinicaVeterinaria.Web.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClinicaVeterinaria.Web.Controllers
{
    public class AnimalController : Controller
    {
        public readonly string endPoint = "https://localhost:7018/api/Animal/";
        private readonly HttpClient _httpClient;
        private readonly ISessao _sessao;
        public AnimalController(ISessao sessao)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(endPoint);
            _sessao = sessao;
        }

        public async Task<IActionResult> ListarMeusPets()
        {
            try
            {
                var clienteLogado = _sessao.BuscarSessaoCliente();


                var clienteResponse = await _httpClient.GetStringAsync("https://localhost:7018/api/Cliente/" + $"{clienteLogado.CpfCliente}");
                var cliente = JsonConvert.DeserializeObject<Cliente>(clienteResponse);

                var responseListaAnimais = await _httpClient.GetStringAsync("https://localhost:7018/api/Animal/" + $"{cliente.ClienteId}");
                var listaAnimaisDeserialize = JsonConvert.DeserializeObject<List<Animal>>(responseListaAnimais);

                ViewBag.mensagem = clienteLogado.NomeCliente;

                return View(listaAnimaisDeserialize);

            }
            catch 
            {
                return View("PaginaErro");
            }
        }

        public async Task<ActionResult> DeletarAnimal(int animalId)
        {
            try
            {
                var animalApagadoResponse = await _httpClient.DeleteAsync(endPoint + $"{animalId}");
                return View(animalApagadoResponse);
            }
            catch (Exception)
            {
                return View("PaginaErro");
            }
        }

        public async Task<IActionResult> FormCadastroAnimal()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAnimal(Animal animal)
        {
            try
            {
                var clienteLogado = _sessao.BuscarSessaoCliente();

                var clienteResponse = await _httpClient.GetStringAsync("https://localhost:7018/api/Cliente/" + $"{clienteLogado.CpfCliente}");
                var cliente = JsonConvert.DeserializeObject<Cliente>(clienteResponse);
                
                animal.ClienteId = cliente.ClienteId;

                var response = await _httpClient.PostAsJsonAsync(endPoint, animal);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    string retorno = await response.Content.ReadAsStringAsync();

                    var mensagem = JsonConvert.DeserializeObject<ResponseMessage>(retorno);

                    ViewBag.mensagemErro = mensagem.Mensagem;

                    return View("PaginaErro");
                }
                return RedirectToAction("ListarMeusPets");
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
