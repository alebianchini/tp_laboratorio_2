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
        Numero n1;
        Numero n2;
        Numero Resultado;
        string operador;
        int flag = 0;
        public FormCalculadora()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }


        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            n1 = new Numero();
            n2 = new Numero();
            this.lblResultado.Text = "0";
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;
            Numero numAux1 = new Numero(numero1);
            Numero numAux2 = new Numero(numero2);

            resultado = Calculadora.Operar(numAux1,numAux2,operador);
            return resultado;
        }

        private void Limpiar()
        {
            flag = 0;
            this.txtNumero1.Text = String.Empty;
            this.txtNumero2.Text = String.Empty;
            this.lblResultado.Text = "0";
            this.cmbOperador.SelectedItem = String.Empty;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            flag = 0;
            this.lblResultado.Text = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text != "0" && this.lblResultado.Text != "Valor Invalido" && flag != 1)
            {
                this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text);
                flag = 1;
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text != "0" && this.lblResultado.Text != "Valor Invalido")
            {
                this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text);
                flag = 0;
            }
        }
    }
}
