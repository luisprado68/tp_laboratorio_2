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

namespace FrmMiCalculadora
{
    public partial class FormCalculadora : Form
    {

        /// <summary>
        /// Constructor de el formulario
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// Convierte el decimal a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero3 = new Numero();

            lblResultado.Text= numero3.DecimalBinario(textNumero1.Text);
        }

        /// <summary>
        /// Convierte el Binario a Decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero3 = new Numero();
            lblResultado.Text = numero3.BinarioDecimal(textNumero1.Text);
        }
        /// <summary>
        /// Limpia los controles de textbox,label,combobox
        /// </summary>
        /// <param name="formu"></param>
        public static void Limpiar(Form formu)
        {
            // Recorrer todos los controles del formulario
            foreach (Control controles in formu.Controls)
            {
                if (controles is TextBox )
                {
                    controles.Text = "";            
                   // Eliminar el texto del TextBox
                }
                if (controles is Label)
                {
                    controles.Text = "";
                    // Eliminar el texto del Label
                }
                if (controles is ComboBox)
                {
                    controles.Text = "";
                    // Eliminar el texto del Combobox
                }
            }
        }
        /// <summary>
        /// Llamo a la funcion limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar(this);
        }
        /// <summary>
        /// Realiza la operacion correspondiente recibir con los numeros y operador correpondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            
            Numero numero1 = new Numero(textNumero1.Text);
            Numero numero2 = new Numero(textNumero2.Text);

            
            double resultado=Calculadora.Operar(numero1, numero2, cmbOperador.Text);
            lblResultado.Text = resultado.ToString();


        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
      
    }
}
