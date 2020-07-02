using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{

    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guardara el contenido de datos en un archivo de Texto 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>True en caso de generar el archivo correctamente</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;

            if (!string.IsNullOrEmpty(archivo) && !string.IsNullOrEmpty(datos))
            {
                try
                {
                    using (StreamWriter escritura = new StreamWriter(archivo, true))
                    {
                        escritura.WriteLine(datos.ToString());

                        retorno = true;
                    }

                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }

            return retorno;
        }

        /// <summary>
        /// Leera un archivo de texto pasado por el parametro archivo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>True en caso de que haya podido leerlo de lo contrario falso y vacio los datos</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            datos = "";

            if (!string.IsNullOrEmpty(archivo) && !string.IsNullOrEmpty(datos))
            {
                try
                {
                    using (StreamReader lectura = new StreamReader(archivo, true))
                    {
                        while ((datos = lectura.ReadLine()) != null)
                        {
                            Console.WriteLine(datos);
                        }

                        retorno = true;
                    }

                }
                catch (Exception ex)
                {
                    throw new ArchivosException(ex);
                }
            }

            return retorno;

        }
    }
}
