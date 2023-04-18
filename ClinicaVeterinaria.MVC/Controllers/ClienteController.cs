using ClinicaVeterinaria.API;
using ClinicaVeterinaria.MVC.Models.Entidades;
using ClinicaVeterinaria.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClinicaVeterinaria.MVC.Controllers
{
    public class ClienteController : Controller
    {
        public readonly string endPoint = "https://localhost:7018/api/Cliente";
        private readonly HttpClient _httpClient;
        private readonly ISessao _sessao;
        public ClienteController(ISessao sessao)
        {
            _sessao = sessao;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(endPoint);
        }

        public async Task<IActionResult> Index()
        {
            if (_sessao.BuscarSessaoCliente() != null) return View("/Views/Home/Home.cshtml");

            return View();
        }

        public async Task<IActionResult> FormCadastro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Cliente cliente)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(endPoint, cliente);
                if(response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    string retorno = await response.Content.ReadAsStringAsync();

                    var mensagem = JsonConvert.DeserializeObject<ResponseMessage>(retorno);

                    ViewBag.mensagemErro = mensagem.Mensagem;

                    return View("FormCadastro");
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public async Task<IActionResult> Logar(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _httpClient.PostAsJsonAsync("https://localhost:7018/api/Cliente/logar", cliente);
                    string valor = await response.Content.ReadAsStringAsync();
                    var mensagemDeserialize = JsonConvert.DeserializeObject<ResponseMessage>(valor);

                    var responseCliente = await _httpClient.GetStringAsync("https://localhost:7018/api/Cliente/" + $"{cliente.CpfCliente}");
                    var clienteDeserialize = JsonConvert.DeserializeObject<Cliente>(responseCliente);

                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.mensagem = mensagemDeserialize.Mensagem;

                        return View("Index");
                    }

                    ViewBag.mensagem = mensagemDeserialize.Mensagem;
                    _sessao.CriarSessaoCliente(clienteDeserialize);
                    
                    return View("/Views/Cliente/Home.cshtml", clienteDeserialize);
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public IActionResult Deslogar()
        {
            _sessao.RemoverSessaoUsuario();

            return View("Index");
        }
    }
}
