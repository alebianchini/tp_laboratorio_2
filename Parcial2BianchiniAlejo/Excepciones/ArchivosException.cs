using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public ArchivosException() : base("Error en archivo")
        {

        }

        /// <summary>
        /// Constructor que recibe mensaje por parametro
        /// </summary>
        /// <param name="mensaje"></param>
        public ArchivosException(string mensaje) : base(mensaje)
        {

        }

        /// <summary>
        /// Usa al constructor de la clase base que recibe una excepcion para mostrar un mensaje de error
        /// </summary>
        /// <param name="innerException">Excepcion recibida</param>
        public ArchivosException(Exception innerException) : base("Error al intentar usar el archivo", innerException)
        {

        }
    }
}
