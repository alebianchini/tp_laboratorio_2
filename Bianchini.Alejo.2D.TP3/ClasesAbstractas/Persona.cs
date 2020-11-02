using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        #region Atributos

        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;

        #endregion


        #region Enumerado
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion


        #region Propiedades

        /// <summary>
        /// Propiedad que obtiene o modifica el atributo Nombre de una persona
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set
            {
                if (ValidarNombreApellido(value) != null)
                {
                    this.nombre = value;
                }
            }
        }


        /// <summary>
        /// Propiedad que obtiene o modifica el atributo Apellido de una persona
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set
            {
                if (ValidarNombreApellido(value) != null)
                {
                    this.apellido = value;
                }
            }
        }


        /// <summary>
        /// Propiedad que obtiene o modifica el atributo Dni de una persona
        /// </summary>
        public int Dni
        {
            get { return this.dni; }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }


        /// <summary>
        /// Propiedad que obtiene o modifica el atributo Nacionalidad de una persona
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get {  return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }


        /// <summary>
        /// Propiedad que modifica el atributo Dni de una persona, recibiendo el dato como string y seteandolo como int
        /// </summary>
        public string StringToDni
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);

            }
        }

        #endregion


        #region Constructores

        /// <summary>
        /// Constructor por defecto que inicializa una persona
        /// </summary>
        public Persona()
        {

        }


        /// <summary>
        /// Hereda el constructor por defecto e inicializa una persona sin el atributo dni
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }


        /// <summary>
        /// Hereda el constructor e inicializa una persona con todos sus atributos
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">Dni de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.Dni = dni;
        }


        /// <summary>
        ///  Hereda el constructor e inicializa una persona recibiendo todos sus atributos, pero el atributo dni como tipo string
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">Dni de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }
        #endregion


        #region Métodos

        /// <summary>
        /// Sobrecarga el método toString haciendo públicos los datos de una persona
        /// </summary>
        /// <returns>Devuelve un string con todos los datons de una persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}");
            sb.AppendLine($"DNI: {this.Dni}");
            sb.AppendLine($"NACIONALIDAD: {this.Nacionalidad}");
            return sb.ToString();
        }


        /// <summary>
        /// Valida el atributo dni del tipo int
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Si es valido retorna el atributo, caso contrario lanza una excepcion</returns>
        protected int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if ((ENacionalidad.Argentino == nacionalidad && dato >= 1 && dato <= 89999999) || 
                (ENacionalidad.Extranjero == nacionalidad && dato >= 90000000 && dato <= 99999999))
            {
                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
        }


        /// <summary>
        /// Valida el atributo dni del tipo string
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Si es valido retorna el atributo, caso contrario lanza una excepcion</returns>
        protected int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (!string.IsNullOrEmpty(dato) && dato.Length > 0 && dato.Length < 9)
            {
                foreach (char caracter in dato)
                {
                    if (!char.IsDigit(caracter))
                    {
                        throw new DniInvalidoException("Dni con caracter invalido");
                    }
                }
                return ValidarDni(nacionalidad, int.Parse(dato));
            }
            else
            {
                throw new DniInvalidoException("Dni vacio o con mas digitos de lo permitido");
            }
        }


        /// <summary>
        /// Valida los atributo nombre y apellido del tipo string
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>Devuelve el atributo si es valido, caso contrario retorna null</returns>
        protected string ValidarNombreApellido(string dato)
        {
            string retorno = string.Empty;
            bool flag = false;
            if (!string.IsNullOrEmpty(dato))
            {
                foreach (char caracter in dato)
                {
                    if (!char.IsLetter(caracter) && (char.IsWhiteSpace(caracter) && flag))
                    {
                        return retorno;
                    }
                    else if (char.IsWhiteSpace(caracter))
                    {
                        flag = true;
                    }
                }
                retorno = dato;
            }
            return retorno;
        }

        #endregion
    }
}

