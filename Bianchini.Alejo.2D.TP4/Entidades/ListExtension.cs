using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ListExtension
    {
        /// <summary>
        /// Busca una Indumentaria en una lista teniendo en cuenta su ID.
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="id"></param>
        /// <returns>Retorna la Indumentaria en caso de encontrarla. Caso contrario retorna null</returns>
        public static Indumentaria FindIndumentariaInList(this List<Indumentaria> lista, int id)
        {
            Indumentaria auxPrenda = null;
            if(lista.Exists(x => x.Id == id))
            {
                auxPrenda = lista.Find(x => x.Id == id);
            }
            return auxPrenda;
        }

        /// <summary>
        /// Busca un ArticuloCompra en una lista teniendo en cuenta su ID.
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="id"></param>
        /// <returns>Retorna la Indumentaria en caso de encontrarlo. Caso contrario retorna null</returns>
        public static ArticuloCompra<Producto> FindArticuloInList(this List<ArticuloCompra<Producto>> lista, int id)
        {
            ArticuloCompra<Producto> auxArt = null;
            if (lista.Exists(x => x.IdProducto == id))
            {
                auxArt = lista.Find(x => x.IdProducto == id);
            }
            return auxArt;
        }

        /// <summary>
        /// Verifica que exista un ArticuloCompra en una lista teniendo en cuenta su ID
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="id"></param>
        /// <returns>Retorna true en caso de que exista. Caso contrario retorna false</returns>
        public static bool ExistsArticuloInList(this List<ArticuloCompra<Producto>> lista, int id)
        {
            if (lista.Exists(x => x.IdProducto == id))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica que exista un Alimento en una lista teniendo en cuenta su Descripcion
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="descripcion"></param>
        /// <returns>Retorna true en caso de que exista. Caso contrario retorna false</returns>
        public static bool ExistsAlimentoInList(this List<Alimento> lista, string descripcion)
        {
            if (lista.Exists(x => x.Descripcion.Equals(descripcion, StringComparison.OrdinalIgnoreCase)))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica que exista una Indumentaria en una lista teniendo en cuenta su Descripcion
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="descripcion"></param>
        /// <returns>Retorna true en caso de que exista. Caso contrario retorna false</returns>
        public static bool ExistsIndumentariaInList(this List<Indumentaria> lista, string descripcion)
        {
            if (lista.Exists(x => x.Descripcion.Equals(descripcion, StringComparison.OrdinalIgnoreCase)))
            {
                return true;
            }
            return false;
        }
    }
}
