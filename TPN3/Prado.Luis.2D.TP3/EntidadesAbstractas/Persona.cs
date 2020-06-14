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
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;


        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        public void  SetDni(int dni)
        {
            this.dni = this.ValidarDni(this.Nacionalidad, dni);
        }

        public void SetDniString(string dni)
        {
            this.dni = this.ValidarDni(this.Nacionalidad, dni);
        }

        public int  RetornoDni()
        {
            return this.dni;
        }

        //public int Dni
        //{
        //    get { return this.dni; }
        //    set
        //    {
                
        //        this.dni = this.ValidarDni(this.Nacionalidad, value);
        //    }
        //}

        //public string StringToDni
        //{

        //    set
        //    {
                
        //        this.dni = this.ValidarDni(this.Nacionalidad, value);
        //    }
        //}

        public Persona()
        {
            this.nombre = "Sin Nombre";
            this.apellido = "Sin Apellido";
            

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad):this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;

        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.SetDni(dni);
            

        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.SetDniString(dni);
            

        }

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();


            datos.Append($"NOMBRE COMPLETO:{this.Nombre}");
            datos.AppendLine($",{this.Apellido}");
            datos.AppendLine($"NACIONALIDAD:{this.Nacionalidad}");
            datos.AppendLine($"DNI:{this.RetornoDni()}");



            return datos.ToString();
        }
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
                return 0;
            
           
            
        }

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
            
            
            return 0;
        }

        private string ValidarNombreApellido(string dato)
        {
            foreach (char item in dato)
            {
                if (item >= 'a' && item >= 'z' || item >= 'A' && item >= 'Z')
                {
                    return dato;
                }
            }
            return "error";
        }
    }
}
