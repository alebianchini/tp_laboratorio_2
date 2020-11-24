using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Archivos;
using Excepciones;

namespace Formularios
{
    public delegate void DelegadoPedido();
    public partial class FormAltaPedido : Form
    {
        public static event DelegadoPedido eventoPedido;
  
        public FormAltaPedido()
        {
            InitializeComponent();
        }

        private void FormAltaPedido_Load(object sender, EventArgs e)
        {
            dgvComidas.DataSource = Comercio.ListaComidas;
            dgvBebidas.DataSource = Comercio.ListaBebidas;
            Comercio.PedidoEnCurso = new Pedido<Producto>();
            Comercio.PedidoEnCurso.DeliveryString = "false";
            eventoPedido += Comercio.SetearCompraEnCurso;
            eventoPedido += Comercio.ActualizarStock;
            eventoPedido += Comercio.GenerarTicket;
        }

        private void btnAddComida_Click(object sender, EventArgs e)
        {
            bool asd = int.TryParse(txbCantidad.Text, out int cantidad);
            Comida auxProducto = (Comida)dgvComidas.CurrentRow.DataBoundItem;
            if (!Comercio.AgregarComidaAlPedido(new ArticuloPedido<Producto>(cantidad, auxProducto, (auxProducto.PrecioUnitario * cantidad), auxProducto.PrecioUnitario)))
            {
                MessageBox.Show($"La cantidad de {auxProducto.Descripcion} solicitada excede el stock disponible!");
            }
            else
            {
                this.dgvPedido.DataSource = null;
                this.dgvPedido.DataSource = Comercio.PedidoEnCurso.Productos;
            }
        }

        private void btnAddBebida_Click(object sender, EventArgs e)
        {
            bool asd = int.TryParse(txbCantidad.Text, out int cantidad);
            Bebida auxProducto = (Bebida)dgvBebidas.CurrentRow.DataBoundItem;
            if (!Comercio.AgregarBebidaAlPedido(new ArticuloPedido<Producto>(cantidad, auxProducto, (auxProducto.PrecioUnitario * cantidad), auxProducto.PrecioUnitario)))
            {
                MessageBox.Show($"La cantidad de {auxProducto.Descripcion} solicitada excede el stock disponible!");
            }
            else
            {
                this.dgvPedido.DataSource = null;
                this.dgvPedido.DataSource = Comercio.PedidoEnCurso.Productos;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente auxCliente;
                if (Comercio.PedidoEnCurso.Productos.Count >= 1)
                {

                    if (Comercio.PedidoEnCurso.Delivery)
                    {
                        if (string.IsNullOrWhiteSpace(txbDomicilio.Text))
                        {
                            throw new FaltaDomicilioException();
                        }
                        else
                        {
                            auxCliente = new Cliente(txbNombre.Text, txbApellido.Text, Convert.ToInt32(txbDni.Text), txbDomicilio.Text);
                            Comercio.PedidoEnCurso.Cliente = auxCliente;
                            eventoPedido.Invoke();
                            eventoPedido -= Comercio.SetearCompraEnCurso;
                            eventoPedido -= Comercio.ActualizarStock;
                            eventoPedido -= Comercio.GenerarTicket;
                        }
                    }
                    else
                    {
                        auxCliente = new Cliente(txbNombre.Text, txbApellido.Text, Convert.ToInt32(txbDni.Text));
                        Comercio.PedidoEnCurso.Cliente = auxCliente;
                        eventoPedido.Invoke();
                        eventoPedido -= Comercio.SetearCompraEnCurso;
                        eventoPedido -= Comercio.ActualizarStock;
                        eventoPedido -= Comercio.GenerarTicket;
                    }
                    MessageBox.Show($"El tiempo de preparación será de {Comercio.PedidoEnCurso.TiempoPreparacion / 1000f} segundos");
                    this.Close();
                }
                else
                {
                    throw new FaltaProductoException();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Comercio.CancelarPedido();
            dgvPedido.DataSource = null;
        }

        private void cbDelivery_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbDelivery.Text == "Si")
            {
                Comercio.PedidoEnCurso.DeliveryString = "true";
            }
            else
            {
                Comercio.PedidoEnCurso.DeliveryString = "false";
            }
        }
    }
}
