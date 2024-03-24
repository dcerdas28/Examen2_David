using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Examen2_David
{
    internal class Vendedor
    {
        #region Diccionario

        //key   value
        // ↓       ↓
        private static Dictionary<string, string> vendedores = new Dictionary<string, string>()
    {
        { "001", "Vendedor1" },
        { "002", "Vendedor2" }
    };//diccionario vendedores

        #endregion

        #region Atributos
        private string codigo;
        private string nombre;
        #endregion

        #region Constructores

        

        public Vendedor()
        {
        }// Constructor blanco

        
        public Vendedor(string codigo, string nombre)
        {
            this.codigo = codigo;
            this.nombre = nombre;
        }// Constructor

        #endregion

        #region Métodos

        public static void ReporteVendedores()
        {

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*** Listado de vendedores*** \n");
            Console.ResetColor();

            Console.WriteLine("A continuación verá la lsita de vendedores registrados en sistema:\n");

            //recorre el diccionario
            //    ↓
            foreach (KeyValuePair<string, string> vendedor in vendedores)
            {
                Console.WriteLine($"Código: {vendedor.Key} || Nombre: {vendedor.Value}");
            }//foreach

            Console.WriteLine("\nDigite una tecla para continuar...");
            Console.ReadLine();
            
            return;

           

        }// metodo ListarVendedores



        public static Vendedor BuscarVendedor(string codigo)
        {
            if (vendedores.ContainsKey(codigo))
            {
                // Obtiene el nombre del vendedor usando el código como clave
                string nombreVendedor = vendedores[codigo];

                // Creo objeto Vendedor con el código y nombre obtenidos
                Vendedor vendedorEncontrado = new Vendedor(codigo, nombreVendedor);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nSe encontró un vendedor:\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Código: {codigo} || Nombre: {nombreVendedor}");
                Console.ResetColor();

               // Console.WriteLine("\nPresione una tecla para continuar...");

                // Devolver el objeto Vendedor creado
                return vendedorEncontrado;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n¡Vendedor no encontrado!");
                Console.ResetColor();

                Console.WriteLine("\nPresione una tecla para continuar...");
                return null;
            }
        }

        #endregion


        #region Clases Vendedor 1 y 2
        public class Vendedor1 : Interface.IVendedor1
        {
            //Atributo*******************************************************
            private string nombreVendedor;

            //Constructor****************************************************
            public Vendedor1(string nombreVendedor)
            {
                this.nombreVendedor = nombreVendedor;
            }//Constructor

            //Método********************************************************
            public void VentasContado()//método de la interfaz IVendedor1
            {
                Console.WriteLine("Realizando ventas al contado");
            
            }//método VentasContado

        }//class Vendedor1**************************************************




        public class Vendedor2 : Interface.IVendedor2
        {
            //Atributo*******************************************************
            private string nombreVendedor;

            //Constructor****************************************************
            public Vendedor2(string nombreVendedor)
            {
                this.nombreVendedor = nombreVendedor;
            }//Constructor

            //Método********************************************************
            public void VentasCredito()//método de la interfaz IVendedor2
            {
                Console.WriteLine("Realizando ventas a crédito");

            }//método VentasCredito

        }//class Vendedor2

        #endregion
    }//Class



}//Space
