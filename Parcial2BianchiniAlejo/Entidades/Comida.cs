using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum EComida
    {
        conCarne,
        vegetariano,
        vegano
    }
    public class Comida : Producto, IProducto
    {
        EComida tipo;

        public Comida() : base()
        {

        }

        /// <summary>
        /// Constructor con todos los atributos de una comida, que recibe el tipo como un string.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descripcion"></param>
        /// <param name="stock"></param>
        /// <param name="precioUnitario"></param>
        /// <param name="tipo"></param>
        public Comida(int id, string descripcion, int stock, double precioUnitario, string tipo) :base(id, descripcion, stock, precioUnitario)
        {
            this.tipo = this.MapeoETipo(tipo);
        }

        /// <summary>
        /// Constructor con todos los atributos de una comida, que recibe el Tipo como un EComida
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descripcion"></param>
        /// <param name="stock"></param>
        /// <param name="precioUnitario"></param>
        public Comida(int id, string descripcion, int stock, double precioUnitario, EComida tipo) : base(id, descripcion, stock, precioUnitario)
        {
            this.tipo = tipo;
        }

        public EComida Tipo
        {
            get { return tipo; }
            set { this.tipo = value; }
        }

        /// <summary>
        /// Recibe un string y lo transforma en un valor del enum ETipo
        /// </summary>
        /// <param name="valor"></param>
        /// <returns>Retorna el tipo de Comida</returns>
        public EComida MapeoETipo(string valor)
        {
            switch (valor)
            {
                case "conCarne":
                    return EComida.conCarne;
                case "vegetariano":
                    return EComida.vegetariano;
                default:
                    return EComida.vegano;
            }
        }

        /// <summary>
        /// Calcula el tiempo de preparación del producto dependiendo de su tipo
        /// </summary>
        /// <returns>Retorna un entero con el tiempo de preparacion</returns>
        public int CalcularTiempoPreparación()
        {
            switch(this.tipo)
            {
                case EComida.conCarne:
                    return 3000;
                case EComida.vegetariano:
                    return 2500;
                default:
                    return 2000;
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
        /// Sobrecarga operador +. Agrega una Comida a una lista de Comidas
        /// </summary>
        /// <param name="auxComida"></param>
        /// <param name="auxList"></param>
        /// <returns>Retorna True si tuvo éxito. En caso caso contrario False</returns>
        public static bool operator +(Comida auxComida, List<Comida> auxList)
        {
            for (int i = 0; i < auxList.Count; i++)
            {
                if (string.IsNullOrEmpty(auxComida.Descripcion) || auxComida.Stock < 1 || auxComida.PrecioUnitario < 1 || auxComida == auxList[i])
                {
                    return false;
                }
            }
            auxList.Add(auxComida);
            return true;
        }

        /// <summary>
        /// SobreCarga operador -. Elimina un Comida de una lista de Comidas
        /// </summary>
        /// <param name="auxComida"></param>
        /// <param name="auxList"></param>
        /// <returns>Retorna True si tuvo éxito. En caso caso contrario False</returns>
        public static bool operator -(Comida auxComida, List<Comida> auxList)
        {
            for (int i = 0; i < auxList.Count; i++)
            {
                if (auxComida == auxList[i])
                {
                    auxList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
