using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;
using Excepciones;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributos

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #endregion


        #region Enumerado
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }

        #endregion


        #region Constructores

        /// <summary>
        /// Constructor por defecto, heredando el constructor de la clase Base.
        /// </summary>
        public Alumno() : base()
        {
        }


        /// <summary>
        /// Inicializa un objeto del tipo alumno con todos sus datos menos el atributo "estadoCuenta"
        /// </summary>
        /// <param name="id">Legajo del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">Dni del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clases que toma el alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) 
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }


        /// <summary>
        /// Inicializa un Alumno con todos sus datos.
        /// </summary>
        /// <param name="id">Legajo del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">Dni del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clases que toma el alumno</param>
        /// <param name="estadoCuenta">Estado de cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) 
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion


        #region Operadores

        /// <summary>
        /// Compara un alumno y una clase segun la clase que toma y el estado de su cuenta
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>si el alunmo toma la clase devuelve true, caso contrario, devuelve false</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Un Alumno será distinto a una Clase sólo si no toma esa clase.
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>Si el alumno no toma la clase devuelve true, caso contrario, devuelve false</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if(a.claseQueToma != clase)
            {
                return true;
            }
            return false;
        }

        #endregion


        #region Métodos

        /// <summary>
        /// Genera un String con todos los datos de un Alumno.
        /// </summary>
        /// <returns>Todosl os datos de un alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }


        /// <summary>
        /// Sobrecarga el metodo toString haciendo públicos los datos de un alumno
        /// </summary>
        /// <returns>Todos los datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }


        /// <summary>
        /// Genera un string que indica la clase en la que participa un alumno.
        /// </summary>
        /// <returns>En que clase participa un alumno</returns>
        protected override string ParticiparEnClase()
        {
            return String.Format($"TOMA CLASE DE: {this.claseQueToma}");
        }

        #endregion     
    }
}
