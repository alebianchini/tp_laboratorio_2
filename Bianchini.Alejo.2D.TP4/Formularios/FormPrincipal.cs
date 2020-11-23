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
using System.Threading;

namespace Formularios
{
    public delegate void DelegadoVenta();
    public partial class FormPrincipal : Form
    {
        public static event DelegadoVenta eventoVenta;
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            txbEmpleado.Text = $"Empleado logueado: {Walmart.EmpleadoActivo.Nombre}";
            dgvAlimentos.DataSource = Walmart.ListaAlimentos;
            dgvIndumentaria.DataSource = Walmart.ListaIndumentaria;
            eventoVenta += Walmart.SetearCompraEnCurso;
            eventoVenta += Walmart.ActualizarStock;
            eventoVenta += Walmart.GenerarTicket;
        }

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnAddPrenda_Click(object sender, EventArgs e)
        {
            bool asd = int.TryParse(txbCantidad.Text, out int cantidad);
            Indumentaria auxProducto = (Indumentaria)dgvIndumentaria.CurrentRow.DataBoundItem;
            if (!Walmart.AgregarIndumentariaAlCarrito(new ArticuloCompra<Producto>(cantidad, auxProducto, (auxProducto.PrecioUnitario * cantidad), auxProducto.PrecioUnitario)))
            {
                MessageBox.Show($"La cantidad de {auxProducto.Descripcion} solicitada excede el stock disponible!");
            }
            else
            {
                this.dgvCarrito.DataSource = null;
                this.dgvCarrito.DataSource = Walmart.CompraEnCurso.Productos;
                this.txbPrecioFinal.Text = $"${Walmart.CompraEnCurso.PrecioTotal.ToString()}";
            }
        }

        private void btnAddAlimento_Click(object sender, EventArgs e)
        {
            bool asd = int.TryParse(txbCantidad.Text, out int cantidad);
            Alimento auxProducto = (Alimento)dgvAlimentos.CurrentRow.DataBoundItem;
            if (!Walmart.AgregarAlimentoAlCarrito(new ArticuloCompra<Producto>(cantidad, auxProducto, (auxProducto.PrecioUnitario * cantidad), auxProducto.PrecioUnitario)))
            {
                MessageBox.Show($"La cantidad de {auxProducto.Descripcion} solicitada excede el stock disponible!");
            }
            else
            {
                this.dgvCarrito.DataSource = null;
                this.dgvCarrito.DataSource = Walmart.CompraEnCurso.Productos;
                this.txbPrecioFinal.Text = $"${Walmart.CompraEnCurso.PrecioTotal.ToString()}";
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Walmart.LimpiarCarrito();
            dgvCarrito.DataSource = null;
            this.txbPrecioFinal.Text = "";
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            if (Walmart.CompraEnCurso.Productos.Count >= 1)
            {
                eventoVenta.Invoke();
                this.dgvCarrito.DataSource = null;
                dgvAlimentos.DataSource = null;
                dgvIndumentaria.DataSource = null;
                dgvAlimentos.DataSource = Walmart.ListaAlimentos;
                dgvIndumentaria.DataSource = Walmart.ListaIndumentaria;
                this.txbPrecioFinal.Text = "";
                MessageBox.Show("Gracias por su compra!!");
            }
        }

        private void nuevoProductoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Thread hiloAddAli = new Thread(this.StartNewAlimento);
            hiloAddAli.Start();
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hiloAddPrenda = new Thread(this.StartNewIndumentaria);
            hiloAddPrenda.Start();
        }

        private void agregarStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hiloStockIndu = new Thread(this.StartStockIndumentaria);
            hiloStockIndu.Start();
        }

        private void agregarStockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Thread hiloStockAli = new Thread(this.StartStockAlimento);
            hiloStockAli.Start();
        }

        private void StartNewAlimento()
        {
            FormAltaAlimento auxForm = new FormAltaAlimento(this);
            auxForm.ShowDialog();
        }

        private void StartNewIndumentaria()
        {
            FormAltaIndumentaria auxForm = new FormAltaIndumentaria(this);
            auxForm.ShowDialog();
        }

        private void StartStockAlimento()
        {
            FormStockAlimento auxForm = new FormStockAlimento(this);
            auxForm.ShowDialog();
        }

        private void StartStockIndumentaria()
        {
            FormStockIndumentaria auxForm = new FormStockIndumentaria(this);
            auxForm.ShowDialog();
        }
    }
}
