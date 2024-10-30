using Obligatorio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Dominio
{
    public abstract class Empleado : IValido
    {
        public static int UltimoId { get; set; } = 1;
        public int Id { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public void Validar()
        {
            char aux;
            int valorAux = 0;
            string nuevoTexto;
            bool arroba = false;
            if (Contraseña == null || Email == null || Nombre == null)
            {
                throw new Exception("Todos los campos son obligatorios.");
            }
            if (FechaIngreso == DateTime.Today)
            {
                throw new Exception("Ingrese correctamente su fecha de ingreso.");
            }
            if (Contraseña.Length < 8)
            {
                throw new Exception("La Contraseña debe ser mayor a 8 carácteres.");
            }
            for (int i = 0; i < Email.Length; i++)
            {
                aux = Email[i];
                if (aux == '@')
                {
                    valorAux = i;
                    arroba = true;
                }
            }
            if (arroba == false)
            {
                throw new Exception("El email debe contener un dominio.");
            }
            nuevoTexto = Email.Substring(0, valorAux);
            if (nuevoTexto.Length < 8)
            {
                throw new Exception("El largo del Email debe ser de al menos 8 carácteres.");
            }
        }
        public override string ToString()
        {
            return $"{Nombre}";
        }
    }
}
