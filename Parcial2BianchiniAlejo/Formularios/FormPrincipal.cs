using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Formularios
{
    public delegate void DelegadoCargaDatos();
    public partial class FormPrincipal : Form
    {
        public static event DelegadoCargaDatos eventoCargarDatos;
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            eventoCargarDatos += Comercio.CargarListaBebidas;
            eventoCargarDatos += Comercio.CargarListaComidas;
            eventoCargarDatos += Comercio.CargarColaPedidos;
            eventoCargarDatos.Invoke();
            RefrescarListViewPendientes();
            Thread hiloPreparaPedidos = new Thread(this.PrepararPedidos);
            hiloPreparaPedidos.Start();
        }

        private void btnAddPedido_Click(object sender, EventArgs e)
        {
            FormAltaPedido formAltaPedido = new FormAltaPedido();
            Thread hiloAltaPedido = new Thread(this.StartNewPedido);
            hiloAltaPedido.Start();
        }

        private void PrepararPedidos()
        {
            PedidoConfirmado auxPedido = new PedidoConfirmado();
            while(true)
            {
                if(Comercio.ColaPedidos.Count > 0)
                {
                    Thread.Sleep(Comercio.ColaPedidos.Peek().TiempoPreparacion);
                    auxPedido = Comercio.ColaPedidos.Dequeue();
                    Comercio.AgregarPedidoTerminado(auxPedido);
                    RefrescarListViewPendientes();
                    RefrescarListViewEntregados();
                }
            }
        }

        private void StartNewPedido()
        {
            FormAltaPedido auxForm = new FormAltaPedido();
            auxForm.ShowDialog();
            this.RefrescarListViewPendientes();
        }

        private void RefrescarListViewPendientes()
        {
            List<PedidoConfirmado> auxList = Comercio.ColaPedidos.ToList();

            if (lvPedidosPendientes.InvokeRequired)
            {
                lvPedidosPendientes.BeginInvoke((MethodInvoker)delegate ()
                {
                    lvPedidosPendientes.Items.Clear();
                    foreach (var item in auxList)
                    {
                        lvPedidosPendientes.Items.Add(item.ToString());
                    }
                }
                );
            }
            else
            {
                lvPedidosPendientes.Items.Clear();
                foreach (var item in auxList)
                {
                    lvPedidosPendientes.Items.Add(item.ToString());
                }
            }
        }

        private void RefrescarListViewEntregados()
        {
            if (lvPedidosEntregados.InvokeRequired)
            {
                lvPedidosEntregados.BeginInvoke((MethodInvoker)delegate ()
                {
                    lvPedidosEntregados.Items.Clear();
                    foreach (var item in Comercio.ListaEntregados)
                    {
                        lvPedidosEntregados.Items.Add(item.ToString());
                    }
                }
                );
            }
            else
            {
                lvPedidosEntregados.Items.Clear();
                foreach (var item in Comercio.ListaEntregados)
                {
                    lvPedidosEntregados.Items.Add(item.ToString());
                }
            }
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Comercio.GuardarColaPedidosPendientes();
        }

        private void btnAleatorios_Click(object sender, EventArgs e)
        {
            Comercio.TestGeneracionNuevosPedidos();
        }
    }
}
