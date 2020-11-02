using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Atributos

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #endregion


        #region Enumerado      
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        #endregion


        #region Propiedades

        /// <summary>
        /// Propiedad que muestra o modifica la lista de alummnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }


        /// <summary>
        ///  Propiedad que muestra o modifica la lista de profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }


        /// <summary>
        /// Propiedad que muestra o modifica la lista de Jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }


        /// <summary>
        /// Propiedad que muestra o modifica la jornada en el indice indicado.
        /// </summary>
        /// <param name="i">Indice</param>
        /// <returns>La jornada de ese indice</returns>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this.jornada.Count)
                {
                    return this.jornada[i];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (i >= this.jornada.Count)
                {
                    this.jornada.Add(value);
                }
            }
        }

        #endregion


        #region Constructor

        /// <summary>
        /// Constructor que instancia la lista de alumnos, de jornada y de profesores.
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }

        #endregion


        #region Operadores

        /// <summary>
        /// Iguala una universidad con una clase, para saber si hay un profesor que da esa clase.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Devuelve el profesor que puede dar la clase, si no encuentra uno lanza una excepcion</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.Instructores)
            {
                if (item == clase)
                {
                    return item;
                }

            }
            throw new SinProfesorException();
        }


        /// <summary>
        /// Iguala una universidad con una clase, para saber si hay un profesor que no da esa clase.
        /// </summary>
        /// <param name="u">Univesidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Devuelve el primer profesor que no da la clase, si no encuentra ninguno lanza una excepcion</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.Instructores)
            {
                if (item != clase)
                {
                    return item;
                }
            }
            throw new SinProfesorException();
        }


        /// <summary>
        /// Iguala una universidad y un profesor para saber si el mismo da clases en el.
        /// </summary>
        /// <param name="u">Univesidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Devuelve true si el profesor da clases en la universidad, caso contrario retorna false</returns>
        public static bool operator ==(Universidad u, Profesor i)
        {
            foreach (Profesor item in u.Instructores)
            {
                if (item == i)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Iguala una universidad y un profesor para saber si el mismo no da clases en el.
        /// </summary>
        /// <param name="u">Univesidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Devuelve true si el profesor no da clases en la universidad, caso contrario retorna false</returns>
        public static bool operator !=(Universidad u, Profesor i)
        {
            return !(u == i);
        }


        /// <summary>
        /// Iguala una universidad y un alumno para saber si el mismo esta inscripto
        /// </summary>
        /// <param name="u">Univesidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Devuelve true si el alumno esta inscripto en la universidad, caso contrario retorna false</returns>
        public static bool operator ==(Universidad u, Alumno a)
        {
            foreach (Alumno item in u.Alumnos)
            {
                if (item == a)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Iguala una universidad y un alumno para saber si el mismo no esta inscripto
        /// </summary>
        /// <param name="u">Univesidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Devuelve true si el alumno no esta inscripto en la universidad, caso contrario retorna false</returns>
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }


        /// <summary>
        /// Agrega una clase a una universidad, generando una nueva jornada indicando el profesor que puede darla y los alunmos que toman la clase.
        /// </summary>
        /// <param name="u">Univesidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Devuelve la universidad</returns>
        public static Universidad operator +(Universidad u, EClases clase)
        {
            Jornada j = new Jornada(clase, (u == clase));
            foreach (Alumno a in u.Alumnos)
            {
                if (a == clase)
                {
                    j.Alumnos.Add(a);
                }
            }
            u.jornada.Add(j);
            return u;
        }


        /// <summary>
        /// Agrega un alumno a una universidad, verificando que no este cargado previamente
        /// </summary>
        /// <param name="u">Univesidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Devuelve true si lo puedo agregar, caso contrario, lanza una excepcion</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {

            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }


        /// <summary>
        /// Agrega un profesor a una universidad, verificanod que no este cargado previamente
        /// </summary>
        /// <param name="u">Univesidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Devuelve la universidad</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {

            if (u != i)
            {
                u.Instructores.Add(i);
            }

            return u;
        }

        #endregion


        #region Metodos

        /// <summary>
        /// Muestra todos los datos del objeto de tipo Universidad recibido por parametro
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>una cadena con todos los datos del objeto de tipo Universidad recibido por parametro</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada item in uni.jornada)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Hace publicos los datos del metodo de clase MostrarDatos
        /// </summary>
        /// <returns>todos los datos del objeto de tipo Universidad</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Gestiona el archivo de un objeto de tipo Universidad en formato xml
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>true si se leyo correctamente, false caso contrario</returns>
        public static bool Guardar(Universidad uni)
        {
            string rutaArchivo = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Universidad.xml");
            Xml<Universidad> archivoXml = new Xml<Universidad>();

            return archivoXml.Guardar(rutaArchivo, uni);
        }

        /// <summary>
        /// Gestiona la lectura de objetos de tipo Universidad en formato xml
        /// </summary>
        /// <returns>Objeto de tipo Universidad</returns>
        public static Universidad Leer()
        {
            Universidad datos = new Universidad();
            string rutaArchivo = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Universidad.xml");
            Xml<Universidad> archivoXml = new Xml<Universidad>();

            archivoXml.Leer(rutaArchivo, out datos);

            return datos;

        }

        #endregion
    }
}
