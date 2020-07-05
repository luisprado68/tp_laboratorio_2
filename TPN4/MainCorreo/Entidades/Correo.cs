using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Paquete> paquetes;
        private List<Thread> mockPaquetes;

        public List<Paquete> Paquete
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Termina todos los hilos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread hilo in mockPaquetes)
            {
                hilo.Abort();
            }
        }

        /// <summary>
        /// Crea una cadena de texto con los datos de los paquetes
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>retorna una cadena de texto</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder str = new StringBuilder();

            foreach (Paquete paquete in ((Correo)elemento).Paquete)
            {
                str.AppendLine(string.Format("{0} para {1} ({2})", paquete.TrackingID, paquete.DireccionEntrega, paquete.Estado.ToString()));
            }

            return str.ToString();
        }

        /// <summary>
        /// Agrega un paquete al correo, si  ya se encuentra cargado lanza excepcion luego inicializa un hilo con ese paquete
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns>retorna el correo</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paqueteEnCorreo in c.Paquete)
            {
                if (p == paqueteEnCorreo)
                {
                    throw new TrackingIdRepetidoException("Se intenta insertar un paquete ya insertado previamente");
                }
            }
            c.Paquete.Add(p);

            Thread hilo = new Thread(p.MockCicloDeVida);
            
            c.mockPaquetes.Add(hilo);
            
            hilo.Start();

            return c;
        }

    }

	

}
