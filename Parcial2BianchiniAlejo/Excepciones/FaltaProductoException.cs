using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class FaltaProductoException : Exception
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public FaltaProductoException() : base("Debe agregar al menos 1 producto al carrito para confirmar un pedido!")
        {

        }

        /// <summary>
        /// Constructor que recibe mensaje por parametro
        /// </summary>
        /// <param name="mensaje"></param>
        public FaltaProductoException(string mensaje) : base(mensaje)
        {

        }

        /// <summary>
        /// Usa al constructor de la clase base que recibe una excepcion para mostrar un mensaje de error
        /// </summary>
        /// <param name="innerException">Excepcion recibida</param>
        public FaltaProductoException(Exception innerException) : base("Debe agregar al menos 1 producto al carrito para confirmar un pedido!", innerException)
        {

        }
    }
}
