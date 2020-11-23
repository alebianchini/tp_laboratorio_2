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
    public partial class FormAltaAlimento : Form
    {
        FormPrincipal formPrincipal;
        public FormAltaAlimento(FormPrincipal f1)
        {
            InitializeComponent();
            formPrincipal = f1;
        }

        private void FormAltaAlimento_Load(object sender, EventArgs e)
        {
            cbCategoria.DataSource = Enum.GetValues(typeof(ETipo));
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txbDescripcion.Text != "" && txbPrecio.Text != "" && txbStock.Text != "" && cbCategoria.Text != "")
            {
                if(!Walmart.ListaAlimentos.ExistsAlimentoInList(txbDescripcion.Text))
                {
                    Alimento alimentoAux = new Alimento(Walmart.ListaAlimentos.Count + 1001, txbDescripcion.Text, Convert.ToInt32(txbStock.Text),
                        Convert.ToDouble(txbPrecio.Text), (ETipo)cbCategoria.SelectedItem);
                    string r = Walmart.AgregarNuevoAlimento(alimentoAux);
                    MessageBox.Show(r);
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
                else
                {
                    MessageBox.Show("Ese Alimento ya existe");
                }
            }
            else
            {
                MessageBox.Show("Primero ingrese datos en los campos");
            }
        }

    }
}
