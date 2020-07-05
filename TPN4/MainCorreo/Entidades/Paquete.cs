using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public delegate void delegadoErrorConexion();
        public static event delegadoErrorConexion eventoErrorConexion;

        public delegate void DelegadoEstado(Object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;

        


        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            string datos;
            
            datos = string.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).direccionEntrega);

            return datos;
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Cambia de estado de los paquetes  e  inserta el paquete en la base de datos
        /// En caso de que falle lanza el evento eventoErrorConexion 
        /// </summary>
        public void MockCicloDeVida()
        {
            while (Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                Estado++;
                InformaEstado(this, null);
            }

            if (!(PaqueteDAO.Insertar(this)))
            {
                Paquete.eventoErrorConexion();
            }
        }

        /// <summary>
        /// Compara  el TrackingID entre dos paquetes 
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>true si es igual, caso contrario false</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.TrackingID.Equals(p2.TrackingID));
        }

        
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return (!(p1 == p2));
        }
    }

}

