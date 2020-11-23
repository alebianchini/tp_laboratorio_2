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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Walmart.CargarDatos();
            List<Empleado> auxList = Walmart.ListaEmpleados;
            CargarEmpleados(auxList);
        }

        private void btnPepe_Click(object sender, EventArgs e)
        {
            List<Empleado> auxList = Walmart.ListaEmpleados;
            SetEmpleadoActivo(auxList[0]);
        }


        private void btnJulieta_Click(object sender, EventArgs e)
        {
            List<Empleado> auxList = Walmart.ListaEmpleados;
            SetEmpleadoActivo(auxList[1]);
        }

        private void btnAriel_Click(object sender, EventArgs e)
        {
            List<Empleado> auxList = Walmart.ListaEmpleados;
            SetEmpleadoActivo(auxList[2]);
        }

        private void SetEmpleadoActivo(Empleado empleado)
        {
            Walmart.EmpleadoActivo = empleado;
            FormPrincipal form = new FormPrincipal();
            this.Hide();
            form.ShowDialog();
        }

        /// <summary>
        /// Escribe los datos de los empleados en el formulario
        /// </summary>
        /// <param name="auxList"></param>
        private void CargarEmpleados(List<Empleado> auxList)
        {
            lbNombre1.Text = auxList[0].Nombre;
            lbDni1.Text = auxList[0].Dni.ToString();
            lbId1.Text = auxList[0].Id.ToString();
            lbNombre2.Text = auxList[1].Nombre;
            lbDni2.Text = auxList[1].Dni.ToString();
            lbId2.Text = auxList[1].Id.ToString();
            lbNombre3.Text = auxList[2].Nombre;
            lbDni3.Text = auxList[2].Dni.ToString();
            lbId3.Text = auxList[2].Id.ToString();
        }
    }
}
