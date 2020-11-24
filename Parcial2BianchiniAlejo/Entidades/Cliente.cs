using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        string nombre;
        string apellido;
        int dni;
        string direccion;

        public Cliente()
        {

        }

        public Cliente(string nombre, string apellido, int dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.direccion = "sin datos";
        }

        public Cliente(string nombre, string apellido, int dni, string direccion)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.direccion = direccion;
        }

        public string Nombre
        {
            get { return nombre; }
            set { this.nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { this.apellido = value; }
        }

        public int Dni
        {
            get { return dni; }
            set { this.dni = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { this.direccion = value; }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre completo: {this.nombre} {this.apellido}");
            sb.AppendLine($"DNI: {this.dni.ToString()}");
            sb.AppendLine($"Direccion: {this.direccion}");
            return sb.ToString();
        }
    }
}
