using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public enum Enacionalidad
    {
        Argentino,
        Extranjero
    }
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private Enacionalidad nacionalidad;
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
        public Enacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }
        public int Dni
        {
            get { return this.dni; }
            set { this.dni = value; }
        }

        public string StringToDni
        {
           
            set { this.dni = 10; }
        }

       public Persona()
        {
            this.nombre = "Sin Nombre";
            this.apellido = "Sin Apellido";
            this.nacionalidad = Enacionalidad.Argentino;
            this.dni = 0;
            
        }

        public Persona(string nombre, string apellido,Enacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;

        }

        public Persona(string nombre, string apellido,int dni, Enacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.Nacionalidad = nacionalidad;

        }

        public Persona(string nombre, string apellido, string dni, Enacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.StringToDni = dni;
            this.Nacionalidad = nacionalidad;

        }

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

            
            datos.AppendLine($"Nombre:{this.Nombre}");
            datos.AppendLine($"Apellido:{this.Apellido}");
            datos.AppendLine($"Dni:{this.Dni}");
            datos.AppendLine($"Nacionalidad:{this.Nacionalidad}");


            return datos.ToString();
        }
        private int ValidarDni(Enacionalidad nacionalidad, int dato)
        {
            if(nacionalidad == Enacionalidad.Argentino)
            {
                if(dato <=1 && dato >= 89999999)
                {
                    return dato;
                }
            }
            else if(nacionalidad == Enacionalidad.Extranjero)
            {
                if (dato <= 90000000 && dato >= 99999999)
                {
                    return dato;
                }
            }

            return 0;
        }

        private int ValidarDni(Enacionalidad nacionalidad, string dato)
        {
            int resultado;
            
            if (int.TryParse(dato,out int dni)) 
            {
                resultado = ValidarDni(nacionalidad, dni);
                if (resultado != 0)
                {
                    return resultado;
                }
            }

            return 0;
        }

        private string ValidarNombreApellido(string dato)
        {
            foreach (char item in dato)
            {
                if(item >= 'a' && item >= 'z' || item >= 'A' && item >= 'Z')
                {
                    return dato;
                }
            }
            return "error";
        }
    }
}
