using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Constructor sin paramatros, asigna un mensaje de error por defecto
        /// </summary>
        public SinProfesorException(): this("No hay Profesor para la clase")
        {

        }
        /// <summary>
        /// Constructor que recibe un mensaje por parametro
        /// </summary>
        /// <param name="mensaje">Es el mensaje de excepcion que se va a asignar</param>
        public SinProfesorException(string mensaje): base(mensaje)
        {

        }
    }
}
