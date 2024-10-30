using Microsoft.AspNetCore.Mvc;
using Obligatorio.Dominio;
using System;
using System.Linq.Expressions;
using static System.Collections.Specialized.BitVector32;

namespace WebApp.Controllers
{
    public class EmpleadoController : Controller
    {
        Sistema sistema = Sistema.Instance();
        public IActionResult IngresoEmpleados()
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Inicio");
        }
        [HttpPost]
        public IActionResult IngresoEmpleados(string email, string contraseña)
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == null)
            {
                try
                {
                    Empleado empleadoLogueado = sistema.GetEmpleadoXEmailYContraseña(email, contraseña);
                    HttpContext.Session.SetString("rolEmpleadoLogueado", empleadoLogueado.GetType().Name);
                    HttpContext.Session.SetString("nombreEmpleadoLogueado", empleadoLogueado.Nombre);
                    HttpContext.Session.SetInt32("idEmpleadoLogueado", empleadoLogueado.Id);
                    if (empleadoLogueado is Peon)
                    {
                        return RedirectToAction("InicioPeon");
                    }
                    else
                    {
                        return RedirectToAction("InicioCapataz");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = ex.Message;
                }
                return View();
            }
            return RedirectToAction("Index", "Inicio");
        }

        public IActionResult Salir()
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Peon" || HttpContext.Session.GetString("rolEmpleadoLogueado") == "Capataz")
            {
                HttpContext.Session.Clear();
            }
            return RedirectToAction("Index", "Inicio");
        }

        public IActionResult EditPeon(int id)
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Peon")
            {
                Peon peonLogueado = (Peon)sistema.GetEmpleadoXId(id);
                return View(peonLogueado);
            }
            return RedirectToAction("Index", "Inicio");
        }
        [HttpPost]
        public IActionResult EditPeon(Peon pPeon)
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Peon")
            {
                try
                {
                    sistema.ActualizarPeon(pPeon);
                    ViewBag.Mensaje = "Actualización con éxito";
                    return View(pPeon);
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = ex.Message;
                }
                return View();
            }
            return RedirectToAction("Index", "Inicio");
        }

        public IActionResult RegistroPeon()
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Inicio");
        }
        [HttpPost]
        public IActionResult RegistroPeon(Peon pPeon)
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == null)
            {
                try
                {
                    sistema.AltaEmpleado(pPeon);
                    ViewBag.Mensaje = "Registro realizado con éxito!";
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = ex.Message;
                    return View();
                }
            }
            return RedirectToAction("Index", "Inicio");
        }

        public IActionResult InicioPeon()
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Peon")
            {
                int? idEmpleadoLogueado = HttpContext.Session.GetInt32("idEmpleadoLogueado");
                Peon peonLogueado = (Peon)sistema.GetEmpleadoXId(idEmpleadoLogueado);
                ViewBag.NombreEmpleado = peonLogueado.Nombre;
                ViewBag.EmailEmpleado = peonLogueado.Email;
                ViewBag.ContraseñaEmpleado = peonLogueado.Contraseña;
                ViewBag.FechaIngresoEmpleado = peonLogueado.FechaIngreso.ToShortDateString();
                ViewBag.EsResidente = peonLogueado.EsResidente;
                return View();
            }
            return RedirectToAction("Index", "Inicio");
        }

        public IActionResult InicioCapataz()
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Capataz")
            {
                int? idEmpleadoLogueado = HttpContext.Session.GetInt32("idEmpleadoLogueado");
                Capataz capatazLogueado = (Capataz)sistema.GetEmpleadoXId(idEmpleadoLogueado);
                ViewBag.NombreEmpleado = capatazLogueado.Nombre;
                ViewBag.EmailEmpleado = capatazLogueado.Email;
                ViewBag.ContraseñaEmpleado = capatazLogueado.Contraseña;
                ViewBag.FechaIngresoEmpleado = capatazLogueado.FechaIngreso.ToShortDateString();
                ViewBag.PersonasACargo = capatazLogueado.CantidadPersonasACargo;
                return View();
            }
            return RedirectToAction("Index", "Inicio");
        }
        public IActionResult EditCapataz(int id)
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Capataz")
            {
                Capataz capatazLogueado = (Capataz)sistema.GetEmpleadoXId(id);
                return View(capatazLogueado);
            }
            return RedirectToAction("Index", "Inicio");
        }
        [HttpPost]
        public IActionResult EditCapataz(Capataz pCapataz)
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Capataz")
            {
                try
                {
                    sistema.ActualizarCapataz(pCapataz);
                    ViewBag.Mensaje = "Actualización con éxito";
                    return View(pCapataz);
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = ex.Message;
                    return View();
                }
            }
            return RedirectToAction("Index", "Inicio");
        }
        public IActionResult ListaPeones()
        {
            if (HttpContext.Session.GetString("rolEmpleadoLogueado") == "Capataz")
            {
                return View(sistema.GetPeones());
            }
            return RedirectToAction("Index", "Inicio");
        }
        public IActionResult DarDeBaja(int idPeon)
        {
            sistema.DarDeBajaEmpleado(idPeon);
            return RedirectToAction("ListaPeones");
        }
    }
}

