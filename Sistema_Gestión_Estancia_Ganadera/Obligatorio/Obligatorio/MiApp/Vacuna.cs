using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Dominio
{
    public class Vacuna : IValido
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string AntiPatogeno { get; set; }
        public Vacuna()
        {
            Nombre = "";
            Descripcion = "";
            AntiPatogeno = "";
        }
        public Vacuna(string nombre, string descripcion, string antiPatogeno)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            AntiPatogeno = antiPatogeno;
        }
        public void Validar()
        {
            if (Nombre == null || Descripcion == null || AntiPatogeno == null)
            {
                throw new Exception("Todos los campos son obligatorios");
            }
        }
        public override string ToString()
        {
            return $"La vacuna: {Nombre}. La misma sirve para curar el {AntiPatogeno}";
        }
    }
}


