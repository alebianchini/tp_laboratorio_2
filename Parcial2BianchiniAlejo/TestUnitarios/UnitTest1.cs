using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Archivos;
using Formularios;
using Excepciones;
using System.Collections.Generic;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Verifica que la exception "ArchivosException" se lance cuando se intenta leer un archivo inexistente.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void TestExepcionArchivo()
        {
            Texto auxArchivo = new Texto();
            string auxDato;

            auxArchivo.Leer("ArchivoInexistente", out auxDato);
        }

        /// <summary>
        /// Verifica que se instancie la lista de tipo ArticuloPedido al instanciar un objeto de tipo Pedido
        /// </summary>
        [TestMethod]
        public void ListaArticuloCompra_Test()
        {
            Pedido<Producto> v = new Pedido<Producto>();

            Assert.IsNotNull(v.Productos);
        }

        /// <summary>
        /// Verifica que se agregue una Bebida a una lista de Bebidas utilizando la sobrecarga del operador +
        /// </summary>
        [TestMethod]
        public void TestProductAddList()
        {
            Bebida p = new Bebida(6500, "Licuado", 56, 50, EBebida.sinAlcohol);
            List<Bebida> list = new List<Bebida>();

            bool r = p + list;

            Assert.IsTrue(r);
        }
    }
}
