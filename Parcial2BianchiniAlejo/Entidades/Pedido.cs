using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedido<T> where T : Producto
    {
        Cliente cliente;
        List<ArticuloPedido<T>> productos;
        double precioTotal;
        string codigo;
        bool delivery;
        int tiempoPreparacion;

        public Pedido()
        {
            this.productos = new List<ArticuloPedido<T>>();
            this.delivery = false;
            this.tiempoPreparacion = 0;
        }

        public Pedido(Cliente cliente, double precioTotal, bool delivery) : this()
        {
            this.cliente = cliente;
            this.precioTotal = precioTotal;
            this.delivery = delivery;
        }

        public Pedido(Cliente cliente, double precioTotal, bool delivery ,string codigo) : this(cliente, precioTotal, delivery)
        {
            this.codigo = codigo;
        }

        public Cliente Cliente
        {
            get { return cliente; }
            set { this.cliente = value; }
        }

        public double PrecioTotal
        {
            get { return precioTotal; }
            set { this.precioTotal = value; }
        }

        public List<ArticuloPedido<T>> Productos
        {
            get { return productos; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { this.codigo = value; }
        }

        public string DeliveryString
        {
            get { return delivery.ToString(); }
            set
            {
                if(value == "true")
                {
                    this.delivery = true;
                }
                else
                {
                    this.delivery = false;
                }
            }
        }

        public bool Delivery
        {
            get { return delivery; }
            set { this.delivery = value; }
        }

        public int TiempoPreparacion
        {
            get { return tiempoPreparacion; }
        }

        /// <summary>
        /// Agrega un artículo a la lista de ArticuloPedidos del Pedido, sumando su valor al precioTotal.
        /// </summary>
        /// <param name="articuloPedido"></param>
        public void AgregarArticulo(ArticuloPedido<T> articuloPedido)
        {
            precioTotal += articuloPedido.PrecioFinal;

            if (Productos.Exists(x => x.IdProducto == articuloPedido.IdProducto))
            {
                ArticuloPedido<T> auxArt = Productos.Find(x => x.IdProducto == articuloPedido.IdProducto);
                auxArt.Cantidad += articuloPedido.Cantidad;
                auxArt.PrecioFinal = auxArt.Cantidad * auxArt.PrecioUnitario;
            }
            else
            {
                productos.Add(articuloPedido);
            }
        }

        public void CalcularTiempoPreparación()
        {
            int tiempo = 0;
            Comida auxComida = new Comida();
            Bebida auxBebida = new Bebida();
            foreach (var item in this.productos)
            {
                if(item.producto.GetType().IsInstanceOfType(auxComida))
                {
                    auxComida = Comercio.ListaComidas.FindComidaInList(item.IdProducto);
                    tiempo += (auxComida.CalcularTiempoPreparación() * item.Cantidad);
                }
                else if(item.producto.GetType().IsInstanceOfType(auxBebida))
                {
                    auxBebida = Comercio.ListaBebidas.FindBebidaInList(item.IdProducto);
                    tiempo += (auxBebida.CalcularTiempoPreparación() * item.Cantidad);
                }
            }
            if(this.delivery)
            {
                tiempo += 5000;
            }
            this.tiempoPreparacion = tiempo;
        }

        /// <summary>
        /// Convierte los datos de un Pedido en un string
        /// </summary>
        /// <returns>Retorna un string formateado con todos los datos del Pedido en formato de Ticket</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Fecha de Compra: {this.codigo}");
            sb.AppendLine("-------------------------------------------------");
            sb.AppendLine("Datos del Cliente: ");
            sb.AppendLine($"\tNombre completo: {this.cliente.Nombre} {this.cliente.Apellido}");
            sb.AppendLine($"\tDNI: {this.cliente.Dni.ToString()}");
            sb.AppendLine($"\tDireccion: {this.cliente.Direccion}");
            sb.AppendLine("-------------------------------------------------");
            sb.AppendLine("Productos");

            foreach (var p in this.productos)
            {
                sb.AppendLine($"{p.Producto}\t\t\t x{p.Cantidad}  ${p.PrecioFinal}");
            }

            sb.AppendLine($"Precio Total: \t\t\t${this.precioTotal}");
            sb.AppendLine("-------------------------------------------------");
            sb.AppendLine($"Gracias por su compra!");
            return sb.ToString();
        }
    }
}
