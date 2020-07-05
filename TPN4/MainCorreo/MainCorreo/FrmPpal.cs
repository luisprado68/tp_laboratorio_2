using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        Correo correo;
        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
            Paquete.eventoErrorConexion += this.MensajeErrorCargaBD;
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(this.txtDireccion.Text, mtxtTrackingID.Text);
            
            paquete.InformaEstado += paq_InformaEstado;

            try
            {
                correo = correo + paquete;
            }
            catch (TrackingIdRepetidoException ex)
            {
                String mensaje = "El Tracking ID " + paquete.TrackingID + " ya figura en la lista de envios.";
                MessageBox.Show(mensaje, "Paquete repetido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ActualizarEstados();
        }

        /// <summary>
        /// Limpia los ListBox y obtiene los datos del paquete
        /// </summary>
        public void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete paquete in this.correo.Paquete)
            {
                switch (paquete.Estado)
                {
                    case EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(paquete);
                        break;
                    case EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    case EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(paquete);
                        break;
                }
            }
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        /// <summary>
        /// Finaliza todos los hilos activos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        private void btn_MostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!Object.Equals(elemento, null))
            {
                
                rtbMostrar.Text = elemento.MostrarDatos(elemento);

                String salida = rtbMostrar.Text;

                salida.Guardar("salida.txt");
            }
        }

        private void MensajeErrorCargaBD()
        {
            MessageBox.Show("Error de conexion a la base de datos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
