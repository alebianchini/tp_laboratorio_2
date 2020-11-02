using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using EntidadesAbstractas = ClasesAbstractas;
using Excepciones;
using Archivos;

namespace TestUnitarios
{
    [TestClass]
    public class MiTestUnitario
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestExepcionDniInvalido()
        {
            Profesor profersorPrueba = new Profesor(15, "Pepe", "Rodriguez", "156u9874", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
        }

        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void TestExepcionArchivo()
        {
            Texto auxArchivo = new Texto();
            string auxDato;

            auxArchivo.Leer("ArchivoInexistente", out auxDato);
        }

        [TestMethod]
        public void TestInstanciaColeccion()
        {
            Profesor auxProfesor = new Profesor(20, "Ricardo", "Flores", "98465412", EntidadesAbstractas.Persona.ENacionalidad.Extranjero);
            Jornada auxJornada = new Jornada(Universidad.EClases.SPD, auxProfesor);

            Assert.IsNotNull(auxJornada.Alumnos);
        }
    }
}
