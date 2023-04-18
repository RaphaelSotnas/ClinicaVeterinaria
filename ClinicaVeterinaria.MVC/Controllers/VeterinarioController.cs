using ClinicaVeterinaria.API;
using ClinicaVeterinaria.Web.Helper;
using ClinicaVeterinaria.Web.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClinicaVeterinaria.Web.Controllers
{
    public class VeterinarioController : Controller
    {
        public readonly string endPoint = "https://localhost:7018/api/Veterinario";
        private readonly HttpClient _httpClient;
        private readonly ISessao _sessao;
        public VeterinarioController(ISessao sessao)
        {
            _sessao = sessao;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(endPoint);
        }

        public async Task<IActionResult> ListarVeterinarios()
        {
            try
            {
                var clienteLogado = _sessao.BuscarSessaoCliente();

                var responseListaVeterinarios = await _httpClient.GetStringAsync("https://localhost:7018/api/Veterinario");
                var listaVeterinariosDeserialize = JsonConvert.DeserializeObject<List<Veterinario>>(responseListaVeterinarios);

                ViewBag.mensagem = clienteLogado.NomeCliente;

                return View(listaVeterinariosDeserialize);
            }
            catch
            {
                return View("PaginaErro");
            }
        }

        public async Task<IActionResult> FormCadastroVeterinario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarVeterinario(Veterinario veterinario)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(endPoint, veterinario);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    string retorno = await response.Content.ReadAsStringAsync();

                    var mensagem = JsonConvert.DeserializeObject<ResponseMessage>(retorno);

                    ViewBag.mensagemErro = mensagem.Mensagem;

                    return View("PaginaErro");
                }
                return RedirectToAction("ListarVeterinarios");
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public async Task<IActionResult> DeletarVeterinario(int veterinarioId)
        {
            try
            {
                var animalApagadoResponse = await _httpClient.DeleteAsync(endPoint + $"/{veterinarioId}");
                return View(animalApagadoResponse);
            }
            catch (Exception)
            {
                return View("PaginaErro");
            }
        }
    }
}
