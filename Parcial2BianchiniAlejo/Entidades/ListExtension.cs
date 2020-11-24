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
        /// Busca una Comida en una lista teniendo en cuenta su ID.
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="id"></param>
        /// <returns>Retorna la Comida en caso de encontrarla. Caso contrario retorna null</returns>
        public static Comida FindComidaInList(this List<Comida> lista, int id)
        {
            Comida auxComida = null;
            if (lista.Exists(x => x.Id == id))
            {
                auxComida = lista.Find(x => x.Id == id);
            }
            return auxComida;
        }

        /// <summary>
        /// Busca una Bebida en una lista teniendo en cuenta su ID.
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="id"></param>
        /// <returns>Retorna la Bebida en caso de encontrarla. Caso contrario retorna null</returns>
        public static Bebida FindBebidaInList(this List<Bebida> lista, int id)
        {
            Bebida auxBebida = null;
            if (lista.Exists(x => x.Id == id))
            {
                auxBebida = lista.Find(x => x.Id == id);
            }
            return auxBebida;
        }

        /// <summary>
        /// Busca un ArticuloPedido en una lista teniendo en cuenta su ID.
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="id"></param>
        /// <returns>Retorna el ArticuloPedido en caso de encontrarlo. Caso contrario retorna null</returns>
        public static ArticuloPedido<Producto> FindArticuloInList(this List<ArticuloPedido<Producto>> lista, int id)
        {
            ArticuloPedido<Producto> auxArt = null;
            if (lista.Exists(x => x.IdProducto == id))
            {
                auxArt = lista.Find(x => x.IdProducto == id);
            }
            return auxArt;
        }

        /// <summary>
        /// Verifica que exista un ArticuloPedido en una lista teniendo en cuenta su ID
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="id"></param>
        /// <returns>Retorna true en caso de que exista. Caso contrario retorna false</returns>
        public static bool ExistsArticuloInList(this List<ArticuloPedido<Producto>> lista, int id)
        {
            if (lista.Exists(x => x.IdProducto == id))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica que exista una Bebida en una lista teniendo en cuenta su Descripcion
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="descripcion"></param>
        /// <returns>Retorna true en caso de que exista. Caso contrario retorna false</returns>
        public static bool ExistsBebidaInList(this List<Bebida> lista, string descripcion)
        {
            if (lista.Exists(x => x.Descripcion.Equals(descripcion, StringComparison.OrdinalIgnoreCase)))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica que exista una Comida en una lista teniendo en cuenta su Descripcion
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="descripcion"></param>
        /// <returns>Retorna true en caso de que exista. Caso contrario retorna false</returns>
        public static bool ExistsComidaInList(this List<Comida> lista, string descripcion)
        {
            if (lista.Exists(x => x.Descripcion.Equals(descripcion, StringComparison.OrdinalIgnoreCase)))
            {
                return true;
            }
            return false;
        }
    }
}
