using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Entidades
{
    public static class Walmart
    {
        static List<Alimento> listaAlimentos;
        static List<Indumentaria> listaIndumentaria;
        static List<Empleado> listaEmpleados;
        static List<Producto> listaCarrito;
        static Empleado empleadoActivo;
        static Compra<Producto> compraEnCurso;

        /// <summary>
        /// Constructor estático, instancia todas las listas de Walmart, y la compra inicial.
        /// </summary>
        static Walmart()
        {
            listaAlimentos = new List<Alimento>();
            listaIndumentaria = new List<Indumentaria>();
            listaEmpleados = new List<Empleado>();
            listaCarrito = new List<Producto>();
            compraEnCurso = new Compra<Producto>();
        }

        public static List<Indumentaria> ListaIndumentaria
        {
            get { return listaIndumentaria; }
        }

        public static List<Alimento> ListaAlimentos
        {
            get { return listaAlimentos; }
        }

        public static List<Empleado> ListaEmpleados
        {
            get { return listaEmpleados; }
            set { listaEmpleados = value; }
        }

        public static Compra<Producto> CompraEnCurso
        {
            get { return compraEnCurso; }
            set 
            {
                if(value != null)
                    compraEnCurso = value; 
            }
        }

        public static Empleado EmpleadoActivo
        {
            get { return empleadoActivo; }
            set { empleadoActivo = value; }
        }

        /// <summary>
        /// Carga la lista de empleados desde un archivo Xml, también ejecuta los métodos encargados de obtener las listas de alimentos e Indumentaria de la base de datos.
        /// </summary>
        public static void CargarDatos()
        {
            List<Empleado> auxList = new List<Empleado>();
            string rutaArchivo = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Empleados.xml");
            Xml<List<Empleado>> archivoXml = new Xml<List<Empleado>>();
            archivoXml.Leer(rutaArchivo, out auxList);
            listaEmpleados = auxList;
            listaAlimentos = ProductosDAO.ObtenerListaAlimentos();
            listaIndumentaria = ProductosDAO.ObtenerListaIndumentaria();
        }

        /// <summary>
        /// Agrega el ArticuloCompra que recibe por parametro, el cual contiene un alimento, a la lista de Articulos de la compra en curso. En caso de que se repita, solo agrega la cantidad seleccionada.
        /// </summary>
        /// <param name="articuloCompra"></param>
        /// <returns>Retorna True EXITO. En caso contrario False.</returns>
        public static bool AgregarAlimentoAlCarrito(ArticuloCompra<Producto> articuloCompra)
        {
            if (CompraEnCurso.Productos.Exists(x => x.Producto.Equals(articuloCompra.Producto, StringComparison.OrdinalIgnoreCase)))
            {
                if (listaAlimentos.Find(x => x.Descripcion.Equals(articuloCompra.Producto, StringComparison.OrdinalIgnoreCase)).Stock >=
                        (articuloCompra.Cantidad + CompraEnCurso.Productos.Find(x => x.Producto.Equals(articuloCompra.Producto, StringComparison.OrdinalIgnoreCase)).Cantidad))
                {
                    compraEnCurso.AgregarArticulo(articuloCompra);
                    return true;
                }
            }
            else
            {
                if (listaAlimentos.Find(x => x.Descripcion.Equals(articuloCompra.Producto, StringComparison.OrdinalIgnoreCase)).Stock >= articuloCompra.Cantidad)
                {
                    compraEnCurso.AgregarArticulo(articuloCompra);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Agrega el ArticuloCompra que recibe por parametro, el cual contiene una Indumentaria, a la lista de Articulos de la compra en curso. En caso de que se repita, solo agrega la cantidad seleccionada.
        /// </summary>
        /// <param name="articuloCompra"></param>
        /// <returns>Retorna True EXITO. En caso contrario False.</returns>
        public static bool AgregarIndumentariaAlCarrito(ArticuloCompra<Producto> articuloCompra)
        {
            if (CompraEnCurso.Productos.ExistsArticuloInList(articuloCompra.IdProducto))
            {
                if (listaIndumentaria.FindIndumentariaInList(articuloCompra.IdProducto).Stock >=
                        (articuloCompra.Cantidad + CompraEnCurso.Productos.FindArticuloInList(articuloCompra.IdProducto).Cantidad))
                {
                    compraEnCurso.AgregarArticulo(articuloCompra);
                    return true;
                }
            }
            else
            {
                if (listaIndumentaria.FindIndumentariaInList(articuloCompra.IdProducto).Stock >= articuloCompra.Cantidad)
                {
                    compraEnCurso.AgregarArticulo(articuloCompra);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Establece el horario y el empleado activo a la hora de concretar la compra.
        /// </summary>
        public static void SetearCompraEnCurso()
        {
            CompraEnCurso.DateTime = DateTime.Now;
            compraEnCurso.Vendedor = empleadoActivo;
        }

        /// <summary>
        /// Actualiza el stock de los productos luego de realizar una compra, tanto en la ejecucion del programa como en la base de datos.
        /// </summary>
        public static void ActualizarStock()
        {
            foreach (ArticuloCompra<Producto> item in CompraEnCurso.Productos)
            {
                if(listaAlimentos.Exists(x => x.Id.Equals(item.IdProducto)))
                {
                    Alimento alimentoAux = listaAlimentos.Find(x => x.Id.Equals(item.IdProducto));
                    alimentoAux.Stock -= item.Cantidad;
                    ProductosDAO.ActualizarStockAlimentoDB(alimentoAux);
                }
                else if(listaIndumentaria.Exists(x => x.Id.Equals(item.IdProducto)))
                {
                    Indumentaria prendaAux = listaIndumentaria.Find(x => x.Id.Equals(item.IdProducto));
                    prendaAux.Stock -= item.Cantidad;
                    ProductosDAO.ActualizarStockIndumentariaDB(prendaAux);
                }
            }
        }

        /// <summary>
        /// Genera un ticket con los datos de la compra al momento de realizarse la misma.
        /// </summary>
        public static void GenerarTicket()
        {
            string rutaArchivo = AppDomain.CurrentDomain.BaseDirectory + 
                $"{ CompraEnCurso.DateTime.ToString("yyyy-MM-dd-HH-mm-ss")}_{CompraEnCurso.Vendedor.Nombre}.txt";
            string datos = compraEnCurso.ToString();
            Texto ticket = new Texto();
            if(ticket.Guardar(rutaArchivo, datos))
            {
                compraEnCurso = new Compra<Producto>();
            }
        }

        /// <summary>
        /// Agrega un nuevo alimento a la lista, tanto en ejecucion como en la base de datos.
        /// </summary>
        /// <param name="nuevoAlimento"></param>
        /// <returns>retorna un string que informa su la carga se realizó correctamente o no</returns>
        public static string AgregarNuevoAlimento(Alimento nuevoAlimento)
        {
            if (nuevoAlimento + listaAlimentos)
            {
                ProductosDAO.AgregarAlimentoDB(nuevoAlimento);
                return "Producto agregado correctamente";
            }
            return "Error en la carga";
        }

        /// <summary>
        /// Agrega una nueva Indumentaria a la lista, tanto en ejecucion como en la base de datos.
        /// </summary>
        /// <param name="nuevaPrenda"></param>
        /// <returns>retorna un string que informa su la carga se realizó correctamente o no</returns>
        public static string AgregarNuevaIndumentaria(Indumentaria nuevaPrenda)
        {
            if (nuevaPrenda + listaIndumentaria)
            {
                ProductosDAO.AgregarIndumentariaDB(nuevaPrenda);
                return "Producto agregado correctamente";
            }
            return "Error en la carga";
        }

        /// <summary>
        /// Limpia el carrito de la compra en curso y restablece su precioTotal a 0.
        /// </summary>
        public static void LimpiarCarrito()
        {
            compraEnCurso.Productos.Clear();
            compraEnCurso.PrecioTotal = 0;
        }

        /// <summary>
        /// Busca la en la lista de Indumentaria el id de la indumentaria recibido por parametro, y al encontrarlo agrega el stock solicitado.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cantidad"></param>
        public static void AgregarStockIndumentaria(int id, int cantidad)
        {
            listaIndumentaria.FindIndumentariaInList(id).Stock += cantidad;
        }

        /// <summary>
        /// Busca la en la lista de Alimentos el id del Alimento recibido por parametro, y al encontrarlo agrega el stock solicitado.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cantidad"></param>
        public static void AgregarStockAlimento(int id, int cantidad)
        {
            listaAlimentos.Find(x => x.Id == (id)).Stock += cantidad;
        }

        /// <summary>
        /// Crea un string con todos los datos de la lista de empleados
        /// </summary>
        /// <returns>retorna el string generado</returns>
        public static string MostrarListaEmpleados()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nLISTA DE EMPLEADOS:");
            sb.AppendLine($"\n{listaEmpleados[0].ToString()}");
            sb.AppendLine($"\n{listaEmpleados[1].ToString()}");
            sb.AppendLine($"\n{listaEmpleados[2].ToString()}");
            return sb.ToString();
        }

        /// <summary>
        /// Crea un string con todos los datos de la lista de Alimentos
        /// </summary>
        /// <returns>retorna el string generado</returns>
        public static string MostrarListaAlimentos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nLISTA DE ALIMENTOS:");
            sb.AppendLine($"\n{listaAlimentos[0].ToString()}");
            sb.AppendLine($"\n{listaAlimentos[1].ToString()}");
            sb.AppendLine($"\n{listaAlimentos[2].ToString()}");
            return sb.ToString();
        }

        /// <summary>
        /// Crea un string con todos los datos de la lista de Indumentaria
        /// </summary>
        /// <returns>retorna el string generado</returns>
        public static string MostrarListaIndumentaria()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nLISTA DE EMPLEADOS:");
            sb.AppendLine($"\n{listaIndumentaria[0].ToString()}");
            sb.AppendLine($"\n{listaIndumentaria[1].ToString()}");
            sb.AppendLine($"\n{listaIndumentaria[2].ToString()}");
            return sb.ToString();
        }
    }
}
