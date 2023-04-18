using ClinicaVeterinaria.MVC.Models.Entidades;
using Newtonsoft.Json;

namespace ClinicaVeterinaria.Web.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;
        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public Cliente BuscarSessaoCliente()
        {
            string sessaoCliente = _httpContext.HttpContext.Session.GetString("sessaoClienteLogado");

            if (string.IsNullOrEmpty(sessaoCliente)) return null;

            return JsonConvert.DeserializeObject<Cliente>(sessaoCliente);
        }

        public void CriarSessaoCliente(Cliente cliente)
        {
            string valor = JsonConvert.SerializeObject(cliente);

            _httpContext.HttpContext.Session.SetString("sessaoClienteLogado", valor);
        }

        public void RemoverSessaoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoClienteLogado");
        }
    }
}
