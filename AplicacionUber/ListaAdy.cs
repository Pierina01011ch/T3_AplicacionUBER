using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionUber
{
    internal class ListaAdy
    {
        private NodoAdy primero;
        public ListaAdy()
        {
            primero = null;
        }
        public NodoAdy ObtenerPrimero()
        {
            return primero;
        }
        public bool HayConexion(int destino)
        {
            NodoAdy actual = primero;
            while (actual!=null)
            {
                if (actual.Destino==destino)
                {
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }
        public void Agregar(int destino, double distanciaKm, int tiempoMin)
        {
            NodoAdy nuevo = new NodoAdy(destino, distanciaKm, tiempoMin);
            nuevo.Siguiente = primero;
            primero = nuevo;
        }
        public void Mostrar()
        {
            NodoAdy actual = primero;
            while (actual!=null)
            {
                Console.Write(
                    $"{actual.Destino} " +
                    $"({actual.DistanciaKm} km, " +
                    $"{actual.TiempoMin} min)");
                if (actual.Siguiente!=null) {
                    Console.Write(" ---> ");
                }

                actual = actual.Siguiente;
            }
            Console.WriteLine();
        }
        public NodoAdy BuscarNodo(int destino)
        {
            NodoAdy actual = primero;
            while (actual!=null)
            {
                if (actual.Destino == destino)
                {
                    return actual;
                }
                actual = actual.Siguiente;
            }
            return null;
        }
    }
}
