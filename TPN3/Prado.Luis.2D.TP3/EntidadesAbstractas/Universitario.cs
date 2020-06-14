using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        /// <summary>
        /// Constructor Universitario
        /// </summary>
        public Universitario() : base()
        {
            this.legajo = 0;
        }
        /// <summary>
        /// Constructor Univaersitario
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;

        }
        /// <summary>
        /// Metodo iguala que sea objeto Universitario
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Retorna true si son iguales caso contrario false</returns>
        public override bool Equals(object obj)
        {

            return obj is Universitario;
        }

        /// <summary>
        /// Muestra los datos de universitario
        /// </summary>
        /// <returns>Retorna los datos de universitatio </returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine($"LEGAJO:{this.legajo}");
            datos.Append(base.ToString());

            return datos.ToString();
        }

     
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Compara si universitarios son igules dependiendo de dni y tipo de objeto
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>Retorna true si son iguales caso contrario false</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {

            if (pg1.Equals(pg2) && pg1.Dni== pg2.Dni)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Compara si universitarios son igules dependiendo de dni y tipo de objeto
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>Retorna true si no son iguales caso contrario false</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
