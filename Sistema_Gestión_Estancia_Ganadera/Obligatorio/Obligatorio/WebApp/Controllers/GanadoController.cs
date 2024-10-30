using Microsoft.AspNetCore.Mvc;
using Obligatorio.Dominio;

namespace WebApp.Controllers
{
    public class GanadoController : Controller
    {
        Sistema sistema = Sistema.Instance();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RegistrarNuevoBovino()
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Capataz")
            {
                return View();
            }

            return RedirectToAction("Index", "Inicio");
        }
        [HttpPost]
        public IActionResult RegistrarNuevoBovino(Bovino pBovino)
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Capataz")
            {
                try
                {
                    sistema.AltaGanado(pBovino);
                    sistema.AsignarPotreroAAltaGanado(pBovino);
                    ViewBag.Mensaje = "Animal Registrado con éxito!";
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = ex.Message;
                }
                return View();
            }
            return RedirectToAction("Index", "Inicio");
        }
        public IActionResult MostrarAnimal()
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Capataz")
            {
                return View();
            }
            return RedirectToAction("Index", "Inicio");
        }
        [HttpPost]
        public IActionResult MostrarAnimal(string tipoAnimal, int pesoGanado)
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Capataz")
            {
                sistema.SetGananciaPorGanado();
                TempData["pesoGanado"] = pesoGanado;
                if (tipoAnimal == "Bovino")
                {
                    return RedirectToAction("MostrarBovinos");
                }
                else
                {
                    return RedirectToAction("MostrarOvinos");
                }
            }
            return RedirectToAction("Index", "Inicio");
        }
       
        public IActionResult MostrarBovinos()
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Capataz")
            {
                int? pesoGanado = TempData["pesoGanado"] as int?;
                return View(sistema.GetBovinosXPeso(pesoGanado));
            }
            return RedirectToAction("Index", "Inicio");
        }

        public IActionResult MostrarOvinos()
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Capataz")
            {
                int? pesoGanado = TempData["pesoGanado"] as int?;
                return View(sistema.GetOvinosXPeso(pesoGanado));
            }
            return RedirectToAction("Index", "Inicio");
        }
    }
}
