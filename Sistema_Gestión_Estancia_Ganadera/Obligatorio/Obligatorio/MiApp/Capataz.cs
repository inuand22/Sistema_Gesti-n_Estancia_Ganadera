using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Dominio
{
    public class Capataz : Empleado
    {
        public int CantidadPersonasACargo { get; set; }
        public Capataz()
        {
            Id = UltimoId++;
            Email = "";
            Contraseña = "";
            Nombre = "";
            FechaIngreso = DateTime.Today;
            CantidadPersonasACargo = 0;
        }
        public Capataz(string email, string contraseña, string nombre, DateTime fechaIngreso, int cantidadPersonasACargo)
        {
            Id = UltimoId++;
            Email = email;
            Contraseña = contraseña;
            Nombre = nombre;
            FechaIngreso = fechaIngreso;
            CantidadPersonasACargo = cantidadPersonasACargo;
        }
    }
}
