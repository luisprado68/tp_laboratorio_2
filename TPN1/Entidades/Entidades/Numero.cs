using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{   
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Constructor que incializa numero en cero
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Constructor sobrecargado para setear el numero al atributo numero.
        /// </summary>
        /// <param name="numero">numero para pasar su valor a atrubuto numero</param>
        public Numero(double numero):this(numero.ToString())
        {
          
        }
        /// <summary>
        /// meteodo que setea el string recibido 
        /// </summary>
        /// <param name="strNumero">string que sera convertido en double para asignar a atributo numero</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        /// <summary>
        /// Seteara el numero validado
        /// </summary>
        public string SetNumero
        {
            set 
            { 
                this.numero = ValidarNumero(value);
            }
        }
        /// <summary>
        /// Validara si el string recibido es entero 
        /// </summary>
        /// <param name="strNumero">string a validar</param>
        /// <returns>Retornara el enetero si es correcto caso contrario un cero</returns>
        private double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, out double numero))
            {
                return numero;
            }
            return 0;
        }
        /// <summary>
        /// Convierte un Binario  a Decimal
        /// </summary>
        /// <param name="binario">el numero binario a convertir</param>
        /// <returns>retorna el binario convertido en decimal caso contrario devuelve valor invalido</returns>
        public string BinarioDecimal(string binario)
        {
            int numero;

            if(int.TryParse(binario, out numero)&& numero > 0)
            {
                int resto;
                int exponente = 0;
                int resultado = 0;

                // Entera la primera vez y obtiene restp y numero
                do
                {
                    resto = numero % 10;

                    numero = numero / 10;
                    //obtengo el resultado multiplicando el exponen por dos y sumandolo al mismo
                    resultado = (int)(resto * Math.Pow(2, exponente)) + resultado;
                    exponente++;

                } while (numero != 0);

                return resultado.ToString();

            }

            return "Valor inválido";
        }
        /// <summary>
        /// Convierte de Decimal a Binario.Reutilizando el metodoDecimalBinario.
        /// </summary>
        /// <param name="numero">double a ser convertido</param>
        /// <returns>Retorna el string binario caso contrario valor invalido</returns>
        public string DecimalBinario(double numero)
        {
            
            return this.DecimalBinario(numero.ToString());
        }

        /// <summary>
        /// Convierte de Decimal a Binario.
        /// </summary>
        /// <param name="numero">string a ser convertido</param>
        /// <returns>Retorna el string binario caso contrario valor invalido</returns>
        public string DecimalBinario(string numero)
        {
            int a;
            if (int.TryParse(numero, out a) && a > 0)
            {
                string binario = "";

                while (a > 0)
                {
                    //guardo el resto en el string acumulandolo
                    binario = a % 2 + binario;
                    //Divido el entero y reemplazo su valor
                    a = a / 2;
                }
                return binario;
            }
                
            return "Valor inválido";
        }
        /// <summary>
        /// Suma los atributos de dos objeto Numero
        /// </summary>
        /// <param name="a">objeto Numero</param>
        /// <param name="b">objeto Numero</param>
        /// <returns>El resultado de la La suma de los numeros</returns>
        public static double operator +(Numero a, Numero b)
        {

            return  a.numero + b.numero;
        }

        /// <summary>
        /// Resta los atributos de dos objeto Numero
        /// </summary>
        /// <param name="a">objeto Numero</param>
        /// <param name="b">objeto Numero</param>
        /// <returns>El resultado de La Resta de los numeros</returns>
        public static double operator -(Numero a, Numero b)
        {

            return a.numero - b.numero;
        }

        /// <summary>
        /// Multiplica los atributos de dos objeto Numero
        /// </summary>
        /// <param name="a">objeto Numero</param>
        /// <param name="b">objeto Numero</param>
        /// <returns>El resultado de la  Multiplicacion de los numeros</returns>
        public static double operator *(Numero a, Numero b)
        {

            return a.numero * b.numero;
        }
        /// <summary>
        /// Divide los atributos de dos objeto Numero
        /// </summary>
        /// <param name="a">objeto Numero</param>
        /// <param name="b">objeto Numero</param>
        /// <returns>El resultado de La Division de los numeros si el atributo del segundo objeto es cero retorna el valor entero minimo</returns>
        public static double operator /(Numero a, Numero b)
        {
            if (b.numero == 0)
            {
                return double.MinValue;
            }
            return a.numero / b.numero;
        }
    }
}
