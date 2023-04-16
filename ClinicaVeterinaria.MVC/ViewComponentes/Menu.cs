using ClinicaVeterinaria.MVC.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClinicaVeterinaria.Web.ViewComponentes
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoClienteLogado = HttpContext.Session.GetString("sessaoClienteLogado");

            if (string.IsNullOrWhiteSpace(sessaoClienteLogado)) return View("/Views/Cliente/FormCadastro.cshtml");

            Cliente cliente = JsonConvert.DeserializeObject<Cliente>(sessaoClienteLogado); 

            return View("/Views/Shared/Componentes/Menu/Default.cshtml");
        }
    }
}
