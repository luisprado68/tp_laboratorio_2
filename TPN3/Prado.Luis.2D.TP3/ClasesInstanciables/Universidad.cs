using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
   
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        public List<Profesor> Profesores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public Jornada this[int i] 
        {
            
            get { return this.jornada[i]; } 
            set { this.jornada[i] = value; } 
        }

        public Universidad()
        {
            alumnos = new List<Alumno>();
            profesores = new List<Profesor>();
            jornada = new List<Jornada>();
        }

        public static bool operator ==(Universidad u, Alumno a)
        {
            foreach (Alumno item in u.Alumnos)
            {
                if(item == a)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

        public static bool operator ==(Universidad u, Profesor p)
        {
            foreach (Profesor item in u.Profesores)
            {
                if (item == p)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Universidad u, Profesor p)
        {
            return !(u == p);
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            
            for (int i=0;i<u.Profesores.Count;i++)
            {
                if (u.Profesores[i] == clase)
                {
                    return u.Profesores[i];

                }

            }

                throw new SinProfesorException();
            
            
        }
        public static Profesor operator !=(Universidad u, EClases clase)
        {
           
            for (int i = 0; i < u.Profesores.Count; i++)
            {
                if (u.Profesores[i] != clase)
                {
                    return u.Profesores[i];


                }

            }
            throw new SinProfesorException();

          
               
        }

        public static Universidad operator +(Universidad u, EClases clase)
        {
            int indice=0;
            Profesor profe;

            profe = u == clase;

            Jornada nueva = new Jornada(clase, profe);
            foreach (Alumno alumno in u.Alumnos)
            {
                if (alumno == clase)
                {

                    nueva.Alumnos.Add(alumno);
                }
            }
            u.Jornadas.Add(nueva);
            return u;
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }
        public static Universidad operator +(Universidad u, Profesor p)
        {
            if(u != p)
            {
                u.Profesores.Add(p);

                return u;
            }
            return u;
        }
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine("Jornada");
            foreach (Jornada item in this.Jornadas)
            {
                datos.AppendLine(item.ToString());
            }

            return datos.ToString();
        }

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.Append(this.MostrarDatos(this));

            return datos.ToString();
        }


        /// <summary>
        /// Genera un Archivo Xml con los datos de la Universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>True en caso de que el archivo se genere con éxito</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> archivo = new Xml<Universidad>();

            if(archivo.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Universidad.xml", uni))
            {
                return true;
            }
            else
            {
                throw new Exception("Error al Guardar el Archivo");
                return false;
            }

            
        }

        public Universidad Leer()
        {
            Xml<Universidad> archivo = new Xml<Universidad>();
            Universidad nueva;
            
            if (archivo.Leer(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "\\Universidad.xml", out nueva))
            {
                return nueva;
            }
            else
            {
                throw new System.Exception("Error al Guardar el Archivo");
                return nueva;
            }
        }
    }
}
