using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Examen2_David
{
    internal class Articulo
    {
        //Array de Articulo ↓
        private static Articulo[] articulos = new Articulo[5];
       

        #region Atributos

        // Atributos
        private string codigo { get; set; }
        private string nombre { get; set; }
        private double precio { get; set; }
        private string categoria { get; set; }

        #endregion




        #region Constructores

        public Articulo()
        {
        }//constructor blanco


        public Articulo(string codigo, string nombre, double precio, string categoria)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.precio = precio;
            this.categoria = categoria;
        }//constructor full

        #endregion

        #region Métodos

        
        public static void AgregarArticulo()
        {
            Console.Clear();

            #region Verficiar espacio en Array


            Console.WriteLine("Verificando Espacio en Array...");
            Thread.Sleep(500);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.WriteLine(".");
            Thread.Sleep(500);

                      
                /*  Se crea una variable int para contar los espacios disponibles,
                    se inicializa en tamaño del array y en caso algun espacio ocupado
                    se va decrementando.
                           ↓                                                        */
                int espaciosDisponibles = articulos.Length;

                bool espacioDisponible = false;


            /*      ETAPAS DEL PROCESO:
                    FOR #1 - EVAULUAR SI HAY ALGÚN ESPACIO DISPONIBLE Y CONTAR CUANTOS QUEDAN.
                    FOR #2 - SI QUEDAN ESPACIOS, INDICAR CUANTOS QUEDAN.
             */

            //Recorro el array ↓
            for (int i = 0; i < articulos.Length; i++)
                {
                    if (articulos[i] == null)// ← si el [i] está disponible (null) ↓
                    {
                        espacioDisponible = true; 

                        // Se eliminó un break aquí, ya que puede que hayan espacios intermedios null.
                    
                    }//if

                    else // ← si el [i] contiene algo... ↓
                    {
                       /*el bool espacioDisponible no se cambia a false, ya que son solo 1
                        espacio disponible debe quedar true y no volver a false.*/

                    espaciosDisponibles--; // ← si en el [i] no está null, se decrementa espaciosDisponibles
                }//else
                
                }//for


            /*Ahora según las variables:

                        int espaciosDisponibles
                        bool espacioDisponible

            Indicamos al usuario si hay o no espacio y cuantos quedan.*/


                if (espacioDisponible) // ← si espacioDisponible quedó = true ↓
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"¡Hay espacio disponible en el array! Quedan {espaciosDisponibles} espacios disponibles.");
                    Console.ResetColor();
                }//if

                else // si espacioDisponible quedó = false ↓
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El array de artículos ya está lleno.");
                    Console.ResetColor();

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadLine();
                return;

                }//else 



                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadLine();
            
            #endregion

            #region Agregar Artículo

            Console.Clear();

            bool error = false;
            string nuevoCodigo;
            string nuevoNombre;
            double nuevoPrecio;
            string nuevaCategoria ="";

            /* - Solicito al usuario: código, nombre y precio.
               - Valido el precio (si convierta ok a float)
               - Creo objeto Articulo.
               - Llamo método AgregarArticulo de la clase Articulo para intentar agregar el nuevo artículo a la lista de artículos.
               - Informamos al usuario sobre el resultado de la operación.*/

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*+*+ Agregar Artículo *++*");
            Console.ResetColor();

            // Solicito los detalles del artículo:

            Console.Write("\nIngrese el código del artículo: ");
            nuevoCodigo = Console.ReadLine();

            Console.Write("Ingrese el nombre del artículo: ");
            nuevoNombre = Console.ReadLine();

            do
            {//Se ingresa y se valida el precio ↓

                Console.Write("Ingrese el precio del artículo: ¢");

                   //Trata de convertirlo a double... si todo bien, almacena el Precio y sale del ciclo.
                   //        ↓                                         ↓↓↓ 
                if (double.TryParse(Console.ReadLine(), out nuevoPrecio))
                {
                    error = false; //si no hubo error ↓
                    break; // ←  ←  ←  ←  ←   ←   sale del ciclo        

                }//if

                //SI NO SE PUDO CONVERTIR A DOUBLE ↓
                else
                {
                    error = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("x_x Precio vo válido, ingrese un número válido.\n");
                    Console.ResetColor();

                }//else

            }//do
            while (error==true);

            do
            {
                // Solicito la categoría al usuario
                Console.WriteLine("\nSeleccione la categoría del artículo, opciones:");
                Console.WriteLine("\n1 - Categoría 1");
                Console.WriteLine("2 - Categoría 2");
                Console.WriteLine("3 - Categoría 3");

                Console.Write("\nDigite una opción: ");

                string entrada = Console.ReadLine();

                // Descarto opciones no válidas
                if (entrada != "1" && entrada != "2" && entrada != "3") //← si digta otro string diferente a 1,2 o 3...
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("x_x Categoría no válida.");
                    Console.ResetColor();

                    error = true;
                }//if
                else
                {
                    nuevaCategoria = entrada; //la almaceno

                }
            } while (error);


            //Creo un nuevo Artículo ↓
            Articulo nuevoArticulo = new Articulo(nuevoCodigo, nuevoNombre, nuevoPrecio, nuevaCategoria);


            //Lo agrego al array
            for (int i = 0; i < articulos.Length; i++)
            {
                if (articulos[i] == null) // ← busca el primer indice vacío
                {
                    articulos[i] = nuevoArticulo;

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n*** El artículo fue agregado correctamente ***");
                    Console.ResetColor();

                    break; // sale del for una vez que se agregó el artículo
                }//if
            }//for

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadLine();

            #endregion

        }//método AgregarArticulo

        public static void BorrarArticulo()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("**** Borrar Artículos ****");
            Console.ResetColor();

            Thread.Sleep(1000);

            Console.WriteLine("\nRevisando existencias de Articulos");
            Thread.Sleep(500);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.WriteLine(".");
            Thread.Sleep(500);


            //Primero valido si hay artículos en el array...



            if (articulos.All(a => a == null))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nActualmente no hay artículos registrados en sistema.");
                Console.ResetColor();

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadLine();
                return; // Sale del método si no hay artículos
            }//if

            //Muestro todos los artículos existentes.

            ReporteArticulos();

            
            Console.Write("\nIngrese el código del artículo que desea eliminar:");
            string codigoEliminar = Console.ReadLine();

            // Buscaré el artículo en el array, lo almacenaré en "articuloEliminar"
            Articulo articuloEliminar = null;

            //recorro el array
            foreach (Articulo articuloBuscado in articulos)
            {
                /* Si artículo buscado no es null Y su código coindice...
                   ↓           ↓          ↓          ↓       ↓       ↓    */
                if (articuloBuscado != null && articuloBuscado.codigo == codigoEliminar)
                {
                    articuloEliminar = articuloBuscado;//acá se guarda.
                    break;
                }//if

            }//foreach

            if (articuloEliminar != null) // ← Si articuloEliminar no quedó null
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nArtículo a eliminar: Código: {articuloEliminar.codigo} || Nombre: {articuloEliminar.nombre} || Precio: ¢{articuloEliminar.precio}");
                Console.ResetColor();

                Console.Write("\n¿Desea eliminar este artículo? (si/no): ");
                string respuesta = Console.ReadLine().ToLower();//to lower por si escribe MAYUSC.

                if (respuesta == "si")
                {
                    //recorro el array para buscarlo
                    for (int i = 0; i < articulos.Length; i++)
                    {
                        if (articulos[i] == articuloEliminar)
                        {
                            articulos[i] = null; // ← Elimino el artículo

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nArtículo eliminado correctamente.");
                            Console.ResetColor();

                            break;
                        }//if
                    }//for
                }//if
                
                else if (respuesta == "no")
                {
                    Console.WriteLine("\nNo se ha eliminado el artículo.");

                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadLine();

                    return;

                }//else if

                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Opción no válida.");
                    Console.ResetColor();

                }//else
            
            }//if

            else // ← Si articuloEliminar SÍ QUEDÓ NULL
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNo se encontró ningún artículo con ese código.");
                Console.ResetColor();

            }//else

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadLine();

        }//método BorrarArticulo

        public static Articulo ConsultarArticulo()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*+*+ Consulta de Artículo *+*+");
            Console.ResetColor();


            Articulo articulo = new Articulo();

            Console.Write("\nIngrese el código del artículo: ");
            string codigo = Console.ReadLine();

            bool encontrado = false;

            //Recorro el array ↓
            for (int i = 0; i < articulos.Length; i++)
            {
                //Si articulos[i] no es null y si su código coincide
                if (articulos[i] != null && articulos[i].codigo == codigo)
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nArtículo encontrado:\n");
                    Console.ResetColor();

                    articulo = articulos[i];

                    Console.WriteLine("Código: " + articulo.codigo);
                    Console.WriteLine("Nombre: " + articulo.nombre);
                    Console.WriteLine("Precio: " + articulo.precio);
                    Console.WriteLine("Categoría" + articulo.categoria);

                    encontrado = true;

                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadLine();

                    

                    return articulo;

                   
                }//if
            }//for

            
            if (!encontrado) // Si encontrado quedó false... ↓
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nEl artículo con código: " + codigo + ", no fue encontrado.");
                Console.ResetColor();

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadLine();


            }//

            return null;

        }//método ConsultarArticulo

        public static void ReporteArticulos()
        {
            

            /*
            Utilizaré el método All del array: Determina si todos los elementos cumplen "x" condición.
            Para la condición a cumplir usaré una función LAMBDA
            La primera "a" representa cada elemento del array.
            La condición de para .All es que cada elemento del array (a) sea == null.

            Esto para validar si el array está vacío.
             
             */
            

            if (articulos.All(a => a == null))//si todos los espacios están null ↓
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("En este momento no hay artículos registrados.");
                Console.ResetColor();

            }//if
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("*** Listado de Artículos ***");
                Console.WriteLine("____________________________\n");
                Console.ResetColor();


                // Recorro el arreglo y muestro los que no son null
                for (int i = 0; i < articulos.Length; i++)
                {
                    if (articulos[i] != null)
                    {
                        Console.WriteLine($"Código: {articulos[i].codigo}");
                        Console.WriteLine($"Nombre: {articulos[i].nombre}");
                        Console.WriteLine($"Precio: ¢{articulos[i].precio}");
                        Console.WriteLine($"Categoría: { articulos[i].categoria}");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("____________________________\n");
                        Console.ResetColor();
                    }//if
                }//for
            }//else

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadLine();
        }

        public static void Facturacion()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("+*+* Facturación +*+*");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nBienvenido al módulo de facturación");
            Console.ResetColor();



            Console.Write("\nDigite el código del vendedor:");
            string vendedor = Console.ReadLine();

            Vendedor.BuscarVendedor(vendedor);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nA continuación será redirigido a la sección de búsqueda de artículos");
            Console.ResetColor();


            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadLine();
            // Consultar el artículo por código
            Articulo articulo = ConsultarArticulo();

            if (articulo == null)
            {

                return;

            }//if

            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("+*+* Facturación +*+*");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nArtículo seleccionado:\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("*****************************");
                Console.ResetColor();

                Console.WriteLine($"Vendedor: {vendedor}");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("*****************************");
                Console.ResetColor();
                Console.WriteLine("Código: " + articulo.codigo);
                Console.WriteLine("Nombre: " + articulo.nombre);
                Console.WriteLine("Precio: ¢" + articulo.precio);
                Console.WriteLine("Categoría: " + articulo.categoria);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nDesea revisar las promociones activas?");
                Console.ResetColor();
                Console.WriteLine("\n1 - Sí");
                Console.WriteLine("2 - No (Facturar sin promoción)");

                string categ = articulo.categoria;

                bool opcionValida = false;
                do
                {
                    Console.Write("\nDigite una opción: ");
                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            // Mostrar las promociones activas
                            Categoria.Promocion(categ);
                            opcionValida = true;
                            Console.ReadLine();
                            break;
                        case "2":
                            // Facturar sin promoción

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nFacturando sin promoción...");
                            Console.ResetColor();
                            opcionValida = true;
                            Console.ReadLine();
                            break;
                        default:

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nOpción no válida. Por favor, ingrese 1 o 2.");
                            Console.ResetColor();
                            break;
                    }
                } while (!opcionValida);

                switch (articulo.categoria)
                {
                    case "1":
                        //15% de Descuento

                        double precio1 = articulo.precio ;
                        double descuento1 = articulo.precio * 0.15;
                        double preciofinal = precio1 - descuento1;

                        Console.WriteLine("El precio final es de: ¢"+preciofinal );
                        Console.ReadLine();
                        break;
                    case "2":
      
                        Console.WriteLine("Puede tomar un segundo artículo del mismo tipo");
                        Console.ReadLine();

                        break;
                    case "3":
                        
                        //double precio2 = articulo.precio;
                        //double descuento2 = articulo/2;
                        //double preciofinal = precio2 - descuento2;

                        break;
                    default:
                        //No promoción

                        break;
                }//switch


                
            }//else
        }//método Facturación

        // Método para consultar el artículo por su código



        #endregion

    }//class
}//space
