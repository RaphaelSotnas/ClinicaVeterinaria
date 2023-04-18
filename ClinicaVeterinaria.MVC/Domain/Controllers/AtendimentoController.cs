using ClinicaVeterinaria.Web.Helper;
using ClinicaVeterinaria.Web.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClinicaVeterinaria.Web.Controllers
{
    public class AtendimentoController : Controller
    {
        public readonly string endPoint = "https://localhost:7018/api/Atendimento";
        private readonly HttpClient _httpClient;
        private readonly ISessao _sessao;
        public AtendimentoController(ISessao sessao)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(endPoint);
            _sessao = sessao;
        }

        public async Task<IActionResult> ListarTodosAtendimentos()
        {
            try
            {
                var clienteLogado = _sessao.BuscarSessaoCliente();

                var responseAtendimentos = await _httpClient.GetStringAsync(endPoint);
                var listaAtendimentosDeserialize = JsonConvert.DeserializeObject<List<Atendimento>>(responseAtendimentos);

                ViewBag.mensagem = clienteLogado.NomeCliente;

                return View(listaAtendimentosDeserialize);
            }
            catch
            {
                return View("PaginaErro");
            }
        }

        public async Task<IActionResult> ListarAtendimentosPorIdCliente()
        {
            try
            {
                var clienteLogado = _sessao.BuscarSessaoCliente();

                var responseAtendimentosDoCliente = await _httpClient.GetStringAsync(endPoint + $"/{clienteLogado.ClienteId}");
                var listaAtendimentosDoClienteDeserialize = JsonConvert.DeserializeObject<List<Atendimento>>(responseAtendimentosDoCliente);

                ViewBag.mensagem = clienteLogado.NomeCliente;

                return View(listaAtendimentosDoClienteDeserialize);
            }
            catch
            {
                return View("PaginaErro");
            }
        }

    }
}
