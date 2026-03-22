using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1CALAJACL
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //// -----Proyecto 1 Christian López y Andres Castillo-----

            /// Registro Inicial Del Sistema



            Console.WriteLine();
            Console.WriteLine("------- Bienvenido al sistema de registro ------");
            Console.WriteLine();

            string codigoTurno = "";
            string nombreOperador;

            Console.WriteLine("Ingrese el nombre del operador:");
            nombreOperador = Console.ReadLine();


            while (codigoTurno.Length != 4)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Ingrese el código de turno (4 caracteres): ");
                codigoTurno = Console.ReadLine();

                if (codigoTurno.Length != 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El código debe tener exactamente 4 caracteres.");
                    Console.ResetColor();
                }
            }

            int capacidad = 0;

            while (capacidad < 10)
            {
                Console.Write("Ingrese la capacidad del parqueo (mínimo 10): ");
                string entrada = Console.ReadLine();

                // Intentamos convertir el texto a número
                if (int.TryParse(entrada, out capacidad))
                {
                    if (capacidad < 10)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: La capacidad debe ser al menos 10.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Por favor, ingrese un número entero válido.");
                    Console.ResetColor();
                }
            }

            ///----------- Iniciación ------------///

            int ticketsCreados = 0;
            int ticketsCerrados = 0;
            double totalRecaudado = 0.0;
            int tiempoSimulado = 0;
            bool hayTicketActivo = false;


            //------ Menú Interactivo -------//

            string opcion = "";

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("--- MENÚ Parqueo ---");
                Console.ResetColor();

                Console.WriteLine("A. Crear Ticket de Entrada");
                Console.WriteLine("B. Registrar Salida y Cobro");
                Console.WriteLine("C. Ver Estado del Parqueo");
                Console.WriteLine("D. Simular Paso del Tiempo");
                Console.WriteLine("E. Salir");

                Console.Write("\nSeleccione una opción: ");
                opcion = Console.ReadLine().ToUpper();



            } while (opcion != "E");


            switch (opcion)
            {

                case "A":

                    string placa = "";
                    while (placa.Length < 6 || placa.Length > 8)
                    {
                        Console.Write("Ingrese la placa (6-8 caracteres): ");
                        placa = Console.ReadLine();

                        if (placa.Length < 6 || placa.Length > 8)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: La placa debe tener entre 6 y 8 caracteres.");
                            Console.ResetColor();
                        }
                    }
                    string placaIngresada = "";
                    while (placaIngresada.Length < 6 || placaIngresada.Length > 8)
                    {
                        Console.Write("Ingrese la placa (6-8 caracteres): ");
                        placaIngresada = Console.ReadLine();
                        if (placaIngresada.Length < 6 || placaIngresada.Length > 8)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: La placa debe tener entre 6 y 8 caracteres.");
                            Console.ResetColor();
                        }
                    }

                    // Validar Tipo de Vehículo
                    int tipoSeleccionado = 0;
                    while (tipoSeleccionado < 1 || tipoSeleccionado > 3)
                    {
                        Console.Write("Tipo (1=Moto, 2=Auto, 3=Pickup): ");
                        int.TryParse(Console.ReadLine(), out tipoSeleccionado);
                        if (tipoSeleccionado < 1 || tipoSeleccionado > 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: Seleccione una opción válida (1, 2 o 3).");
                            Console.ResetColor();
                        }
                    }

                    Console.Write("Nombre del cliente: ");
                    string nombreCliente = Console.ReadLine();
                    break;

                case "B":
                    if (!hayTicketActivo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No hay tickets activos para registrar salida.");
                        Console.ResetColor();
                    }
                    else
                    {
                        // Lógica para registrar salida y cobro
                    }

                    break;

                case "C":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n--- ESTADO GENERAL DEL PARQUEO ---");
                    Console.ResetColor();

                    // Lógica para espacios ocupados (basada en el ticket activo)
                    int ocupados = hayTicketActivo ? 1 : 0;
                    int disponibles = capacidad - ocupados;

                    Console.WriteLine($"Capacidad Total: {capacidad}");
                    Console.WriteLine($"Espacios Ocupados: {ocupados}");
                    Console.WriteLine($"Espacios Disponibles: {disponibles}");
                    Console.WriteLine($"Tiempo Simulado: {tiempoSimulado} minutos");

                    // El formato :C2 o :F2 ayuda a mostrar el dinero con dos decimales
                    Console.WriteLine($"Total Recaudado: Q{totalRecaudado:F2}");
                    Console.WriteLine($"Tickets Creados: {ticketsCreados}");
                    Console.WriteLine($"Tickets Cerrados: {ticketsCerrados}");

                    Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                    Console.ReadKey(); // Pausa para que el usuario pueda leer los datos
                    break;

                case "D":

                    int minutosASumar = 0;
                    bool entradaValida = false;

                    while (!entradaValida)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Ingrese los minutos a simular (1 a 1440): ");
                        string entrada = Console.ReadLine();

                        // Validamos que sea un número y que esté en el rango
                        if (int.TryParse(entrada, out minutosASumar) && minutosASumar >= 1 && minutosASumar <= 1440)
                        {
                            entradaValida = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: Debe ingresar un número entero entre 1 y 1440.");
                            Console.ResetColor();
                        }
                    }

                    // Actualizamos el tiempo acumulado
                    tiempoSimulado += minutosASumar;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Se han sumado {minutosASumar} minutos exitosamente.");
                    Console.WriteLine($"Tiempo total en el sistema: {tiempoSimulado} minutos.");
                    Console.ResetColor();

                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}