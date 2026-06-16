using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionUber
{
    internal class GrafoNDP
    {
        private ListaAdy[] lista;
        private int cantVertices;
        public GrafoNDP(int cantVertices)
        {
            this.cantVertices = cantVertices;
            lista = new ListaAdy[cantVertices];
            for (int i=0; i<cantVertices;i++)
            {
                lista[i] = new ListaAdy();
            }
        }
        public int ObtenerCantVertices()
        {
            return cantVertices;
        }
        public ListaAdy ObtenerLista(int vertice)
        {
            return lista[vertice];
        }
        public bool VerificarValido(int v)
        {
            return v >= 0 && v < cantVertices;
        }
        public bool HayArista(int origen, int destino)
        {
            return lista[origen].HayConexion(destino);
        }
        public void AgregarArista(int origen, int destino, double distanciaKm, int tiempoMin)
        {
            if (!VerificarValido(origen)||!VerificarValido(destino)) {
                Console.WriteLine("Vértices no válidos");
                return;
            }
            if (lista[origen].HayConexion(destino)) {
                Console.WriteLine("La arista ya existe");
                return;
            }
            lista[origen].Agregar(destino, distanciaKm, tiempoMin);
            lista[destino].Agregar(origen, distanciaKm, tiempoMin);
            Console.WriteLine("Arista añadida");
        }
        public void Mostrar()
        {
            for (int i=0; i<cantVertices;i++) {
                Console.Write($"Vértice {i}: ");
                lista[i].Mostrar();
            }
        }
        public void BuscarHastaNivel2(int origen, GestorCarros gestor)
        {
            if (!VerificarValido(origen))
            {
                Console.WriteLine("Vértice no válido");
                return;
            }
            bool[] visitado = new bool[cantVertices];
            visitado[origen] = true;
            Console.WriteLine("Nivel 0: ");
            gestor.MostrarTaxisEnVertice(origen);
            ListaAdy listaOrigen = lista[origen];
            NodoAdy actual = listaOrigen.ObtenerPrimero();

            while (actual!=null)
            {
                int vec = actual.Destino;
                if (!visitado[vec])
                {
                    visitado[vec] = true;
                    Console.WriteLine($"Nivel 1 - Vértice {vec}");
                    gestor.MostrarTaxisEnVertice(vec);
                    NodoAdy actual2 = lista[vec].ObtenerPrimero();

                    while (actual2!=null)
                    {
                        int vec2 = actual2.Destino;
                        if (!visitado[vec2])
                        {
                            visitado[vec2] = true;
                            Console.WriteLine($"Nivel 2 - Vértice {vec2}");
                            gestor.MostrarTaxisEnVertice(vec2);
                        }
                        actual2 = actual2.Siguiente;
                    }
                }
                actual = actual.Siguiente;
            }
        }
        public ResultadoRuta BuscarRuta3Niveles(int origen, int destino)
        {
            ResultadoRuta r = new ResultadoRuta();
            if (!VerificarValido(origen)||!VerificarValido(destino)) {
                return r;
            }
            NodoAdy directo = lista[origen].BuscarNodo(destino);

            if (directo != null)
            {
                r.Encontrado = true;
                r.DistanciaKm = directo.DistanciaKm;
                r.TiempoMin = directo.TiempoMin;

                return r;
            }

            NodoAdy actual1 = lista[origen].ObtenerPrimero();

            while (actual1 != null)
            {
                int v1 =
                    actual1.Destino;

                NodoAdy nivel2 = lista[v1].BuscarNodo(destino);

                if (nivel2 != null)
                {
                    r.Encontrado = true;
                    r.DistanciaKm = actual1.DistanciaKm + nivel2.DistanciaKm;
                    r.TiempoMin = actual1.TiempoMin + nivel2.TiempoMin;
                    return r;
                }

                NodoAdy actual2 = lista[v1].ObtenerPrimero();

                while (actual2 != null)
                {
                    int v2 = actual2.Destino;

                    NodoAdy nivel3 = lista[v2]
                        .BuscarNodo(destino);

                    if (nivel3 != null)
                    {
                        r.Encontrado = true;
                        r.DistanciaKm = actual1.DistanciaKm + actual2.DistanciaKm + nivel3.DistanciaKm;
                        r.TiempoMin = actual1.TiempoMin + actual2.TiempoMin + nivel3.TiempoMin;
                        return r;
                    }

                    actual2 = actual2.Siguiente;
                }
                actual1 = actual1.Siguiente;
            }
            return r;
        }
        public ResultadoRuta BuscarTaxiAlOrigen(int verticeTaxi, int origen)
        {
            ResultadoRuta r = new ResultadoRuta();

            if (!VerificarValido(verticeTaxi) || !VerificarValido(origen)) {
                return r;
            }

            NodoAdy direc = lista[verticeTaxi].BuscarNodo(origen);

            if (direc != null) {
                r.Encontrado = true;
                r.DistanciaKm = direc.DistanciaKm;
                r.TiempoMin = direc.TiempoMin;
                return r;
            }

            NodoAdy actual = lista[verticeTaxi].ObtenerPrimero();

            while (actual != null)
            {
                int vec = actual.Destino;

                NodoAdy nivel2 =
                    lista[vec]
                    .BuscarNodo(origen);

                if (nivel2 != null) {
                    r.Encontrado = true;
                    r.DistanciaKm = actual.DistanciaKm + nivel2.DistanciaKm;
                    r.TiempoMin = actual.TiempoMin + nivel2.TiempoMin;
                    return r;
                }
                actual = actual.Siguiente;
            }
            return r;
        }
    }
}
