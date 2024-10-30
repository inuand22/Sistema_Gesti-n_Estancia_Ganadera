using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Dominio
{
    public class Ovino : Ganado
    {
        public static double PesoEstimadoLana { get; set; } = 160;
        public static double PrecioKGLana { get; set; } = 110;
        public static double PrecioKGOvinoPie { get; set; } = 150;
        public Ovino()
        {
            NumCaravana = 00000000;
            EsMacho = false;
            Raza = "";
            FechaNacimiento = new DateTime(0000, 00, 00);
            CostoAdquisicion = 0;
            CostoAlimentacion = 0;
            PesoActual = 0;
            EsHibrido = false;
            GananciaVentaIndividual = 0;
        }
        public Ovino(int numCaravana, bool esMacho, string raza, DateTime fechaNacimiento,
            double costoAdquisicion, double costoAlimentacion, double pesoActual,
            bool esHibrido)
        {
            NumCaravana = numCaravana;
            EsMacho = esMacho;
            Raza = raza;
            FechaNacimiento = fechaNacimiento;
            CostoAdquisicion = costoAdquisicion;
            CostoAlimentacion = costoAlimentacion;
            PesoActual = pesoActual;
            EsHibrido = esHibrido;
            GananciaVentaIndividual = 0;
        }
        public override double PotencialPrecioGanado()
        {
            double aux = 0;
            aux = PesoEstimadoLana * PrecioKGLana + PesoActual * PrecioKGOvinoPie;
            if (EsHibrido)
            {
                aux = aux * 0.95;
            }

            return aux;
        }
    }
}

