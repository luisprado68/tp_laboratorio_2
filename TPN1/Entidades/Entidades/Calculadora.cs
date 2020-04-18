using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {   /// <summary>
        /// Valida si el el string recibido es uno de los operadores de la caluladora y lo devuelve.
        /// </summary>
        /// <param name="operador">el tipo de operacion a validar</param>
        /// <returns>Devuelve uno de los operadores si no, retorna +</returns>
        private static string ValidarOperador(string operador)
        {
            if(operador =="+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            return "+";
        }

        /// <summary>
        /// Realiza la operacion matematica dependiendo del operador recibido.
        /// </summary>
        /// <param name="numero1">Numero ingresado </param>
        /// <param name="numero2">Numero ingresao </param>
        /// <param name="operador">Tipo de operador </param>
        /// <returns>retorna el resultado de dicha operacion</returns>
        public static double Operar(Numero numero1, Numero numero2,string operador)
        {
            operador = ValidarOperador(operador);
            

           if(operador == "+")
            {
                return  numero1 + numero2;
            }
            else if(operador == "-")
            {
                return numero1 - numero2;
            }
            else if (operador == "*")
            {
                return numero1 * numero2;
            }
            else 
            {
                return numero1 / numero2;
                
            }

        }
    }
}
