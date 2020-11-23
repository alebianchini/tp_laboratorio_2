using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Lee un archivo xml y guarda los datos en la variable que recibe por parametro.
        /// </summary>
        /// <param name="archivo">ruta de archivo</param>
        /// <param name="datos">datos a leer</param>
        /// <returns>retorna true si logro leer los datos, caso contrario, lanza una excepcion</returns>
        public bool Leer(string archivo, out T datos)
        {
            datos = default(T);
            if (File.Exists(archivo))
            {
                try
                {
                    using (XmlTextReader auxArchivo = new XmlTextReader(archivo))
                    {
                        XmlSerializer lector = new XmlSerializer(typeof(T));
                        datos = (T)lector.Deserialize(auxArchivo);
                        return true;
                    }
                }
                catch (Exception)
                {
                    throw new ArchivosException("Error al intentar leer el archivo Xml");
                }
            }
            return false;
        }

        /// <summary>
        /// Guarda datos serializados en un archivo Xml
        /// </summary>
        /// <param name="archivo">ruta de archivo</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns>retorna true si logro guardar los datos, caso contrario, lanza una excepcion</returns>
        public bool Guardar(string archivo, T datos)
        {
            if (!String.IsNullOrEmpty(archivo))
            {
                try
                {
                    using (XmlTextWriter auxArchivo = new XmlTextWriter(archivo, Encoding.UTF8))
                    {
                        XmlSerializer escritor = new XmlSerializer(typeof(T));
                        escritor.Serialize(auxArchivo, datos);
                        return true;
                    }
                }
                catch (Exception)
                {
                    throw new ArchivosException("Error al intentar grabar en el archivo Xml");
                }
            }
            return false;
        }
    }
}
