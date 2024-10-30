using Microsoft.AspNetCore.Mvc;
using Obligatorio.Dominio;

namespace WebApp.Controllers
{
    public class PotreroController : Controller
    {
        Sistema sistema = Sistema.Instance();
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Capataz")
            {
                ViewBag.Potreros = sistema.GetPotreros();
                return View(sistema.GetGanadoAlAireLibre());
            }
            return RedirectToAction("Index", "Inicio");
        }
        [HttpPost]
        public IActionResult Index(int idPotrero, int numCaravana)
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Capataz")
            {
                Ganado pGanado = sistema.GetGanadoXNumCaravana(numCaravana);
                Potrero potreroAMover = sistema.GetPotreroXId(idPotrero);
                ViewBag.Potreros = sistema.GetPotreros();
                try
                {
                    sistema.MoverGanadoLibreAPotrero(potreroAMover, pGanado);
                    ViewBag.Mensaje = "Animal movido con éxito";
                    return View(sistema.GetGanadoAlAireLibre());
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = ex.Message;
                    return View();
                }
            }
            return RedirectToAction("Index", "Inicio");
        }
        public IActionResult ListaPotreros()
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Capataz")
            {
                sistema.SetGananciaPorPotrero();
                List<Potrero> listPotreros = new List<Potrero>();
                listPotreros = sistema.GetPotreros();                
                listPotreros.Sort();
                return View(listPotreros);
            }
            return RedirectToAction("Index", "Inicio");
        }
    }
}
