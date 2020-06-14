using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        /// <summary>
        /// /Enumerado de estados de cuenta
        /// </summary>
        public enum EEstadoCuenta
     
        {
            AlDia,
            Deudor,
            Becado
        }
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        /// <summary>
        /// constructor por defecto a la base
        /// </summary>
        public Alumno() : base()
        {

        }
        /// <summary>
        /// Constructor de alumno que carga sus datos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;

        }

        /// <summary>
        /// Constructor de alumno que carga sus datos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
            this.estadoCuenta = estadoCuenta;

        }
        /// <summary>
        /// muestra los datos de alumno y los retorna
        /// </summary>
        /// <returns>sitrng de datos de persona y estado de cuenta de alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();


            datos.Append(base.MostrarDatos());
            datos.AppendLine($"ESTADO DE CUENTA:{this.estadoCuenta}");
            datos.Append(ParticiparEnClase());
            return datos.ToString();
        }

        /// <summary>
        /// sobreescribe el metodo toString mostrarndo datos de alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.Append(MostrarDatos());

            return datos.ToString();
        }

        /// <summary>
        /// Muestra las clases del alumno
        /// </summary>
        /// <returns>retorna la clases en stirng</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine($"TOMA CLASES DE:{this.claseQueToma}");
            return datos.ToString();
        }

        /// <summary>
        /// Compara la clase del alumno clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>si son iguales retorna true caso contrario false</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {

            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Compara la clase del alumno clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>Si son distintas retorna true</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }
    }
}
