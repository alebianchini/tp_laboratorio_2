using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum EBebida
    {
        alcohol,
        sinAlcohol,
    }
    public class Bebida : Producto, IProducto
    {
        EBebida tipo;

        public Bebida() : base()
        {

        }

        /// <summary>
        /// Constructor con todos los atributos de una Bebida, que recibe el tipo como un string.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descripcion"></param>
        /// <param name="stock"></param>
        /// <param name="precioUnitario"></param>
        /// <param name="tipo"></param>
        public Bebida(int id, string descripcion, int stock, double precioUnitario, string tipo) : base(id, descripcion, stock, precioUnitario)
        {
            this.tipo = this.MapeoETipo(tipo);
        }

        /// <summary>
        /// Constructor con todos los atributos de una Bebida, que recibe el Tipo como un EComida
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descripcion"></param>
        /// <param name="stock"></param>
        /// <param name="precioUnitario"></param>
        public Bebida(int id, string descripcion, int stock, double precioUnitario, EBebida tipo) : base(id, descripcion, stock, precioUnitario)
        {
            this.tipo = tipo;
        }

        public EBebida Tipo
        {
            get { return tipo; }
            set { this.tipo = value; }
        }

        /// <summary>
        /// Recibe un string y lo transforma en un valor del enum EBebida
        /// </summary>
        /// <param name="valor"></param>
        /// <returns>Retorna el tipo de Bebida</returns>
        public EBebida MapeoETipo(string valor)
        {
            switch (valor)
            {
                case "alcohol":
                    return EBebida.alcohol;
                default:
                    return EBebida.sinAlcohol;
            }
        }

        /// <summary>
        /// Calcula el tiempo de preparación del producto dependiendo de su tipo
        /// </summary>
        /// <returns>Retorna un entero con el tiempo de preparacion</returns>
        public int CalcularTiempoPreparación()
        {
            switch (this.tipo)
            {
                case EBebida.alcohol:
                    return 1000;
                default:
                    return 500;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ID: " + this.Id.ToString());
            sb.AppendLine("Producto: " + this.Descripcion);
            sb.AppendLine("Stock: " + this.Stock.ToString());
            sb.AppendLine("Tipo de Producto: " + this.tipo.ToString());
            sb.AppendLine("Precio por Unidad: " + this.PrecioUnitario.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga operador +. Agrega una Bebida a una lista de Bebidas
        /// </summary>
        /// <param name="auxBebida"></param>
        /// <param name="auxList"></param>
        /// <returns>Retorna True si tuvo éxito. En caso caso contrario False</returns>
        public static bool operator +(Bebida auxBebida, List<Bebida> auxList)
        {
            for (int i = 0; i < auxList.Count; i++)
            {
                if (string.IsNullOrEmpty(auxBebida.Descripcion) || auxBebida.Stock < 1 || auxBebida.PrecioUnitario < 1 || auxBebida == auxList[i])
                {
                    return false;
                }
            }
            auxList.Add(auxBebida);
            return true;
        }

        /// <summary>
        /// SobreCarga operador -. Elimina un Bebida de una lista de Bebidas
        /// </summary>
        /// <param name="auxBebida"></param>
        /// <param name="auxList"></param>
        /// <returns>Retorna True si tuvo éxito. En caso caso contrario False</returns>
        public static bool operator -(Bebida auxBebida, List<Bebida> auxList)
        {
            for (int i = 0; i < auxList.Count; i++)
            {
                if (auxBebida == auxList[i])
                {
                    auxList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
