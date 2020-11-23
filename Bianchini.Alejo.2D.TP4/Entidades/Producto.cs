using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        int id;
        string descripcion;
        int stock;
        double precioUnitario;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Producto()
        {

        }

        /// <summary>
        /// Construye un Producto con todos sus atributos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descripcion"></param>
        /// <param name="stock"></param>
        /// <param name="precioUnitario"></param>
        public Producto(int id, string descripcion, int stock, double precioUnitario)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.stock = stock;
            this.precioUnitario = precioUnitario;
        }

        public int Id
        {
            get { return id; }
        }

        public string Descripcion
        {
            get { return descripcion; }
        }

        public int Stock
        {
            get { return stock; }
            set 
            {
                if(value > 0)
                    this.stock = value; 
            }
        }

        public double PrecioUnitario
        {
            get { return precioUnitario; }
        }
    }
}
