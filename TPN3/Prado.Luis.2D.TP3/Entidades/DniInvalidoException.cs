﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException() : base("Este es el mensaje por defecto")
        {

        }

        public DniInvalidoException(Exception e) : base("Este es el mensaje por defecto", e)
        {

        }
        public DniInvalidoException(string message) : base(message)
        {

        }
        public DniInvalidoException(string message, Exception e) : base(message,e)
        {

        }
    }
}
