using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidadException : Exception
    {
        public NacionalidadInvalidadException() : base("Este es el mensaje por defecto")
        {

        }

        public NacionalidadInvalidadException(string message) : base(message)
        {

        }
    }
}
