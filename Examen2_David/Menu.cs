using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examen2_David
{
    internal class Menu
    {
        #region Variables
        private static string opcion;
        #endregion

        #region Métodos
        public static void menuPrincipal()
        {
            int opcion1 = 0;
            do
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("+*+*+* Menu Principal *+*+**");
                Console.ResetColor();

                Console.WriteLine("\n1- Articulos.");
                Console.WriteLine("2- Facturación.");
                Console.WriteLine("3- Reportes");
                Console.WriteLine("4- Salir");
                Console.Write("\nDigite una opción:");
                int.TryParse(Console.ReadLine(), out opcion1);// si ingresa una letra no va a dejar continuar
                switch (opcion1)
                {
                    case 1: SubMenuArticulos();
                            break;
                    case 2: Articulo.Facturacion();
                            break;
                    case 3: SubMenuReporte();
                            break;
                    case 4:
                        Console.WriteLine("\nSaliendo...");
                        Thread.Sleep(500);
                        Console.WriteLine(".");
                        Thread.Sleep(500);
                        Console.WriteLine(".");
                        Thread.Sleep(500);

                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n*******  x_x opción no válida  *******");
                        Console.ResetColor();
                        
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ResetColor();

                        Console.ReadLine();
                        break;
                }// fin switch
            } while (opcion1 != 4);

        }//método menuPrincipal

        public static void SubMenuArticulos()
        {

            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("*+*+*+  Submenú Artículos  *+*+*+\n");
                Console.ResetColor();

                Console.WriteLine("1. Agregar");
                Console.WriteLine("2. Borrar");
                Console.WriteLine("3. Consultar");
                Console.WriteLine("4. Volver al menú principal");
                Console.Write("\nDigite una opción: ");

                //almaceno la opción
                opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                       Articulo.AgregarArticulo();
                        break;
                    case "2":
                        Articulo.BorrarArticulo();
                        break;
                    case "3":
                       Articulo.ConsultarArticulo();
                        break;
                    case "4":
                        Console.WriteLine("Volviendo al menú principal...");
                        return; // sale del método

                    default:

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("*******  x_x opción no válida  *******");
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ResetColor();

                        Console.ReadLine();

                        break;

                }//switch

            }//while

        }//método MostrarSubMenuArticulos


        public static void subMenuVendedores()
        {
            bool opcionValida = false;

            do
            {
                Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*+*+*+ Submenú Vendedores *+*+*+\n");
            Console.ResetColor();

            
            Console.WriteLine("¿Qué desea hacer?\n");
            Console.WriteLine("\n1. Ver Listado de Vendedores.");
            Console.WriteLine("2. Buscar Vendedor.");
            Console.WriteLine("3. Volver al menú anterior");
            Console.Write("\nDigite una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Vendedor.ReporteVendedores();
                    break;
                case "2":

                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("+*+* Buscar Vendedor +*+*");
                        Console.ResetColor();
                        Console.Write("\nDigite el código del vendedor: ");
                    
                        string codigoBuscar= Console.ReadLine();

                        Vendedor.BuscarVendedor(codigoBuscar);
                        
                        Console.ReadLine() ;

                        break;

                    case "3":
                        return;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n¡Opción no válida! Por favor, seleccione una opción válida.");
                    Console.ResetColor();
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;
            }//switch

        } while (!opcionValida);
        }//método subMenuVendedores


        public static void SubMenuReporte()
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("***** Submenú Reporte *****");
                Console.ResetColor();

                Console.WriteLine("\n1. Vendedores");
                Console.WriteLine("2. Categorías");
                Console.WriteLine("3. Artículos");
                Console.WriteLine("4. Volver al menú principal");
                Console.Write("\nDigite una opción: ");
                opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        subMenuVendedores();
                        break;
                    case "2":
                        //MostrarReporteCategorias();
                        break;
                    case "3":
                        Articulo.ReporteArticulos();
                        break;
                    case "4":
                        return;//no retorna nada y sale al menú principal
                    default:

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("*******  x_x opción no válida  *******");
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ResetColor();

                        Console.ReadLine();

                        break;
                
                }//switch
            
            }//while
        
        }//método Reporte



        #endregion

    }//Class
}//Space