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
    public partial class FormStockAlimento : Form
    {
        FormPrincipal formPrincipal;
        public FormStockAlimento(FormPrincipal f1)
        {
            InitializeComponent();
            formPrincipal = f1;
        }

        private void FormStockAlimento_Load(object sender, EventArgs e)
        {
            dgvProductos.DataSource = Walmart.ListaAlimentos;
            Alimento auxAlimento = (Alimento)dgvProductos.CurrentRow.DataBoundItem;
            lbCantidadActual.Text = auxAlimento.Stock.ToString();
            lbDescripcion.Text = auxAlimento.Descripcion;
            txbCantidad.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Alimento auxAlimento = (Alimento)dgvProductos.CurrentRow.DataBoundItem;
            Walmart.AgregarStockAlimento(auxAlimento.Id, Convert.ToInt32(txbCantidad.Text));
            ProductosDAO.ActualizarStockAlimentoDB(auxAlimento);
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = Walmart.ListaAlimentos;
            txbCantidad.Text = "";
            if (formPrincipal.dgvAlimentos.InvokeRequired)
            {
                formPrincipal.dgvAlimentos.BeginInvoke((MethodInvoker)delegate ()
                {
                    formPrincipal.dgvAlimentos.DataSource = null;
                    formPrincipal.dgvAlimentos.DataSource = Walmart.ListaAlimentos;
                }
                );
            }
            else
            {
                formPrincipal.dgvAlimentos.DataSource = null;
                formPrincipal.dgvAlimentos.DataSource = Walmart.ListaAlimentos;
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            Alimento auxAlimento = (Alimento)dgvProductos.CurrentRow.DataBoundItem;
            lbCantidadActual.Text = auxAlimento.Stock.ToString();
            lbDescripcion.Text = auxAlimento.Descripcion;
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
