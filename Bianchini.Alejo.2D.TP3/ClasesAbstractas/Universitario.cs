using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos

        private int legajo;

        #endregion


        #region Constructores

        /// <summary>
        /// Constructor por defecto que hereda el constructor por defecto de persona
        /// </summary>
        public Universitario(): base()
        {
        }


        /// <summary>
        /// Constructor que hereda el constructor base e inicializa un universitario agregando el atributo legajo
        /// </summary>
        /// <param name="legajo">Numero de legajo del universitario</param>
        /// <param name="nombre">Nombre del universitario</param>
        /// <param name="apellido">Apellido del universitario</param>
        /// <param name="dni">Dni del universitario</param>
        /// <param name="nacionalidad">Nacionalidad del universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad): base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion


        #region Operadores

        /// <summary>
        /// Compara un universitario con otro verificando si sus dni o legajos son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>Si son iguales segun criterio devuelve true, caso conrtario devuelve false</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {

            if (pg1.Equals(pg2) && pg1.Dni == pg2.Dni || pg1.legajo == pg2.legajo)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Compara un universitario con otro y determina si son diferentes
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>Si no son iguales devuelve true, caso conrtario devuelve false</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion


        #region Métodos

        /// <summary>
        /// Sobrecarga del método Equals, determina si un objeto es del tipo Universitario
        /// </summary>
        /// <param name="obj">objeto a comparar</param>
        /// <returns>Retorna true si el objeto es del tipo universitario, caso contrario retorna false</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this.GetType(), obj.GetType()))
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Muestra todos los datos de un universitario.
        /// </summary>
        /// <returns>Devuelve un string con todos los datos de un universitario </returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"LEGAJO NUMERO: {this.legajo}");
            return sb.ToString();
        }


        /// <summary>
        /// Metodo abstracto sin implementación
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        #endregion
    }
}
