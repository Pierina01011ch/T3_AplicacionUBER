using AplicacionUber;

namespace AplicacionUber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GrafoNDP g = new GrafoNDP(10);
            GestorCarros gestor = new GestorCarros(50);
            int opcion;

            do
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("        APLICACIÓN UBER        ");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1. Agregar Carro");
                Console.WriteLine("2. Modificar Tipo");
                Console.WriteLine("3. Agregar Arista");
                Console.WriteLine("4. Asignar Ubicaciones a Taxis");
                Console.WriteLine("5. Buscar taxis cercanos");
                Console.WriteLine("6. Distancia entre 2 puntos");
                Console.WriteLine("7. Tomar Taxi");
                Console.WriteLine("8. Mostrar datos");
                Console.WriteLine("9. Fin");
                Console.Write("Seleccione una opción: ");

                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        gestor.AgregarCarro(g.ObtenerCantVertices());
                        break;
                    case 2:
                        gestor.ModificarTipoCarro(g.ObtenerCantVertices());
                        break;
                    case 3:
                        OpcionAgregarArista(g);
                        break;
                    case 4:
                        gestor.AsignarUbicaciones(g.ObtenerCantVertices());
                        break;
                    case 5:
                        Console.Write("Vértice - origen: ");
                        int origen = Convert.ToInt32(Console.ReadLine());
                        g.BuscarHastaNivel2(origen, gestor);
                        break;
                    case 6:
                        Console.Write("Origen: ");
                        int origenRuta = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Destino: ");
                        int destinoRuta = Convert.ToInt32(Console.ReadLine());

                        ResultadoRuta ruta = g.BuscarRuta3Niveles(origenRuta, destinoRuta);

                        if (ruta.Encontrado) {
                            Console.WriteLine($"Distancia Total: {ruta.DistanciaKm} km");
                            Console.WriteLine($"Tiempo Total: {ruta.TiempoMin} min");
                        }
                        else {
                            Console.WriteLine("No existe ruta hasta tercer nivel");
                        }
                        break;
                    case 7:
                        Console.Write("Origen: "); 
                        int origenViaje = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Destino: ");
                        int destinoViaje = Convert.ToInt32(Console.ReadLine());
                        ResultadoRuta viaje = g.BuscarRuta3Niveles(origenViaje, destinoViaje);

                        if (!viaje.Encontrado) {
                            Console.WriteLine("La carrera supera los 3 niveles");
                            break;
                        }

                        Console.WriteLine();
                        Console.WriteLine("------TAXIS CERCANOS------");

                        for (int i = 0; i < gestor.ObtenerCantidad(); i++)
                        {
                            Carro c = gestor.ObtenerCarro(i);

                            if (c.Tipo.ToUpper() == "TAXI")
                            {
                                ResultadoRuta llegada = g.BuscarTaxiAlOrigen(c.Vertice, origenViaje);

                                if (llegada.Encontrado)
                                {
                                    double costo = viaje.TiempoMin * c.Solesxmin;
                                    Console.WriteLine($"[{i}] {c.Placa}");
                                    Console.WriteLine($"Vertice: {c.Vertice}");
                                    Console.WriteLine($"Tiempo al origen: {llegada.TiempoMin} min");
                                    Console.WriteLine($"Tiempo carrera: {viaje.TiempoMin} min");
                                    Console.WriteLine($"Costo: S/. {costo}");
                                    Console.WriteLine();
                                }
                            }
                        }
                        Console.Write("Seleccione Taxi: ");

                        int posTaxi = Convert.ToInt32(Console.ReadLine());

                        Carro taxi = gestor.ObtenerCarro(posTaxi);

                        if (taxi == null) {
                            Console.WriteLine("Taxi no válido.");
                            break;
                        }

                        double monto = viaje.TiempoMin * taxi.Solesxmin;

                        Console.WriteLine();
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine($"Taxi: {taxi.Placa}");
                        Console.WriteLine($"Tiempo viaje: {viaje.TiempoMin} min");
                        Console.WriteLine($"Distancia: {viaje.DistanciaKm} km");
                        Console.WriteLine($"Monto total por Yape: S/. {monto}");
                        Console.WriteLine("----------------------------------");
                        break;
                    case 8:
                        Console.WriteLine("----CARROS----");
                        gestor.MostrarCarros();
                        Console.WriteLine("----GRAFO----");
                        g.Mostrar();
                        break;
                }
            } while (opcion != 9);
        }
        static void OpcionAgregarArista(GrafoNDP grafo)
        {
            Console.Write("Origen: ");
            int origen = Convert.ToInt32(Console.ReadLine());

            Console.Write("Destino: ");
            int destino = Convert.ToInt32(Console.ReadLine());

            Console.Write("Distancia (km): ");
            double distancia = Convert.ToDouble(Console.ReadLine());

            Console.Write("Tiempo (Minutos): ");
            int tiempo = Convert.ToInt32(Console.ReadLine());

            grafo.AgregarArista(origen, destino, distancia, tiempo);
        }
    }
}
