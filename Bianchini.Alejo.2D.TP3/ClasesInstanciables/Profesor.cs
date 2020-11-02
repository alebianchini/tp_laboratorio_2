using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;
using Excepciones;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos

        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #endregion


        #region Constructores

        /// <summary>
        ///  Constructor estático que inicializa el atributo random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }


        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Profesor(): base()
        {

        }


        /// <summary>
        /// Inicializa un objeto del tipo profesor con todos sus datos y una Cola de EClases con dos clases Random.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion


        #region Operadores

        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i">un profesor</param>
        /// <param name="clase">una clase</param>
        /// <returns>Si el profesor da la clase devuelve true, caso contrario, devuelve false</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Un Profesor será distinto a un EClase si no da esa clase.
        /// </summary>
        /// <param name="i">un profesor</param>
        /// <param name="clase">una clase</param>
        /// <returns>Si el profesor no da la clase devuelve true, caso contrario, devuelve false</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion


        #region Métodos

        /// <summary>
        /// Asigna dos clases random a un porfesor
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            }
        }


        /// <summary>
        /// Genera un string que indica las clases que el profesor tiene el dia de la fecha.
        /// </summary>
        /// <returns>Un string con las clases en las que participa un profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }


        /// <summary>
        /// Genera un String con todos los datos de un profesor
        /// </summary>
        /// <returns>Un String con todos los datos de un profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }


        /// <summary>
        /// Hace publicos los datos de un profesor
        /// </summary>
        /// <returns>Un string con todos los datos del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion
    }
}
