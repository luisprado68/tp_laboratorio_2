﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AlumnoRepetidoException  :Exception
    {
        public AlumnoRepetidoException() : base("Este es el mensaje por defecto")
        {

        }
    }
}
