using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ArticuloCompra<T> where T : Producto
    {
        int cantidad;
        T producto;
        double precioFinal;
        double precioUnitario;

        public int Cantidad
        {
            get { return cantidad; }
            set 
            {
                if (value > 0)
                    this.cantidad = value;
                else
                    this.cantidad = 1;
            }
        }
        public string Producto
        {
            get { return producto.Descripcion; }
        }

        public int IdProducto
        {
            get { return producto.Id; }
        }

        public double PrecioFinal
        {
            get { return precioFinal; }
            set 
            {
                if (value > 0)
                    this.precioFinal = value;
                else
                    this.precioFinal = precioUnitario;
            }
        }
        public double PrecioUnitario
        {
            get { return precioUnitario; }
        }

        /// <summary>
        /// Constructor con todos los atributos de un ArticuloCompra.
        /// </summary>
        /// <param name="cantidad"></param>
        /// <param name="producto"></param>
        /// <param name="precioFinal"></param>
        /// <param name="precioUnitario"></param>
        public ArticuloCompra(int cantidad, T producto, double precioFinal, double precioUnitario)
        {
            this.cantidad = cantidad;
            this.producto = producto;
            this.precioFinal = precioFinal;
            this.precioUnitario = precioUnitario;
        }

        /// <summary>
        /// Convierte los datos de un ArticuloCompra en un string
        /// </summary>
        /// <returns>Retorna un string formateado con todos los datos de un ArticuloCompra</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Cantidad: " + this.cantidad.ToString());
            sb.AppendLine("Producto: " + this.producto.Descripcion);
            sb.AppendLine("Precio por Unidad: " + this.precioUnitario.ToString());
            sb.AppendLine("Precio Final: " + this.precioFinal.ToString());
            return sb.ToString();
        }
    }
}
