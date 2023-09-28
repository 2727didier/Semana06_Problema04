using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana06_Problema04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int capacidadMaxima = 0;
            int asistentesActuales = 0;
            int totalAsistentes = 0;
            int totalSalidas = 0;
            int vecesLleno = 0;
            int vecesVacio = 0;
            bool localLleno = false;
            bool localVacio = true;
            List<int> historialAsistentes = new List<int>();
            List<int> historialSalidas = new List<int>();

            Console.WriteLine("Bienvenido al sistema de control de aforo de la tiendita de Don Mariano");
            Console.Write("Por favor, ingrese el número máximo de personas permitidas en el local: ");

            while (capacidadMaxima <= 0 || capacidadMaxima > 50)
            {
                if (int.TryParse(Console.ReadLine(), out capacidadMaxima) && capacidadMaxima > 0 && capacidadMaxima <= 50)
                {
                    Console.WriteLine($"\nEl número máximo establecido es de {capacidadMaxima} personas.");
                    Console.WriteLine("Presione una tecla para comenzar a contar.");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("\nIngrese un número válido entre 1 y 50.");
                    Console.Write("Por favor, ingrese el número máximo de personas permitidas en el local: ");
                }
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Aforo actual: {asistentesActuales} / {capacidadMaxima}");
                Console.WriteLine("Presione");
                Console.WriteLine("[ i ] si ingresa una persona");
                Console.WriteLine("[ s ] si sale una persona");
                Console.WriteLine("[ x ] para terminar");

                char opcion = Console.ReadKey().KeyChar;

                switch (opcion)
                {
                    case 'i':
                        if (asistentesActuales < capacidadMaxima)
                        {
                            asistentesActuales++;
                            totalAsistentes++;
                            historialAsistentes.Add(totalAsistentes);
                            localVacio = false;
                            if (asistentesActuales == capacidadMaxima)
                            {
                                localLleno = true;
                                vecesLleno++;
                            }
                            Console.WriteLine("\nUna persona ha entrado al local.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\nEl local está lleno. No se permite la entrada.");
                            Console.ReadKey();
                        }
                        break;

                    case 's':
                        if (asistentesActuales > 0)
                        {
                            asistentesActuales--;
                            totalSalidas++;
                            historialSalidas.Add(totalSalidas);
                            localLleno = false;
                            if (asistentesActuales == 0)
                            {
                                localVacio = true;
                                vecesVacio++;
                            }
                            Console.WriteLine("\nUna persona ha salido del local.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\nNo hay personas en el local para que salgan.");
                            Console.ReadKey();
                        }
                        break;

                    case 'x':
                        Console.Clear();
                        Console.WriteLine("Historial:");
                        Console.WriteLine($"Total de personas que asistieron: {totalAsistentes}");
                        Console.WriteLine($"Total de personas que salieron: {totalSalidas}");
                        Console.WriteLine($"Veces que el local estuvo lleno: {vecesLleno}");
                        Console.WriteLine($"Veces que el local estuvo vacío: {vecesVacio}");
                        Console.WriteLine("\nSaliendo del programa. ¡Gracias por usar el sistema de control de aforo!");
                        return;
                }
            }
        }
    }

}
    
