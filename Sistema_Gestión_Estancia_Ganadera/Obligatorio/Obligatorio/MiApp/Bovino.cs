using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Dominio
{
    public class Bovino : Ganado
    {
        public bool SeAlimentaPorGrano { get; set; }
        public static double PrecioKGBovinoPie { get; set; } = 160;
        public Bovino()
        {
            NumCaravana = 00000000;
            EsMacho = false;
            Raza = "";
            FechaNacimiento = DateTime.Today;
            CostoAdquisicion = 0;
            CostoAlimentacion = 0;
            PesoActual = 0;
            EsHibrido = false;
            SeAlimentaPorGrano = false;
            GananciaVentaIndividual = 0;

        }
        public Bovino(int numCaravana, bool esMacho, string raza, DateTime fechaNacimiento, double costoAdquisicion,
            double costoAlimentacion, double pesoActual, bool esHibrido, bool seAlimentaPorGrano)
        {
            NumCaravana = numCaravana;
            EsMacho = esMacho;
            Raza = raza;
            FechaNacimiento = fechaNacimiento;
            CostoAdquisicion = costoAdquisicion;
            CostoAlimentacion = costoAlimentacion;
            PesoActual = pesoActual;
            EsHibrido = esHibrido;
            SeAlimentaPorGrano = seAlimentaPorGrano;
            GananciaVentaIndividual = 0;
        }
        public override double PotencialPrecioGanado()
        {
            double aux = 0;
            aux = PesoActual * PrecioKGBovinoPie;
            if (SeAlimentaPorGrano == true)
            {
                aux = aux * 1.30;
            }
            if (EsMacho == false)
            {
                aux = aux * 1.10;
            }
            return aux;
        }
    }
}
