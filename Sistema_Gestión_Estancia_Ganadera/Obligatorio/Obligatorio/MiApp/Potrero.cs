using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Dominio
{
    public class Potrero : IComparable<Potrero>
    {
        public static int UltimoID { get; set; } = 1;
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public int Hectareas { get; set; }
        public int CapacidadMaxAnimales { get; set; }
        public List<Ganado> _ListaGanadosEnPotrero { get; set; }
        public double PotencialPrecioVenta { get; set; } = 0;
        public Potrero()
        {
            ID = UltimoID++;
            Descripcion = "";
            Hectareas = 1;
            CapacidadMaxAnimales = 0;
            PotencialPrecioVenta = 0;
        }
        public Potrero(string descripcion, int hectareas, int capacidadMaxAnimales, List<Ganado> _listaganadosenpotrero)
        {
            ID = UltimoID;
            UltimoID++;
            Descripcion = descripcion;
            Hectareas = hectareas;
            CapacidadMaxAnimales = capacidadMaxAnimales;
            _ListaGanadosEnPotrero = _listaganadosenpotrero;
            PotencialPrecioVenta = 0;
        }
        public override string ToString()
        {
            return $"Este potrero cuenta con {Hectareas} de hectareas. Con una capacidad máxima de {CapacidadMaxAnimales} de animales." +
                $"Es el potero número: {ID}";
        }
        public int CompareTo(Potrero? potrero)
        {
            int retorno;
            retorno = CapacidadMaxAnimales.CompareTo(potrero.CapacidadMaxAnimales);
            if (retorno == 0)
            {
                retorno = _ListaGanadosEnPotrero.Count.CompareTo(potrero._ListaGanadosEnPotrero.Count) * -1;
            }
            return retorno;
        }
    }
}
