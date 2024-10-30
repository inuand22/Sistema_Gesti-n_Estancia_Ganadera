using Microsoft.AspNetCore.Mvc;
using Obligatorio.Dominio;

namespace WebApp.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
