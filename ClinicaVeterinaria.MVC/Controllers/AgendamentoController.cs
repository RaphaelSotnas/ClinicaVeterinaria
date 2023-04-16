using Microsoft.AspNetCore.Mvc;

namespace ClinicaVeterinaria.Web.Controllers
{
    public class AgendamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
