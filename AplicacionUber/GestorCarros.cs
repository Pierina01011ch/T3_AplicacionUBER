using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionUber
{
    internal class GestorCarros
    {
        private Carro[] carros;
        private int cantidad;

        public GestorCarros(int capacidad)
        {
            carros = new Carro[capacidad];
            cantidad = 0;
        }
        public void AgregarCarro(int cantVertices)
        {
            if (cantidad>=carros.Length) {
                Console.WriteLine("No hay espacio");
                return;
            }
            Carro nuevo = new Carro();
            Console.Write("Placa: ");
            nuevo.Placa = Console.ReadLine();

            Console.Write("Color: ");
            nuevo.Color = Console.ReadLine();

            Console.Write("Tipo (Taxi/Particular): ");
            nuevo.Tipo = Console.ReadLine();

            if (nuevo.Tipo.ToUpper()=="TAXI")
            {
                Console.Write("SolesxMin: ");
                nuevo.Solesxmin = Convert.ToDouble(Console.ReadLine());
                Random rnd = new Random();
                nuevo.Vertice = rnd.Next(0, cantVertices);
            }
            else
            {
                nuevo.Solesxmin = 0;
                nuevo.Vertice = -1;
            }
            carros[cantidad] = nuevo;
            cantidad++;
            Console.WriteLine("Carro añadido correctamente");
        }
        public void ModificarTipoCarro(int cantVertices)
        {
            Console.Write("Placa a buscar: ");
            string placa = Console.ReadLine();

            for (int i=0;i<cantidad;i++)
            {
                if (carros[i].Placa == placa)
                {
                    Console.Write("Nuevo tipo (Taxi/Particular): ");
                    string tipo = Console.ReadLine();
                    carros[i].Tipo = tipo;
                    if (tipo.ToUpper() == "TAXI")
                    {
                        Console.Write("solesxmin: ");
                        carros[i].Solesxmin = Convert.ToDouble(Console.ReadLine());
                        Random rnd = new Random();
                        carros[i].Vertice = rnd.Next(0, cantVertices);
                    }
                    else
                    {
                        carros[i].Solesxmin = 0;
                        carros[i].Vertice = -1;
                    }
                    Console.WriteLine("Carro actualizado");
                    return;
                }
            }
            Console.WriteLine("Placa no encontrada");
        }
        public void MostrarCarros()
        {
            if (cantidad==0)
            {
                Console.WriteLine("No hay carros registrados");
                return;
            }
            for (int i=0; i<cantidad;i++)
            {
                Console.WriteLine($"Carro #{i+1}");
                carros[i].Mostrar();
            }
        }
        public void AsignarUbicaciones(int cantVertices)
        {
            Random rnd = new Random();
            for (int i=0; i<cantidad;i++)
            {
                if (carros[i].Tipo.ToUpper() == "TAXI")
                {
                    carros[i].Vertice = rnd.Next(0, cantVertices);
                }
            }
            Console.WriteLine("Ubicaciones asignadas");
        }
        public void MostrarTaxisEnVertice(int vertice)
        {
            for (int i=0;i<cantidad;i++)
            {
                if (carros[i].Tipo.ToUpper() == "TAXI" && carros[i].Vertice == vertice)
                    carros[i].Mostrar();
            }
        }
        public void MostrarTaxisDisponibles()
        {
            for(int i=0; i < cantidad; i++)
            {
                if (carros[i].Tipo.ToUpper() == "TAXI")
                {
                    Console.WriteLine($"[{i}] {carros[i].Placa} - " + $"Vértice {carros[i].Vertice}");
                }
            }
        }
        public int ObtenerCantidad()
        {
            return cantidad;
        }
        public Carro ObtenerCarro(int posic)
        {
            if (posic >= 0 && posic < cantidad)
            {
                return carros[posic];
            }
            return null;
        }
    }
}
