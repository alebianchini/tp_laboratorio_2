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
    public partial class FormAltaIndumentaria : Form
    {
        FormPrincipal formPrincipal;
        public FormAltaIndumentaria(FormPrincipal f1)
        {
            InitializeComponent();
            formPrincipal = f1;
        }

        private void FormAltaIndumentaria_Load(object sender, EventArgs e)
        {
            cbTalle.DataSource = Enum.GetValues(typeof(ETalle));
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txbDescripcion.Text)) && !(string.IsNullOrEmpty(txbPrecio.Text)) && 
                !(string.IsNullOrEmpty(txbStock.Text)) && !(string.IsNullOrEmpty(txbColor.Text)) && !(string.IsNullOrEmpty(cbTalle.Text)))
            {
                if (!Walmart.ListaIndumentaria.ExistsIndumentariaInList(txbDescripcion.Text))
                {
                    Indumentaria prendaAux = new Indumentaria(Walmart.ListaIndumentaria.Count + 3001, txbDescripcion.Text, Convert.ToInt32(txbStock.Text),
                        txbColor.Text ,Convert.ToDouble(txbPrecio.Text), (ETalle)cbTalle.SelectedItem);
                    string r = Walmart.AgregarNuevaIndumentaria(prendaAux);
                    MessageBox.Show(r);
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
                else
                {
                    MessageBox.Show("Esa Indumentaria ya existe");
                }
            }
            else
            {
                MessageBox.Show("Primero ingrese datos en los campos");
            }
        }
    }
}
