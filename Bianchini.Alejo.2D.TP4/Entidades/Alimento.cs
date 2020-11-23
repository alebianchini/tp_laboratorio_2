using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum ETipo
    {
        perecedero,
        noPerecedero,
        sinDato
    }

    public class Alimento : Producto
    {
        ETipo tipo;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alimento():base()
        {

        }

        /// <summary>
        /// Constructor con todos los atributos de un Alimento recibiendo el Tipo como un string
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descripcion"></param>
        /// <param name="stock"></param>
        /// <param name="precioUnitario"></param>
        /// <param name="tipo"></param>
        public Alimento(int id, string descripcion, int stock, double precioUnitario, string tipo) : base(id, descripcion, stock, precioUnitario)
        {
            this.tipo = this.MapeoETipo(tipo);
        }

        /// <summary>
        /// Constructor con todos los atributos de un Alimento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descripcion"></param>
        /// <param name="precioUnitario"></param>
        /// <param name="tipo"></param>
        public Alimento(int id, string descripcion, int stock, double precioUnitario, ETipo tipo): base(id,descripcion,stock,precioUnitario)
        {
            this.tipo = tipo;
        }

        public ETipo Tipo
        {
            get { return tipo; }
        }

        /// <summary>
        /// Recibe un string y lo transforma en un valor del enum ETipo
        /// </summary>
        /// <param name="valor"></param>
        /// <returns>Retorna el tipo de alimento, con "sinDato" como tipo por default</returns>
        public ETipo MapeoETipo(string valor)
        {
            switch (valor)
            {
                case "perecedero":
                    return ETipo.perecedero;
                case "noPerecedero":
                    return ETipo.noPerecedero;
                default:
                    return ETipo.sinDato;
            }
        }

        /// <summary>
        /// Convierte los datos de un alimento en un string
        /// </summary>
        /// <returns>Retorna un string formateado con todos los datos de un alimento</returns>
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
        /// Sobrecarga operador +. Agrega un alimento a una lista de Alimentos
        /// </summary>
        /// <param name="auxAlimento"></param>
        /// <param name="auxList"></param>
        /// <returns>Retorna True si tuvo éxito. En caso caso contrario False</returns>
        public static bool operator +(Alimento auxAlimento, List<Alimento> auxList)
        {
            for (int i = 0; i < auxList.Count; i++)
            {
                if (string.IsNullOrEmpty(auxAlimento.Descripcion) || auxAlimento.Stock < 1 || auxAlimento.PrecioUnitario < 1 || auxAlimento == auxList[i])
                {
                    return false;
                }
            }
            auxList.Add(auxAlimento);
            return true;
        }

        /// <summary>
        /// SobreCarga operador -. Elimina un alimento de una lista de alimentos
        /// </summary>
        /// <param name="auxAlimento"></param>
        /// <param name="auxList"></param>
        /// <returns>Retorna True si tuvo éxito. En caso caso contrario False</returns>
        public static bool operator -(Alimento auxAlimento, List<Alimento> auxList)
        {
            for (int i = 0; i < auxList.Count; i++)
            {
                if (auxAlimento == auxList[i])
                {
                    auxList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
