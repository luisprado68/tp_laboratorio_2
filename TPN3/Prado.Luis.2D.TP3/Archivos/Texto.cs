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
            try
            {
                StreamWriter escritura = new StreamWriter(archivo, true);

                escritura.WriteLine(datos.ToString());
                escritura.Close();

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

        }

        /// <summary>
        /// Leera un archivo de texto pasado por el parametro archivo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>True en caso de que haya podido leerlo</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                StreamReader lectura = new StreamReader(archivo, true);
                
                while ((datos = lectura.ReadLine()) != null)
                {
                    Console.WriteLine(datos);
                }
                lectura.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }
    }
}
