using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Compra<T> where T : Producto
    {
        Empleado vendedor;
        List<ArticuloCompra<T>> productos;
        double precioTotal;
        DateTime dateTime;

        public Empleado Vendedor
        {
            get { return vendedor; }
            set { this.vendedor = value; }
        }

        public double PrecioTotal
        {
            get { return precioTotal; }
            set { this.precioTotal = value; }
        }

        public List<ArticuloCompra<T>> Productos
        {
            get { return productos; }
        }

        public DateTime DateTime
        {
            get { return dateTime; }
            set { this.dateTime = value; }
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Compra()
        {
            this.productos = new List<ArticuloCompra<T>>();
        }

        /// <summary>
        /// Construye una compra con los datos del vendedor y precioTotal de la misma.
        /// </summary>
        /// <param name="vendedor"></param>
        /// <param name="precioTotal"></param>
        public Compra(Empleado vendedor, double precioTotal) : this()
        {
            this.vendedor = vendedor;
            this.precioTotal = precioTotal;
        }

        /// <summary>
        /// Construye una compra con todos sus atributos.
        /// </summary>
        /// <param name="vendedor"></param>
        /// <param name="precioTotal"></param>
        /// <param name="dateTime"></param>
        public Compra(Empleado vendedor, double precioTotal, DateTime dateTime) : this(vendedor, precioTotal)
        {
            this.dateTime = dateTime;
        }

        /// <summary>
        /// Agrega un artículo a la lista de ArticuloCompra de la Compra, sumando su valor al precioTotal.
        /// </summary>
        /// <param name="articuloCompra"></param>
        public void AgregarArticulo(ArticuloCompra<T> articuloCompra)
        {
            precioTotal += articuloCompra.PrecioFinal;

            if (Productos.Exists(x => x.IdProducto == articuloCompra.IdProducto))
            {
                ArticuloCompra<T> auxArt = Productos.Find(x => x.IdProducto == articuloCompra.IdProducto);
                auxArt.Cantidad += articuloCompra.Cantidad;
                auxArt.PrecioFinal = auxArt.Cantidad * auxArt.PrecioUnitario;
            }
            else
            {
                productos.Add(articuloCompra);
            }

        }

        /// <summary>
        /// Convierte los datos de una Compra en un string
        /// </summary>
        /// <returns>Retorna un string formateado con todos los datos de la Compra en formato de Ticket</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Fecha de Compra: {this.DateTime}");
            sb.AppendLine("-------------------------------------------------");
            sb.AppendLine("Datos del Vendedor: ");
            sb.AppendLine($"\tNombre: {this.Vendedor.Nombre}");
            sb.AppendLine($"\tDNI: {this.Vendedor.Dni}");
            sb.AppendLine($"\tNro Empleado: {this.Vendedor.Id}");
            sb.AppendLine("-------------------------------------------------");
            sb.AppendLine("Productos");

            foreach (var p in this.Productos)
            {
                sb.AppendLine($"{p.Producto}\t\t\t x{p.Cantidad}  ${p.PrecioFinal}");
            }

            sb.AppendLine($"Precio Total: \t\t\t${this.precioTotal}");
            sb.AppendLine("-------------------------------------------------");
            sb.AppendLine($"Gracias por su compra!");
            return sb.ToString();
        }
    }
}
