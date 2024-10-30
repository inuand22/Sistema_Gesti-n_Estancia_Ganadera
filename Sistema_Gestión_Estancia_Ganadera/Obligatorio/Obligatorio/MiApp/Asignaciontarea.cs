using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Dominio
{
    public class AsignacionTarea : IComparable<AsignacionTarea>
    {
        public Empleado MyEmpleado { get; set; }
        public Tarea Tarea { get; set; }
        public AsignacionTarea()
        {
            MyEmpleado = null;
            Tarea = null;
        }
        public AsignacionTarea(Empleado myEmpleado, Tarea tarea)
        {
            MyEmpleado = myEmpleado;
            Tarea = tarea;
        }
        public override string ToString()
        {
            return $"La tarea {Tarea.Descripcion} de ID: {Tarea.ID}. Fue Asignada a: {MyEmpleado.Nombre} de Email: {MyEmpleado.Email}";
        }
        public int CompareTo(AsignacionTarea? other)
        {
            return Tarea.FechaRealizacion.CompareTo(other.Tarea.FechaRealizacion);
        }
    }
}

