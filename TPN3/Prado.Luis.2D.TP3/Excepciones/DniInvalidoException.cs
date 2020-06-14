﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Constructor DniInvalidoException
        /// </summary>
        public DniInvalidoException() : base("Este es el mensaje por defecto")
        {

        }
        /// <summary>
        /// Constructor DniInvalidoException
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(Exception e) : base("Este es el mensaje por defecto", e)
        {

        }
        /// <summary>
        /// Constructor DniInvalidoException
        /// </summary>
        /// <param name="message"></param>
        public DniInvalidoException(string message) : base(message)
        {

        }
        /// <summary>
        /// Constructor DniInvalidoException
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception e) : base(message, e)
        {

        }
    }
}
