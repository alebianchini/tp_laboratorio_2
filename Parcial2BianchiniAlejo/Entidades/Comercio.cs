using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Archivos;

namespace Entidades
{
    public static class Comercio
    {
        
        static List<Comida> listaComidas;
        static List<Bebida> listaBebidas;
        static Queue<PedidoConfirmado> colaPedidos;
        static List<PedidoConfirmado> listaEntregados;
        static Pedido<Producto> pedidoEnCurso = new Pedido<Producto>();

        static Comercio()
        {
            listaComidas = new List<Comida>();
            listaBebidas = new List<Bebida>();
            colaPedidos = new Queue<PedidoConfirmado>();
            listaEntregados = new List<PedidoConfirmado>();
        }

        public static List<Comida> ListaComidas
        {
            get { return listaComidas; }
        }

        public static List<Bebida> ListaBebidas
        {
            get { return listaBebidas; }
        }
        
        public static Queue<PedidoConfirmado> ColaPedidos
        {
            get { return colaPedidos; }
        }

        public static List<PedidoConfirmado> ListaEntregados
        {
            get { return listaEntregados; }
        }

        public static Pedido<Producto> PedidoEnCurso
        {
            get { return pedidoEnCurso; }
            set
            {
                if (value != null)
                    pedidoEnCurso = value;
            }
        }


        public static bool AgregarComidaAlPedido(ArticuloPedido<Producto> articuloPedido)
        {
            if (pedidoEnCurso.Productos.ExistsArticuloInList(articuloPedido.IdProducto))
            {
                if (listaComidas.FindComidaInList(articuloPedido.IdProducto).Stock >=
                        (articuloPedido.Cantidad + pedidoEnCurso.Productos.FindArticuloInList(articuloPedido.IdProducto).Cantidad))
                {
                    pedidoEnCurso.AgregarArticulo(articuloPedido);
                    return true;
                }
            }
            else
            {
                if (listaComidas.FindComidaInList(articuloPedido.IdProducto).Stock >= articuloPedido.Cantidad)
                {
                    pedidoEnCurso.AgregarArticulo(articuloPedido);
                    return true;
                }
            }

            return false;
        }

        public static bool AgregarBebidaAlPedido(ArticuloPedido<Producto> articuloPedido)
        {
            if (pedidoEnCurso.Productos.ExistsArticuloInList(articuloPedido.IdProducto))
            {
                if (listaBebidas.FindBebidaInList(articuloPedido.IdProducto).Stock >=
                        (articuloPedido.Cantidad + pedidoEnCurso.Productos.FindArticuloInList(articuloPedido.IdProducto).Cantidad))
                {
                    pedidoEnCurso.AgregarArticulo(articuloPedido);
                    return true;
                }
            }
            else
            {
                if (listaBebidas.FindBebidaInList(articuloPedido.IdProducto).Stock >= articuloPedido.Cantidad)
                {
                    pedidoEnCurso.AgregarArticulo(articuloPedido);
                    return true;
                }
            }

            return false;
        }

        public static void AgregarPedidoTerminado(PedidoConfirmado auxPedido)
        {
            listaEntregados.Add(auxPedido);
            PedidosDB.AgregarPedidoDB(auxPedido);
        }

        /// <summary>
        /// Establece el Codigo del pedido en base a la hora actual y los datos del cliente, a la hora de concretar el pedido.
        /// </summary>
        public static void SetearCompraEnCurso()
        {
            pedidoEnCurso.Codigo = DateTime.Now.ToString("HH-mm-ss");
            pedidoEnCurso.CalcularTiempoPreparación();
            PedidoConfirmado pedidoConfirmado = new PedidoConfirmado(pedidoEnCurso.Codigo, pedidoEnCurso.PrecioTotal, pedidoEnCurso.Delivery.ToString(), pedidoEnCurso.TiempoPreparacion);
            AgregarPedidoACola(pedidoConfirmado);
        }

        /// <summary>
        /// Actualiza el stock de los productos luego de confirmar un pedido, tanto en la ejecucion del programa como en los archivos Xml.
        /// </summary>
        public static void ActualizarStock()
        {
            foreach (ArticuloPedido<Producto> item in pedidoEnCurso.Productos)
            {
                if (listaComidas.Exists(x => x.Id.Equals(item.IdProducto)))
                {
                    Comida comidaAux = listaComidas.FindComidaInList(item.IdProducto);
                    comidaAux.Stock -= item.Cantidad;
                }
                else if (listaBebidas.Exists(x => x.Id.Equals(item.IdProducto)))
                {
                    Bebida bebidaAux = listaBebidas.FindBebidaInList(item.IdProducto);
                    bebidaAux.Stock -= item.Cantidad;
                }
                GuardarListaComidas();
                GuardarListaBebidas();
            }
        }

        /// <summary>
        /// Genera un ticket con los datos del pedido al momento de realizarse el mismo.
        /// </summary>
        public static void GenerarTicket()
        {
            string rutaArchivo = AppDomain.CurrentDomain.BaseDirectory + $"{ pedidoEnCurso.Codigo}.txt";
            string datos = pedidoEnCurso.ToString();
            Texto ticket = new Texto();
            if(ticket.Guardar(rutaArchivo, datos))
            {
                
            }
        }

        /// <summary>
        /// Agrega el nuevo pedido a la cola de pedidos
        /// </summary>
        public static void AgregarPedidoACola(PedidoConfirmado newPedido)
        {
            colaPedidos.Enqueue(newPedido);
        }

        public static void CancelarPedido()
        {
            pedidoEnCurso.Productos.Clear();
            pedidoEnCurso.PrecioTotal = 0;
        }

        public static void CargarListaComidas()
        {
            List<Comida> auxList = new List<Comida>();
            string rutaArchivo = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Comidas.xml");
            Xml<List<Comida>> archivoXml = new Xml<List<Comida>>();
            archivoXml.Leer(rutaArchivo, out auxList);
            listaComidas = auxList;
        }

        public static void CargarListaBebidas()
        {
            List<Bebida> auxList = new List<Bebida>();
            string rutaArchivo = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Bebidas.xml");
            Xml<List<Bebida>> archivoXml = new Xml<List<Bebida>>();
            archivoXml.Leer(rutaArchivo, out auxList);
            listaBebidas = auxList;
        }

        public static void CargarColaPedidos()
        {
            Queue<PedidoConfirmado> auxColaPedidos = new Queue<PedidoConfirmado>();
            List<PedidoConfirmado> auxList;
            string rutaArchivo = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Pedidos.xml");
            Xml<List<PedidoConfirmado>> archivoXml = new Xml<List<PedidoConfirmado>>();
            archivoXml.Leer(rutaArchivo, out auxList);
            foreach (var item in auxList)
            {
                auxColaPedidos.Enqueue(item);
            }
            colaPedidos = auxColaPedidos;
        }

        public static void GuardarListaBebidas()
        {
            string rutaArchivo = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Bebidas.xml");
            Xml<List<Bebida>> archivoXml = new Xml<List<Bebida>>();
            archivoXml.Guardar(rutaArchivo, listaBebidas);
        }

        public static void GuardarListaComidas()
        {
            string rutaArchivo = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Comidas.xml");
            Xml<List<Comida>> archivoXml = new Xml<List<Comida>>();
            archivoXml.Guardar(rutaArchivo, listaComidas);
        }

        public static void GuardarColaPedidosPendientes()
        {
            List<PedidoConfirmado> auxlist = colaPedidos.ToList();
            string rutaArchivo = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Pedidos.xml");
            Xml<List<PedidoConfirmado>> archivoXml = new Xml<List<PedidoConfirmado>>();
            archivoXml.Guardar(rutaArchivo, auxlist);

            //string rutaArchivo = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Pedidos.xml");
            //Xml<Queue<PedidoConfirmado>> archivoXml = new Xml<Queue<PedidoConfirmado>>();
            //archivoXml.Guardar(rutaArchivo, colaPedidos);
        }

        public static void TestGeneracionNuevosPedidos()
        {
            for (int i = 0; i < 10; i++)
            {
                colaPedidos.Enqueue(new PedidoConfirmado(DateTime.Now.ToString("HH-mm-ss"), 550, "false", 4000));
                Thread.Sleep(1000);
            }
        }
    }
}
