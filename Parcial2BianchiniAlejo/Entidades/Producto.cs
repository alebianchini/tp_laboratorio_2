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

        public Producto()
        {

        }

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
            set { this.id = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { this.descripcion = value; }
        }

        public int Stock
        {
            get { return stock; }
            set
            {
                if (value > 0)
                    this.stock = value;
            }
        }

        public double PrecioUnitario
        {
            get { return precioUnitario; }
            set { this.precioUnitario = value; }
        }
    }
}
