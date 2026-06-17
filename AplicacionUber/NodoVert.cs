using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionUber
{
    internal class NodoVert
    {
        public int Id { get; set; }
        public ListaAdy Adyac { get; set; }
        public NodoVert Siguiente { get; set; }
        public NodoVert(int id)
        {
            Id = id;
            Adyac = new ListaAdy();
            Siguiente = null;
        }
    }
}
