using ClinicaVeterinaria.MVC.Models.Entidades;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ClinicaVeterinaria.Web.Helpers
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContentAccessor;
        public Sessao(IHttpContextAccessor httpContextAccessor)
        {
            _httpContentAccessor = httpContextAccessor;
        }
        public void CriarSessaoCliente(Cliente Cliente)
        {
            string valor = JsonConvert.SerializeObject(Cliente);
            _httpContentAccessor.HttpContext.Session.SetString("sessaoClienteLogado", valor);
        }

        public Cliente BuscarSessaoCliente()
        {
            string sessaoCliente = _httpContentAccessor.HttpContext.Session.GetString("sessaoClienteLogado");

            if (string.IsNullOrEmpty(sessaoCliente)) return null;

            return JsonConvert.DeserializeObject<Cliente>(sessaoCliente);
        }

        public void RemoverSessaoCliente(Cliente Cliente)
        {
            _httpContentAccessor.HttpContext.Session.Remove("sessaoClienteLogado");
        }
    }
}
