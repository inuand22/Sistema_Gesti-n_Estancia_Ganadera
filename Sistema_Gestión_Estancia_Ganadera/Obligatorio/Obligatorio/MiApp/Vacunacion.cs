using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Dominio
{
    public class Vacunacion : IValido
    {
        public Vacuna MyVacuna { get; set; }
        public DateTime VacunaFecha { get; set; }
        public Ganado MyGanado { get; set; }
        public Vacunacion()
        {
            MyVacuna = null;
            VacunaFecha = new DateTime(0000, 00, 00);

            MyGanado = null;
        }
        public Vacunacion(Ganado myGanado, Vacuna myVacuna, DateTime vacunaFecha)
        {
            MyGanado = myGanado;
            MyVacuna = myVacuna;
            VacunaFecha = vacunaFecha;
        }
        public DateTime GetFechaVencimiento()
        {
            return VacunaFecha.AddYears(1);
        }
        public bool EsVacunable()
        {
            bool result = false;
            int año = DateTime.Now.Year;
            int mes = DateTime.Now.Month;
            if (año - MyGanado.FechaNacimiento.Year < 1)
            {
                if (mes - MyGanado.FechaNacimiento.Month < 3)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            else
            {
                result = true;
            }
            return result;
        }
        public void Validar()
        {
            if (MyGanado == null || MyVacuna == null)
            {
                throw new Exception("Todos los campos son obligatorios");
            }
        }
        public override string ToString()
        {
            return $"Vacunamos al ganado de número de caravana: {MyGanado.NumCaravana}. Con la vacuna{MyVacuna.Nombre}. " +
                $"Siendo hoy: {VacunaFecha.Date}. La misma vence el: {GetFechaVencimiento()}";
        }
    }
}
