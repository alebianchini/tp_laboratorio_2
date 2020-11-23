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

namespace Formularios
{
    public partial class FormStockIndumentaria : Form
    {
        FormPrincipal formPrincipal;
        public FormStockIndumentaria(FormPrincipal f1)
        {
            InitializeComponent();
            formPrincipal = f1;
        }

        private void FormStockIndumentaria_Load(object sender, EventArgs e)
        {
            dgvProductos.DataSource = Walmart.ListaIndumentaria;
            Indumentaria auxPrenda = (Indumentaria)dgvProductos.CurrentRow.DataBoundItem;
            lbCantidadActual.Text = auxPrenda.Stock.ToString();
            lbDescripcion.Text = auxPrenda.Descripcion;
            txbCantidad.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Indumentaria auxPrenda = (Indumentaria)dgvProductos.CurrentRow.DataBoundItem;
            Walmart.AgregarStockIndumentaria(auxPrenda.Id, Convert.ToInt32(txbCantidad.Text));
            ProductosDAO.ActualizarStockIndumentariaDB(auxPrenda);
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = Walmart.ListaIndumentaria;
            txbCantidad.Text = "";
            if (formPrincipal.dgvIndumentaria.InvokeRequired)
            {
                formPrincipal.dgvIndumentaria.BeginInvoke((MethodInvoker)delegate ()
                {
                    formPrincipal.dgvIndumentaria.DataSource = null;
                    formPrincipal.dgvIndumentaria.DataSource = Walmart.ListaIndumentaria;
                }
                );
            }
            else
            {
                formPrincipal.dgvIndumentaria.DataSource = null;
                formPrincipal.dgvIndumentaria.DataSource = Walmart.ListaIndumentaria;
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            Indumentaria auxPrenda = (Indumentaria)dgvProductos.CurrentRow.DataBoundItem;
            lbCantidadActual.Text = auxPrenda.Stock.ToString();
            lbDescripcion.Text = auxPrenda.Descripcion;
            txbCantidad.Text = "";
        }

        private void txbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
