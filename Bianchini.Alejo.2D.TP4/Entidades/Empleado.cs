using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado
    {
        int id;
        string nombre;
        int dni;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Empleado()
        {

        }

        /// <summary>
        /// Construye un Empleado con todos sus atributos.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="dni"></param>
        public Empleado(int id, string nombre, int dni)
        {
            this.id = id;
            this.nombre = nombre;
            this.dni = dni;
        }

        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { this.nombre = value; }
        }

        public int Dni
        {
            get { return dni; }
            set { this.dni = value; }
        }

        /// <summary>
        /// Convierte los datos de un empleado en un string
        /// </summary>
        /// <returns>Retorna un string formateado con todos los datos de un empleado</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ID: " + this.id.ToString());
            sb.AppendLine("Nombre: " + this.nombre);
            sb.AppendLine("DNI: " + this.dni.ToString());
            return sb.ToString();
        }
    }
}
