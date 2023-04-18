using ClinicaVeterinaria.MVC.Models.Entidades;
using ClinicaVeterinaria.Web.Helper;
using ClinicaVeterinaria.Web.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClinicaVeterinaria.Web.Controllers
{
    public class AgendamentoController : Controller
    {
        public readonly string endPoint = "https://localhost:7018/api/Agendamento";
        private readonly HttpClient _httpClient;
        private readonly ISessao _sessao;
        public AgendamentoController(ISessao sessao)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(endPoint);
            _sessao = sessao;
        }

        public async Task<IActionResult> ListarHorariosDisponiveis()
        {
            try
            {
                var clienteLogado = _sessao.BuscarSessaoCliente();

                var responseListaHorariosDisponiveis = await _httpClient.GetStringAsync(endPoint);
                var listaHorariosDisponiveisDeserialize = JsonConvert.DeserializeObject<List<Agendamento>>(responseListaHorariosDisponiveis);

                ViewBag.mensagem = clienteLogado.NomeCliente;

                return View(listaHorariosDisponiveisDeserialize);
            }
            catch
            {
                return View("PaginaErro");
            }
        }

        public async Task<IActionResult> FormAgendarHorario(int agendamentoId)
        {
            var clienteLogado = _sessao.BuscarSessaoCliente();
            ViewBag.mensagem = clienteLogado.NomeCliente; 

            var agendamentoReponse = await _httpClient.GetStringAsync(endPoint + $"/{agendamentoId}");
            var agendamentoDeserializado = JsonConvert.DeserializeObject<Agendamento>(agendamentoReponse);

            return View(agendamentoDeserializado);
        }

        public async Task<IActionResult> AgendarHorario(Agendamento agendamento)
        {
            var clienteLogado = _sessao.BuscarSessaoCliente();
            ViewBag.mensagem = clienteLogado.NomeCliente;

            var responseCliente = await _httpClient.GetStringAsync("https://localhost:7018/api/Cliente/" + $"{clienteLogado.CpfCliente}");
            var clienteDeserialize = JsonConvert.DeserializeObject<Cliente>(responseCliente);

            var listaAnimaisCadastradosNoBanco = await _httpClient.GetStringAsync("https://localhost:7018/api/Animal/" + $"{clienteDeserialize.ClienteId}");
            var listaAnimaisDeserialize = JsonConvert.DeserializeObject<List<Animal>>(listaAnimaisCadastradosNoBanco);

            var animalParaAgenda = listaAnimaisDeserialize.FirstOrDefault(x => x.NomeAnimal == agendamento.Animal.NomeAnimal);

            var agendamentoDoBanco = await _httpClient.GetStringAsync(endPoint + $"/{agendamento.AgendamentoId}");
            var agendamentoDeserialize = JsonConvert.DeserializeObject<Agendamento>(agendamentoDoBanco);

            var veterinarioDoBanco = await _httpClient.GetStringAsync("https://localhost:7018/api/Veterinario/" + $"{agendamento.VeterinarioId}");
            var veterinarioDeserialize = JsonConvert.DeserializeObject<Veterinario>(veterinarioDoBanco);

            var agendamentoParaSerPersistido = new Agendamento
            {
                AgendamentoId = agendamentoDeserialize.AgendamentoId,
                AnimalId = animalParaAgenda.AnimalId,
                DataCadastro = DateTime.Now,
                Disponivel = false,
                VeterinarioId = veterinarioDeserialize.VeterinarioId,
                Animal = animalParaAgenda, 
                DataConsulta = agendamentoDeserialize.DataConsulta,
                Veterinario = veterinarioDeserialize,
                VeterinarioGeriatrico = veterinarioDeserialize.Geriatria,
                VeterinarioNome = veterinarioDeserialize.NomeVeterinario,
            };

            var response = await _httpClient.PostAsJsonAsync(endPoint, agendamentoParaSerPersistido);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return View("/Views/Agendamento/AnimalGeriatricoErro.cshtml");
            }
            
            return View("/Views/Agendamento/Agendado.cshtml");
        }
    }
}
