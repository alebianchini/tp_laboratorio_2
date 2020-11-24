using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class FaltaDomicilioException : Exception
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public FaltaDomicilioException() : base("El pedido es para Delivery, debe solicitar un domicilio al Cliente!")
        {

        }

        /// <summary>
        /// Constructor que recibe mensaje por parametro
        /// </summary>
        /// <param name="mensaje"></param>
        public FaltaDomicilioException(string mensaje) : base(mensaje)
        {

        }

        /// <summary>
        /// Usa al constructor de la clase base que recibe una excepcion para mostrar un mensaje de error
        /// </summary>
        /// <param name="innerException">Excepcion recibida</param>
        public FaltaDomicilioException(Exception innerException) : base("El pedido es para Delivery, debe solicitar un domicilio al Cliente!", innerException)
        {

        }
    }
}
