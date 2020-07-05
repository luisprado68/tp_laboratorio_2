using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        /// <summary>
        /// Insertara un paquete en la base de datos
        /// </summary>
        /// <param name="p">Paquete a insertar</param>
        /// <returns>retorna false si hubo un error</returns>
        public static bool Insertar(Paquete p)
        {
            String connectionStr = @"Data Source= DESKTOP-Q2NN84T;Initial Catalog = correo-sp-2017; Integrated Security = True";

            try
            {
                comando = new SqlCommand();
                conexion = new SqlConnection(connectionStr);

                conexion.Open();

                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conexion;

                StringBuilder str = new StringBuilder();

                str.Append("INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) VALUES(");
                str.Append("'" + p.DireccionEntrega + "',");
                str.Append("'" + p.TrackingID + "',");
                str.Append("'Luis Prado')");

                comando.CommandText = str.ToString();

                

                comando.ExecuteNonQuery();

            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                conexion.Close();
            }
            return true;
        }
    }
}
