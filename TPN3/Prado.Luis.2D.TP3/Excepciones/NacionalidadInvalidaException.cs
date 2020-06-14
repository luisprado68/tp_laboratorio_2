using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor NacionalidadInvalidaException
        /// </summary>
        public NacionalidadInvalidaException() : base("Este es el mensaje por defecto")
        {

        }

        /// <summary>
        /// Constructor NacionalidadInvalidaException
        /// </summary>
        /// <param name="message"></param>
        public NacionalidadInvalidaException(string message) : base(message)
        {

        }
    }
}
