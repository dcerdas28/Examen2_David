using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Examen2_David
{
    internal class Categoria
    {
        public string detallePromocion { get; set; }

        public Categoria(string detallePromocion)
        {
            this.detallePromocion = detallePromocion;
        }

        public static void Promocion(string categoria)
        {


            switch (categoria)
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n***Aplica promoción: 15% de Descuento***");
                    Console.ResetColor();
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n***Aplica promoción: Promoción 2x1***");
                    Console.ResetColor();
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n***Aplica promoción: A mitad de precio***");
                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nNo hay promoción disponible para esta categoría.");
                    Console.ResetColor();
                    break;
            }

        }//método Promocion

        //public void ListadoCategorias()
        //{
        //    Console.WriteLine("Listado de categorías:");
        //    foreach (var categoria in categorias)
        //    {
        //        Console.WriteLine(categoria.detallePromocion);
        //    }
        //}

        //public static bool CategoriaExiste(string detallePromocion)
        //{
        //    foreach (var categoria in categorias)
        //    {
        //        if (categoria.detallePromocion == detallePromocion)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

    }//class categoria

    //internal class Categoria1 : Categoria
    //{
    //    public Categoria1() : base("15% de Descuento") { }

    //    public override void Promocion()
    //    {
    //        Console.WriteLine("Promoción: " + detallePromocion);
    //    }
    //}

    //internal class Categoria2 : Categoria
    //{
    //    public Categoria2() : base("Promoción 2x1") { }

    //    public override void Promocion()
    //    {
    //        Console.WriteLine("Promoción: " + detallePromocion);
    //    }
    //}

    //internal class Categoria3 : Categoria
    //{
    //    public Categoria3() : base("Todo a mitad de precio") { }

    //    public override void Promocion()
    //    {
    //        Console.WriteLine("Promoción: " + detallePromocion);
    //    }
    //}

}



