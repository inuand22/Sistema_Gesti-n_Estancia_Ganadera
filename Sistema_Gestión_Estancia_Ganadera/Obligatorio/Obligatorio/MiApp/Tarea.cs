using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Dominio
{
    public class Tarea : IValido
    {
        public static int UltimoID { get; set; } = 1;
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRealizacion { get; set; }
        public bool FueCompletada { get; set; }
        public DateTime FechaCierre { get; set; }
        public string Comentario { get; set; }
        public Tarea()
        {
            ID = UltimoID++;
            Descripcion = "";
            FechaRealizacion = DateTime.Today;
            FueCompletada = false;
            FechaCierre = DateTime.Today;
            Comentario = null;
        }
        public Tarea(string descripcion, DateTime fechaRealizacion, bool fueCompletada, DateTime fechaCierre, string comentario)
        {
            ID = UltimoID++;
            Descripcion = descripcion;
            FechaRealizacion = fechaRealizacion;
            FueCompletada = fueCompletada;
            FechaCierre = fechaCierre;
            Comentario = comentario;
        }
        public string FueTerminada()
        {
            if (FueCompletada)
            {
                return "si";
            }
            else
            {
                return "No";
            }
        }
        public void Validar()
        {
            if (Descripcion == null || FechaRealizacion == DateTime.Today || FechaCierre == DateTime.Today || Comentario == null)
            {
                throw new Exception("Campos Obligatorios.");
            }
        }
        public override string ToString()
        {
            return $"Tarea Número: {ID} - " +
                $"Descripción de la Tarea: {Descripcion} - Fecha de Realización: {FechaRealizacion}" +
                $" - La misma fue Compeltada?: {FueTerminada()} - Fecha de Cierre: {FechaCierre} - " +
                $" ¨Devolución del Peón: {Comentario}.";
        }
    }
}
