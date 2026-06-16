using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionUber
{
    internal class NodoAdy
    {
        public int Destino { get; set; }
        public double DistanciaKm { get; set; }
        public int TiempoMin { get; set; }
        public NodoAdy Siguiente { get; set; }
        public NodoAdy(int destino, double distanciaKm, int tiempoMin)
        {
            Destino = destino;
            DistanciaKm = distanciaKm;
            TiempoMin = tiempoMin;
            Siguiente = null;
        }
    }
}
