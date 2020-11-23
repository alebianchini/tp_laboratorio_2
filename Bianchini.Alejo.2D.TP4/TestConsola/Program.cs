using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Excepciones;
using Archivos;

namespace TestConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Bianchini.Alejo.2D.TP4";
            Alimento a1 = new Alimento(1, "Gaseosa", 6, 30, ETipo.perecedero);
            Alimento a2 = new Alimento(2, "Oreo", 9, 65, ETipo.perecedero);
            Alimento a3 = new Alimento(3, "Cereal", 4, 26, ETipo.noPerecedero);
            Indumentaria i1 = new Indumentaria(5, "Remera", 3, "Blanco", 430, ETalle.L);
            Indumentaria i2 = new Indumentaria(6, "Buzo", 5, "Rojo", 620, ETalle.S);
            Indumentaria i3 = new Indumentaria(7, "Pantalon", 3, "Negro", 390, ETalle.M);

            Console.WriteLine(Console.Title);
            Console.WriteLine("\nPRODUCTOS GENERADOS CON EXITO");
            Console.WriteLine("\nPresione una tecla para ver la lista de Alimentos");
            Console.WriteLine(" Y luego presione otra vez para ver la lista de Indumentaria");
            Console.ReadKey();
            Console.Clear();

            //Testeo que las listas esten instanciadas y las sobrecargas para agregar objetos a las listas funcionen correctamente.
            if (a1 + Walmart.ListaAlimentos && a2 + Walmart.ListaAlimentos && a3 + Walmart.ListaAlimentos)
            {
                Console.WriteLine("Alimentos cargados a la lista con exito\n");
                Console.WriteLine(Walmart.MostrarListaAlimentos());
                Console.ReadKey();
                Console.Clear();
            }
            if (i1 + Walmart.ListaIndumentaria && i2 + Walmart.ListaIndumentaria && i3 + Walmart.ListaIndumentaria)
            {
                Console.WriteLine("\nIndumentaria cargada a la lista con exito\n");
                Console.WriteLine(Walmart.MostrarListaIndumentaria());
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("\nPresione una tecla para cargar la lista de empleados del archivo Xml...");
            Console.ReadKey();

            //Testeo que la funcionalidad de deserealizar funcione correctamente.
            List<Empleado> auxList = new List<Empleado>();
            string rutaArchivo = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Empleados.xml");
            Xml<List<Empleado>> archivoXml = new Xml<List<Empleado>>();
            archivoXml.Leer(rutaArchivo, out auxList);
            Walmart.ListaEmpleados = auxList;
            Console.WriteLine(Walmart.MostrarListaEmpleados());

            Console.WriteLine("\n\nPresione una tecla para que se cree una compra...");
            Console.ReadKey();
            Console.Clear();

            //Testeo que todos los articulos de compra se creen correctamente usando Generics para poder pasar tanto objetos del tipo Alimento como el tipo Indumentaria
            //Creo una compra nueva la cual tambien una Generics, y luego invoco al metodo GenerarTicket de la clase Walmart para verificar que funcione correctamente dicha
            //funcionalidad del programa. Luego hago un ToString de la compra para mostrar los datos del ticket generado por consola.
            Compra<Producto> compra = new Compra<Producto>(Walmart.ListaEmpleados[1], 490, DateTime.Now);
            ArticuloCompra<Producto> art1 = new ArticuloCompra<Producto>(2, a1, 60, 30);
            ArticuloCompra<Producto> art2 = new ArticuloCompra<Producto>(2, i1, 430, 430);
            compra.Productos.Add(art1);
            compra.Productos.Add(art2);
            Walmart.CompraEnCurso = compra;
            Walmart.GenerarTicket();

            Console.WriteLine("\nSe ha generado un ticket.txt por esta compra, que puede encontrarse en la carpeta bin/Debug del archivo TestConsola\n");
            Console.WriteLine(compra.ToString());
            Console.ReadKey();
        }
    }
}
