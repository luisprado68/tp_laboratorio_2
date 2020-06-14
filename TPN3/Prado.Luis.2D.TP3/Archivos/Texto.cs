using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Archivos
{
    [Serializable]
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
            FileStream file = new FileStream(archivo, FileMode.Create);

            BinaryFormatter binario = new BinaryFormatter();

            binario.Serialize(file, datos.Trim());

            file.Close();
            return true;
        }

        /// <summary>
        /// Leera un archivo de texto pasado por el parametro archivo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>True en caso de que haya podido leerlo</returns>
        public bool Leer(string archivo, out string datos)
        {
            FileStream file = new FileStream(archivo, FileMode.Open);

            BinaryFormatter binario = new BinaryFormatter();

            datos = (string)binario.Deserialize(file);

            file.Close();

            return true;
        }
    }
}
