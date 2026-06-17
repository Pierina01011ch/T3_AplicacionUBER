using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionUber
{
    internal class ListaVert
    {
        private NodoVert primero;

        public ListaVert() {
            primero = null;
        }

        public void AgregarVertice(int id)
        {
            NodoVert nuevo =
                new NodoVert(id);

            if (primero == null) {
                primero = nuevo;
                return;
            }

            NodoVert actual = primero;

            while (actual.Siguiente != null) {
                actual = actual.Siguiente;
            }

            actual.Siguiente = nuevo;
        }

        public NodoVert BuscarVertice(int id)
        {
            NodoVert actual = primero;

            while (actual != null)
            {
                if (actual.Id == id) {
                    return actual;
                }

                actual = actual.Siguiente;
            }

            return null;
        }
        public NodoVert ObtenerPrimero() {
            return primero;
        }
    }
}
