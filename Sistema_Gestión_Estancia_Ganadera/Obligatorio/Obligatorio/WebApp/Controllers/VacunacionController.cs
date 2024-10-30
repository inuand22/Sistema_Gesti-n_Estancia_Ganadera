using Microsoft.AspNetCore.Mvc;
using Obligatorio.Dominio;

namespace WebApp.Controllers
{
    public class VacunacionController : Controller
    {
        Sistema sistema = Sistema.Instance();

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Peon")
            {
                ViewBag.Ganados = sistema.GetGanados();
                return View();
            }
            return RedirectToAction("Index", "Inicio");
        }
        [HttpPost]
        public IActionResult Index(int numCaravana, string nombreVacuna)
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Peon")
            {
                ViewBag.Ganados = sistema.GetGanados();
                Ganado ganadoPorVacunar = sistema.GetGanadoXNumCaravana(numCaravana);
                if (ganadoPorVacunar == null)
                {
                    ViewBag.Mensaje = "Número de caravana incorrecto";
                }
                Vacuna vacunaPorUsar = sistema.GetVacunaXNombreVacuna(nombreVacuna);
                Vacunacion vacunacionPorRealizar = new Vacunacion(ganadoPorVacunar, vacunaPorUsar, DateTime.Today);
                try
                {
                    sistema.AltaVacunacion(vacunacionPorRealizar);
                    ViewBag.Mensaje = "Vacunación registrada con ÉXITO!";
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = ex.Message;
                }
                return View();
            }
            return RedirectToAction("Index", "Inicio");
        }
    }
}
