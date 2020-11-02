using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor sin paramatros, asigna un mensaje de error por defecto
        /// </summary>
        public AlumnoRepetidoException(): this("Alumno repetido")
        {

        }
        /// <summary>
        /// Constructor con posibilidad de enviar un mensaje de excepcion
        /// </summary>
        /// <param name="mensaje">Es el mensaje de excepcion que se va a asignar</param>
        public AlumnoRepetidoException(string mensaje): base(mensaje)
        {

        }
    }
}
