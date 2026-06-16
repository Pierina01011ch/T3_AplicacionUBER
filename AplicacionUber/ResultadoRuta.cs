using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionUber
{
    internal class ResultadoRuta
    {
        public bool Encontrado { get; set; }
        public double DistanciaKm { get; set; }
        public int TiempoMin { get; set; }
        public ResultadoRuta()
        {
            Encontrado = false;
            DistanciaKm = 0;
            TiempoMin = 0;
        }
    }
}
