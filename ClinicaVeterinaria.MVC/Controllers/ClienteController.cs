using ClinicaVeterinaria.API;
using ClinicaVeterinaria.MVC.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClinicaVeterinaria.MVC.Controllers
{
    public class ClienteController : Controller
    {
        public readonly string endPoint = "https://localhost:7018/api/Cliente";
        private readonly HttpClient _httpClient;

        public ClienteController( )
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(endPoint);
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> FormCadastro()
        {
            return View();
        }

        public async Task<IActionResult> Cadastrar(Cliente cliente)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(endPoint, cliente);
                if(response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var x = response.Content.ReadAsStringAsync();

                    var mensagem = JsonConvert.DeserializeObject<ResponseTeste>(x.ToString());

                    View("FormCadastro");
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return View();
        }




    }
}
