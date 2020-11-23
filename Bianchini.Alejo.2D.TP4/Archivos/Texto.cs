using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Lee los datos en un archivo de texto y los guarda en un String que recibe por parametro.
        /// </summary>
        /// <param name="archivo">ruta de archivo/param>
        /// <param name="datos">datos recibidos</param>
        /// <returns> retorna true si logro leer los datos, caso contrario, lanza una excepcion</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                datos = String.Empty;
                if (File.Exists(archivo))
                {
                    using (StreamReader auxArchivo = new StreamReader(archivo))
                    {
                        datos = auxArchivo.ReadToEnd();
                    }
                    return true;
                }
                else
                {
                    throw new ArchivosException("El archivo que se intento leer no existe");
                }
            }
            catch (Exception)
            {
                throw new ArchivosException("Error al intentar leer el archivo de texto");
            }
        }

        /// <summary>
        /// Guarda todos los datos del string que recibe por parametro en un archivo de texto en la ruta indicada
        /// </summary>
        /// <param name="archivo">ruta de archivo</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns> retorna true si logro guardar los datos, caso contrario, lanza una excepcion</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                if (!String.IsNullOrEmpty(archivo))
                {
                    using (StreamWriter auxArchivo = new StreamWriter(archivo, false))
                    {
                        auxArchivo.WriteLine(datos);
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                throw new ArchivosException("Error al intentar grabar en el archivo de texto");
            }
            return false;
        }
    }
}
