using Microsoft.AspNetCore.Mvc;
using Obligatorio.Dominio;

namespace WebApp.Controllers
{
    public class TareasController : Controller
    {
        Sistema sistema = Sistema.Instance();
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Peon")
            {
                int? idLogueado = HttpContext.Session.GetInt32("idEmpleadoLogueado");
                Peon peonLogueado = (Peon)sistema.GetEmpleadoXId(idLogueado);
                return View(sistema.GetTareasNoRealizadasXPeon(peonLogueado));
            }
            return RedirectToAction("Index", "Inicio");
        }

        public IActionResult CompletarTarea()
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Peon")
            {
                int? idLogueado = HttpContext.Session.GetInt32("idEmpleadoLogueado");
                Peon peonLogueado = (Peon)sistema.GetEmpleadoXId(idLogueado);
                ViewBag.AsignacionTareas = sistema.GetTareasNoRealizadasXPeon(peonLogueado);
                return View();
            }
            return RedirectToAction("Index", "Inicio");
        }
        [HttpPost]
        public IActionResult CompletarTarea(int idTarea, string pComentario)
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Peon")
            {
                int? idLogueado = HttpContext.Session.GetInt32("idEmpleadoLogueado");
                Peon peonLogueado = (Peon)sistema.GetEmpleadoXId(idLogueado);
                AsignacionTarea tareaAcompletar = sistema.GetAsignacionTareaPorPeon(idLogueado, idTarea);
                ViewBag.AsignacionTareas = sistema.GetTareasNoRealizadasXPeon(peonLogueado);
                try
                {
                    sistema.CompletarAsignacionTarea(tareaAcompletar, pComentario);
                    ViewBag.Mensaje = "Tarea Finalizada con éxito";
                    ViewBag.AsignacionTareas = sistema.GetTareasNoRealizadasXPeon(peonLogueado);
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = ex.Message + " - Verifique Tarea Seleccionada - ";
                }
                return View();
            }
            return RedirectToAction("Index", "Inicio");
        }
        public IActionResult ListaTareasPeon(int idPeon)
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Capataz")
            {
                return View(sistema.GetAsignacionTareasXIdPeon(idPeon));
            }
            return RedirectToAction("Index", "Inicio");
        }

        public IActionResult AsignarTarea(int idPeon)
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Capataz")
            {
                TempData["idPeon"] = idPeon;
                return View();
            }
            return RedirectToAction("Index", "Inicio");
        }
        [HttpPost]
        public IActionResult AsignarTarea(Tarea pTarea)
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Capataz")
            {
                int? idPeon = TempData["idPeon"] as int?;
                try
                {
                    sistema.AltaTarea(pTarea);
                    Peon _peon = (Peon)sistema.GetEmpleadoXId(idPeon);
                    AsignacionTarea _asignacionTarea = new AsignacionTarea(_peon, pTarea);
                    sistema.AltaAsignacionTarea(_asignacionTarea);
                    ViewBag.Mensaje = "Tarea Agregada a peón con éxito!";
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
