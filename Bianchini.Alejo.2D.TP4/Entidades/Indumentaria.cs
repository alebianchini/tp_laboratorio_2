using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum ETalle
    {
        S,
        M,
        L,
        sinDato
    }

    public class Indumentaria : Producto
    {
        string color;
        ETalle talle;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Indumentaria()
        {

        }

        /// <summary>
        /// Construye una Indumentaria con todos sus atributos, recibiendo el Talle como string
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descripcion"></param>
        /// <param name="stock"></param>
        /// <param name="color"></param>
        /// <param name="precioUnitario"></param>
        /// <param name="talle"></param>
        public Indumentaria(int id, string descripcion, int stock, string color, double precioUnitario, string talle): base(id, descripcion, stock, precioUnitario)
        {
            this.color = color;
            this.talle = this.MapeoETipo(talle);
        }

        /// <summary>
        /// Construye una Indumentaria con todos sus atributos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descripcion"></param>
        /// <param name="color"></param>
        /// <param name="precioUnitario"></param>
        /// <param name="talle"></param>
        public Indumentaria(int id, string descripcion, int stock, string color, double precioUnitario, ETalle talle): base(id,descripcion,stock,precioUnitario)
        {
            this.color = color;
            this.talle = talle;
        }

        public string Color
        {
            get { return color; }
        }

        public ETalle Talle
        {
            get { return talle; }
        }

        /// <summary>
        /// Recibe un string y lo transforma en un valor del enum ETalle
        /// </summary>
        /// <param name="valor"></param>
        /// <returns>Retorna el talle de la indumentaria, con "sinDato" como tipo por default</returns>
        public ETalle MapeoETipo(string valor)
        {
            switch(valor)
            {
                case "S":
                    return ETalle.S;
                case "M":
                    return ETalle.M;
                case "L":
                    return ETalle.L;
                default:
                    return ETalle.sinDato;
            }
        }

        /// <summary>
        /// Convierte los datos de una Indumentaria en un string
        /// </summary>
        /// <returns>Retorna un string formateado con todos los datos de una indumentaria</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ID: " + this.Id.ToString());
            sb.AppendLine("Producto: " + this.Descripcion);
            sb.AppendLine("Stock: " + this.Stock.ToString());
            sb.AppendLine("Color: " + this.color);
            sb.AppendLine("Tipo de Producto: " + this.talle.ToString());
            sb.AppendLine("Precio por Unidad: " + this.PrecioUnitario.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga operador +. Agrega una Indumentaria a una lista de Indumentarias
        /// </summary>
        /// <param name="auxPrenda"></param>
        /// <param name="auxList"></param>
        /// <returns>Retorna True si tuvo éxito. En caso caso contrario False</returns>
        public static bool operator +(Indumentaria auxPrenda, List<Indumentaria> auxList)
        {
            for (int i = 0; i < auxList.Count; i++)
            {
                if (string.IsNullOrEmpty(auxPrenda.Descripcion) || auxPrenda.Stock < 1 || string.IsNullOrEmpty(auxPrenda.Color) ||auxPrenda.PrecioUnitario < 1 || auxPrenda == auxList[i])
                {
                    return false;
                }
            }
            auxList.Add(auxPrenda);
            return true;
        }

        /// <summary>
        /// Sobrecarga operador -. Elimina una Indumentaria a una lista de Indumentarias
        /// </summary>
        /// <param name="auxPrenda"></param>
        /// <param name="auxList"></param>
        /// <returns>Retorna True si tuvo éxito. En caso caso contrario False</returns>
        public static bool operator -(Indumentaria auxPrenda, List<Indumentaria> auxList)
        {
            for (int i = 0; i < auxList.Count; i++)
            {
                if (auxPrenda == auxList[i])
                {
                    auxList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
