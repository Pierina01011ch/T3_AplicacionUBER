using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionUber
{
    internal class Carro
    {
        public string Placa { get; set; }
        public string Color { get; set; }
        public string Tipo { get; set; }
        public double Solesxmin { get; set; }
        public int Vertice { get; set; }
        public Carro()
        {
            Placa = "";
            Color = "";
            Tipo = "";
            Solesxmin = 0;
            Vertice = -1;
        }
        public void Mostrar()
        {
            Console.WriteLine($"Placa: {Placa}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Tipo: {Tipo}");
            if (Tipo.ToUpper() == "TAXI") {
                Console.WriteLine($"SolesxMin: {Solesxmin}");
                Console.WriteLine($"Vértice: {Vertice}");
            }
            Console.WriteLine();
        }
    }
}
