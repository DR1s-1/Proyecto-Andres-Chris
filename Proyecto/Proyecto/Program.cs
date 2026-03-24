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
            Console.WriteLine("=====================================");
            Console.WriteLine("BIENVENIDO AL SISTEMA DE PARQUEO");
            Console.WriteLine("=====================================");
            Console.WriteLine();

            string codigoTurno = ""; //Variables para validar entrada del operador
            string nombreOperador;

            Console.Write("Ingrese el nombre del operador: ");
            nombreOperador = Console.ReadLine();

            // Validar código de turno (4 caracteres)
            while (codigoTurno.Length != 4)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Ingrese el código de turno (4 caracteres): ");
                codigoTurno = Console.ReadLine().ToUpper();

                if (codigoTurno.Length != 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El código debe tener exactamente 4 caracteres.");
                    Console.ResetColor();
                }
            }

            // Validar capacidad
            int capacidad = 0;
            while (capacidad < 10)
            {
                Console.Write("Ingrese la capacidad del parqueo (mínimo 10): ");
                string entrada = Console.ReadLine();

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
                    Console.WriteLine("Error: Ingrese un número entero válido.");
                    Console.ResetColor();
                }
            }

            ///----------- Variables del Sistema (SOLO 1 TICKET ACTIVO) ------------///
            int ticketsCreados = 0;
            int ticketsCerrados = 0;
            double totalRecaudado = 0.0;
            int tiempoSimulado = 0;
            int espaciosOcupados = 0;

            // VARIABLES DEL ÚNICO TICKET ACTIVO
            bool hayTicketActivo = false;
            string placaActiva = "";
            int tipoActivo = 0; // 1=Moto, 2=Auto, 3=Pickup
            string nombreClienteActivo = "";
            int minutoEntrada = 0;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Sistema iniciado - Operador: {nombreOperador} | Turno: {codigoTurno}");
            Console.WriteLine($"Capacidad configurada: {capacidad} espacios");
            Console.ResetColor();

            //------ Menú Interactivo PRINCIPAL -------//
            string opcion = "";
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=====================================");
                Console.WriteLine("           MENÚ PARQUEO");
                Console.WriteLine($"Operador: {nombreOperador} | Turno: {codigoTurno}");
                Console.WriteLine("=====================================");
                Console.ResetColor();

                Console.WriteLine("A. Crear Ticket de Entrada");
                Console.WriteLine("B. Registrar Salida y Cobro");
                Console.WriteLine("C. Ver Estado del Parqueo");
                Console.WriteLine("D. Simular Paso del Tiempo");
                Console.WriteLine("E. Salir");
                Console.WriteLine("=====================================");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine().ToUpper();

                switch (opcion)
                {
                    case "A":
                        // Verificar espacio disponible Y que no haya ticket activo
                        if (espaciosOcupados >= capacidad)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("¡PARQUEO LLENO!");
                            Console.WriteLine("   No se pueden crear más tickets.");
                            Console.ResetColor();
                        }
                        else if (hayTicketActivo)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("¡YA HAY UN TICKET ACTIVO!");
                            Console.WriteLine("   Registre la salida primero (opción B).");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("--- DATOS DEL VEHÍCULO ---");

                            // Validar placa
                            string placa = "";
                            while (placa.Length < 6 || placa.Length > 8)
                            {
                                Console.Write("Placa (6-8 caracteres): ");
                                placa = Console.ReadLine().ToUpper();

                                if (placa.Length < 6 || placa.Length > 8)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("La placa debe tener 6-8 caracteres.");
                                    Console.ResetColor();
                                }
                            }

                            // Validar tipo de vehículo (SIN ARREGLOS)
                            int tipoSeleccionado = 0;
                            while (tipoSeleccionado < 1 || tipoSeleccionado > 3)
                            {
                                Console.Write("Tipo (1= Moto, 2= Auto, 3= Pickup): ");
                                string tipoInput = Console.ReadLine();
                                if (int.TryParse(tipoInput, out tipoSeleccionado))
                                {
                                    if (tipoSeleccionado < 1 || tipoSeleccionado > 3)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Seleccione 1, 2 o 3.");
                                        Console.ResetColor();
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Ingrese un número válido.");
                                    Console.ResetColor();
                                }
                            }

                            Console.Write("Nombre del cliente: ");
                            string nombreCliente = Console.ReadLine();

                            // GUARDAR DATOS DEL TICKET ACTIVO
                            placaActiva = placa;
                            tipoActivo = tipoSeleccionado;
                            nombreClienteActivo = nombreCliente;
                            minutoEntrada = tiempoSimulado;
                            hayTicketActivo = true;

                            ticketsCreados++;
                            espaciosOcupados++;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("TICKET CREADO EXITOSAMENTE");
                            Console.WriteLine($"   #{ticketsCreados} | Placa: {placa}");
                            string tipoTexto = tipoSeleccionado == 1 ? "Moto" : tipoSeleccionado == 2 ? "Auto" : "Pickup";
                            Console.WriteLine($"   Tipo: {tipoTexto}");
                            Console.WriteLine($"   Cliente: {nombreCliente}");
                            Console.WriteLine($"   Hora entrada: {tiempoSimulado} min");
                            Console.ResetColor();
                        }
                        break;

                    case "B":
                        if (!hayTicketActivo)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No hay vehículos en el parqueo.");
                            Console.WriteLine("   Cree tickets primero (opción A).");
                            Console.ResetColor();
                        }
                        else
                        {
                            // CÁLCULO DE COBRO CORRECTO según REGLAS DE NEGOCIO
                            int minutosEstacionado = tiempoSimulado - minutoEntrada;

                            // Gratuidad primeros 15 minutos
                            if (minutosEstacionado <= 15)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("¡SALIDA GRATUITA!");
                                Console.WriteLine($"   Placa: {placaActiva} | Cliente: {nombreClienteActivo}");
                                Console.WriteLine($"   Tiempo: {minutosEstacionado} min (≤15 min = GRATIS)");
                                Console.ResetColor();
                            }
                            else
                            {
                                // Calcular horas reales (redondeo hacia arriba)
                                double horas = Math.Ceiling((double)minutosEstacionado / 60);

                                //  Tarifa por tipo de vehículo
                                double tarifaPorHora = tipoActivo == 1 ? 5.0 : tipoActivo == 2 ? 10.0 : 15.0;
                                double cobroBase = horas * tarifaPorHora;

                                //  Multa por exceder 6 horas
                                double cobroFinal = cobroBase;
                                bool aplicaMulta = horas > 6;
                                if (aplicaMulta)
                                {
                                    cobroFinal += 25.0;
                                }

                                //  Descuento VIP (nombre contiene "VIP")
                                bool esVIP = nombreClienteActivo.ToUpper().Contains("VIP");
                                if (esVIP)
                                {
                                    double descuento = cobroFinal * 0.10;
                                    cobroFinal -= descuento;
                                }

                                totalRecaudado += cobroFinal;
                                ticketsCerrados++;

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("SALIDA REGISTRADA!");
                                string tipoTexto = tipoActivo == 1 ? "Moto" : tipoActivo == 2 ? "Auto" : "Pickup";
                                Console.WriteLine($"   Placa: {placaActiva} | {tipoTexto} | {nombreClienteActivo}");
                                Console.WriteLine($"   Tiempo: {minutosEstacionado} min ({horas:F0}h)");
                                Console.WriteLine($"   Tarifa base: Q{cobroBase:F2}");
                                if (aplicaMulta) Console.WriteLine("   + Multa (6h+): Q25.00");
                                if (esVIP) Console.WriteLine("   - Descuento VIP: 10%");
                                Console.WriteLine($"   TOTAL: Q{cobroFinal:F2}");
                                Console.WriteLine($"   Recaudado total: Q{totalRecaudado:F2}");
                                Console.ResetColor();
                            }

                            // LIMPIAR TICKET ACTIVO
                            hayTicketActivo = false;
                            espaciosOcupados--;
                        }
                        break;

                    case "C":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("--- ESTADO GENERAL DEL PARQUEO ---");
                        Console.WriteLine("=====================================");
                        Console.ResetColor();

                        int espaciosDisponibles = capacidad - espaciosOcupados;
                        Console.WriteLine($"Total Recaudado: Q{totalRecaudado:F2}");
                        Console.WriteLine($"Tickets Creados: {ticketsCreados}");
                        Console.WriteLine($"Tickets Cerrados: {ticketsCerrados}");
                        Console.WriteLine($"Tiempo Simulado: {tiempoSimulado} minutos");
                        Console.WriteLine($"Capacidad Total: {capacidad}");
                        Console.WriteLine($"Espacios Ocupados: {espaciosOcupados}");
                        Console.WriteLine($"Espacios Disponibles: {espaciosDisponibles}");
                        Console.WriteLine($"Ocupación: {(double)espaciosOcupados / capacidad * 100:F1}%");

                        if (hayTicketActivo)
                        {
                            Console.WriteLine("--- TICKET ACTIVO ---");
                            string tipoTexto = tipoActivo == 1 ? "Moto" : tipoActivo == 2 ? "Auto" : "Pickup";
                            Console.WriteLine($"Placa: {placaActiva} | {tipoTexto} | {nombreClienteActivo}");
                            Console.WriteLine($"Entrada: minuto {minutoEntrada}");
                        }
                        break;

                    case "D":
                        Console.Write("Minutos a simular (1-1440): ");
                        if (int.TryParse(Console.ReadLine(), out int minutos) && minutos >= 1 && minutos <= 1440)
                        {
                            tiempoSimulado += minutos;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Se sumaron {minutos} minutos");
                            Console.WriteLine($"   Tiempo total: {tiempoSimulado} minutos");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: Debe ser 1-1440 minutos.");
                            Console.ResetColor();
                        }
                        break;

                    case "E":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("=====================================");
                        Console.WriteLine("         TURNO FINALIZADO");
                        Console.WriteLine("=====================================");
                        Console.WriteLine($"Operador: {nombreOperador}");
                        Console.WriteLine($"Turno: {codigoTurno}");
                        Console.WriteLine($"Total Recaudado: Q{totalRecaudado:F2}");
                        Console.WriteLine($"{ticketsCerrados}/{ticketsCreados} tickets procesados");
                        Console.WriteLine($"Parqueo: {espaciosOcupados}/{capacidad} ocupados");
                        if (hayTicketActivo) Console.WriteLine("¡ADVERTENCIA: Hay un ticket activo sin cerrar!");
                        Console.WriteLine("=====================================");
                        Console.WriteLine("¡Gracias por usar el sistema!");
                        Console.ResetColor();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opción inválida!");
                        Console.WriteLine("   Use A, B, C, D o E");
                        Console.ResetColor();
                        break;
                }

                // Pausa solo si no es salida
                if (opcion != "E")
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("--- Presione ENTER para continuar ---");
                    Console.ResetColor();
                    Console.ReadLine();
                }

            } while (opcion != "E");

            Console.WriteLine("Presione cualquier tecla para cerrar...");
            Console.ReadKey();

        }

    }
}