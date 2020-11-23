using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Formularios;
using Excepciones;
using Archivos;
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
        /// Verifica que se instancie la lista de tipo ArticuloCompra al instanciar un objeto de tipo Compra
        /// </summary>
        [TestMethod]
        public void ListaArticuloCompra_Test()
        {
            Compra<Producto> v = new Compra<Producto>();

            Assert.IsNotNull(v.Productos);
        }

        /// <summary>
        /// Verifica que se agregue un Alimento a una lista de Alimentos utilizando la sobrecarga del operador +
        /// </summary>
        [TestMethod]
        public void TestProductAddList()
        {
            Alimento p = new Alimento(1, "budin", 15, 150, ETipo.perecedero);
            List<Alimento> list = new List<Alimento>();

            bool r = p + list;

            Assert.IsTrue(r);
        }
    }
}
