﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario() : base()
        {
            this.legajo = 0;
        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;

        }
        public override bool Equals(object obj)
        {

            return obj is Universitario;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine($"LEGAJO:{this.legajo}");
            datos.Append(base.ToString());

            return datos.ToString();
        }

        protected abstract string ParticiparEnClase();

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {

            if (pg1.Equals(pg2) && pg1.RetornoDni() == pg2.RetornoDni())
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
