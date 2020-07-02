using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{

    public abstract class Persona
    {
        /// <summary>
        /// Enu tipo de nacionalidad
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;

        /// <summary>
        /// Obtiene o setea el nombre
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Obtiene o setea el apellido
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = ValidarNombreApellido(value); ; }
        }

        /// <summary>
        /// Obtiene o setea la nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        /// <summary>
        /// Obtiene o setea validando el dni dependiendo de la nacionalidad
        /// </summary>
        public int Dni
        {
            get { return this.dni; }
            set
            {

                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        /// <summary>
        ///  Setea validando el dni dependiendo de la nacionalidad
        /// </summary>
        public string StringToDni
        {

            set
            {

                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Constructor persona
        /// </summary>
        public Persona()
        {
            this.nombre = "Sin Nombre";
            this.apellido = "Sin Apellido";

        }
        /// <summary>
        /// Constructor Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;

        }

        /// <summary>
        /// Constructor Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad)
        {
           
            this.Dni = dni;


        }
        /// <summary>
        /// Constructor Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            
            this.StringToDni = dni;


        }
        /// <summary>
        /// Muestra los datos de persona
        /// </summary>
        /// <returns>Retorna los datos </returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();


            datos.Append($"NOMBRE COMPLETO:{this.Nombre}");
            datos.AppendLine($",{this.Apellido}");
            datos.AppendLine($"NACIONALIDAD:{this.Nacionalidad}");
            datos.AppendLine($"DNI:{this.Dni}");

            return datos.ToString();
        }
        /// <summary>
        /// Valida el dni dependiendo de la nacionalidad si es correcto caso contrario lanza excepcion
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Retorna el dni</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999)
            {
                return dato;

            }
            else if (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
            {

                return dato;
            }

            throw new NacionalidadInvalidaException("Nacionalidad invalida");
           

        }

        /// <summary>
        /// /// Valida el dni dependiendo de la nacionalidad si es correcto caso contrario lanza excepcion
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int resultado;

            if (int.TryParse(dato, out int dni))
            {
                resultado = ValidarDni(nacionalidad, dni);
                if (resultado != 0)
                {
                    return resultado;
                }
            }

            throw new DniInvalidoException("Dni invalido");
          
        }

        /// <summary>
        /// Valida el nombre y apellido 
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>retorna el nombre si cumple con la condiciones de no ser caracter especial y letras caso contrario no carga</returns>
        private string ValidarNombreApellido(string dato)
        {
            if (!string.IsNullOrEmpty(dato) && !string.IsNullOrWhiteSpace(dato))
                return dato;
            else
                return "";
        }
    }
}
