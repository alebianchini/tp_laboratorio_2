using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PedidoConfirmado
    {
        string codigo;
        double precioFinal;
        string delivery;
        string direccion;
        int tiempoPreparacion;


        public PedidoConfirmado()
        {
            this.direccion = "no es para llevar";
            this.tiempoPreparacion = 0;
        }

        public PedidoConfirmado(string codigo, double precioFinal, string delivery, int tiempo):this()
        {
            this.codigo = codigo;
            this.precioFinal = precioFinal;
            this.delivery = delivery;
            this.tiempoPreparacion = tiempo;
        }

        public PedidoConfirmado(string codigo, double precioFinal, string delivery, string direccion, int tiempo):this(codigo,precioFinal,delivery,tiempo)
        {
            this.direccion = direccion;
        }

        public string Codigo
        {
            get { return codigo; }
            set { this.codigo = value; }
        }

        public double PrecioFinal
        {
            get { return precioFinal; }
            set { this.precioFinal = value; }
        }

        public string Delivery
        {
            get { return delivery; }
            set { this.delivery = value; }
        }

        public bool DeliveryOfBool
        {
            set { this.delivery = value.ToString(); }
        }

        public string Direccion
        {
            get { return direccion; }
            set { this.direccion = value; }
        }

        public int TiempoPreparacion
        {
            get { return tiempoPreparacion; }
            set { this.tiempoPreparacion = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Codigo: {this.codigo} Delivery: {this.delivery}");
            return sb.ToString();
        }
    }
}
