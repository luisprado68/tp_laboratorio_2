using System;
using System.Collections.Generic;
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
        /// Guardara un archivo xml con los datos  del parametro datos 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {

            if (!string.IsNullOrEmpty(archivo) && datos != null)
            {
                try
                {

                    using (XmlTextWriter escribir = new XmlTextWriter(archivo, Encoding.UTF8))
                    {
                        XmlSerializer serializar = new XmlSerializer(typeof(T));

                        serializar.Serialize(escribir, datos);
                    }
                    return true;

                }
                catch (Exception ex)
                {
                    throw new ArchivosException(ex);
                }
            }

            return false;

        }

        /// <summary>
        /// Leera el archivo pasado por el parametro archivo 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>True en caso de poder leerlo y el objeto T</returns>
        public bool Leer(string archivo, out T datos)
        {
            datos = default(T);

            if (!string.IsNullOrEmpty(archivo) && datos != null)
            {
                try
                {
                    using (XmlTextReader leer = new XmlTextReader(archivo))
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(T));

                        datos = (T)ser.Deserialize(leer);

                        return true;
                    }


                }
                catch (Exception ex)
                {
                    throw new ArchivosException(ex);
                }
            }

            return false;

        }
    }
}
