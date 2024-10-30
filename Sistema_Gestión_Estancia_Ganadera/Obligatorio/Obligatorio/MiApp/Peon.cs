using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Dominio
{
    public class Peon : Empleado
    {
        public bool EsResidente { get; set; }
        public Peon()
        {
            Id = UltimoId++;
            Email = "";
            Contraseña = "";
            Nombre = "";
            FechaIngreso = DateTime.Today;
            EsResidente = false;
        }
        public Peon(string email, string contraseña, string nombre, DateTime fechaIngreso, bool esResidente)
        {
            Id = UltimoId++;
            Email = email;
            Contraseña = contraseña;
            Nombre = nombre;
            FechaIngreso = fechaIngreso;
            EsResidente = esResidente;
        }
    }
}