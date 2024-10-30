using Obligatorio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Dominio
{
    public abstract class Ganado : IValido
    {
        public int NumCaravana { get; set; }
        public string Raza { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public double CostoAdquisicion { get; set; }
        public double CostoAlimentacion { get; set; }
        public double PesoActual { get; set; }
        public bool EsHibrido { get; set; }
        public bool EsMacho { get; set; }
        public double GananciaVentaIndividual { get; set; } = 0;
        public Ganado() { }
        public void Validar()
        {
            if (NumCaravana == null || Raza == null || FechaNacimiento == DateTime.Today || CostoAdquisicion == null || CostoAlimentacion == null ||
                PesoActual == null)
            {
                throw new Exception("Todos los campos son OBLIGATORIOS");
            }
            if (NumCaravana.ToString().Length != 8)
            {
                throw new Exception("Los dígitos del número de Caravana deben ser  8");
            }
            if (CostoAdquisicion == 0 || CostoAlimentacion == 0 || PesoActual == 0)
            {
                throw new Exception("Ingrese correctamente el valor solicitado.");
            }
        }
        public bool AnimalEsCria()
        {
            bool bandera = false;
            if (DateTime.Today.Year - FechaNacimiento.Year < 1)
            {
                bandera = true;
            }
            return bandera;
        }
        public abstract double PotencialPrecioGanado();

        public override string ToString()
        {
            return $"Sexo: {EsMacho}. Nació en el: {FechaNacimiento.Year} en el mes {FechaNacimiento.Month}. De raza: {Raza}." +
                $"Con un peso de: {PesoActual} Kgs. Su número de caravana es: {NumCaravana}";
        }
    }
}
