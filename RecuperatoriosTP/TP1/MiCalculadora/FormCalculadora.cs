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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        int flag;
        public FormCalculadora()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Borra los datos de los TextBox, ComboBox y Label de la pantalla.
        /// </summary>
        private void Limpiar()
        {
            flag = 0;
            this.txtNumero1.Text = String.Empty;
            this.txtNumero2.Text = String.Empty;
            this.lblResultado.Text = "0";
            this.cmbOperador.SelectedItem = String.Empty;
            this.cmbOperador.Text = String.Empty;
        }

        /// <summary>
        /// Realiza la operacion entre los datos que recibe por parametro. Invocando al metodo Operar de la clase Calculadora.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>Retorna el resultado de la opracion en formato double.</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;
            Numero numAux1 = new Numero(numero1);
            Numero numAux2 = new Numero(numero2);

            resultado = Calculadora.Operar(numAux1, numAux2, operador);
            return resultado;
        }

        /// <summary>
        /// Evento que tiene lugar cuando se hace click sobre el boton Operar.
        /// Reaiza la operacion entre los datos ingresados en los textBox y el operador ingresado en el comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            flag = 0;
            if(string.IsNullOrWhiteSpace(this.cmbOperador.Text))
            {
                this.cmbOperador.Text = "+";
            }
            this.lblResultado.Text = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
        }

        /// <summary>
        /// Evento que tiene lugar cuando se hace click sobre el boton Limpiar. Limpia los campos del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Evento que tiene lugar cuando se hace click sobre el boton Cerrar. Cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que tiene lugar cuando se hace click sobre el boton Convertir a binario. Convierte el valor escrito en lbResultado a Binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text != "0" && this.lblResultado.Text != "Valor Invalido" && flag != 1)
            {
                this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text);
                flag = 1;
            }
        }

        /// <summary>
        /// Evento que tiene lugar cuando se hace click sobre el boton Convertir a Decimal. Convierte el valor escrito en lbResultado a Decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text != "0" && this.lblResultado.Text != "Valor Invalido" && flag != 0)
            {
                this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text);
                flag = 0;
            }
        }

        /// <summary>
        /// Evento que tiene lugar cuando se intenta cerrar el Fomrulario. Consulta al usuario si realmente desea cerrar y valida su respuesta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Tiene lugar cuando se presiona una tecla dentro del comboBox, e impide que se pueda escribir en él.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbOperador_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
