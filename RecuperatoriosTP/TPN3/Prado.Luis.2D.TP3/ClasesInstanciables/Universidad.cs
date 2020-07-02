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
        /// <summary>
        /// Enum de tipo Eclases
        /// </summary>
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

        /// <summary>
        /// Obtiene o setea la lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// Obtiene o setea la lista de jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        /// <summary>
        /// Obtiene o setea la lista de profesore
        /// </summary>
        public List<Profesor> Profesores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        /// <summary>
        /// Obtiene la jorada o setea por indice
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {

            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }

        /// <summary>
        /// Constructor universidad
        /// </summary>
        public Universidad()
        {
            alumnos = new List<Alumno>();
            profesores = new List<Profesor>();
            jornada = new List<Jornada>();
        }

        /// <summary>
        /// Compara si el alumno de parametro existe en la lista de alumnos
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns>Retorna true si existe caso contrario false</returns>
        public static bool operator ==(Universidad u, Alumno a)
        {
            foreach (Alumno item in u.Alumnos)
            {
                if (item == a)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Compara si el alumno de parametro existe en la lista de alumnos
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns>Retorna true no  existe caso contrario false</returns>
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

        /// <summary>
        /// Compara la lista de profesores si existe el profesor en parametro
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns>Retorna true si existe de lo contrario false</returns>
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
        /// <summary>
        /// Compara la lista de profesores si existe el profesor en parametro
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns>Retorna true si no existe de lo contrario false</returns>
        public static bool operator !=(Universidad u, Profesor p)
        {
            return !(u == p);
        }

        /// <summary>
        /// Compara los si existe un profesor que tenga una clase igual a la pasada por parametro si no lanza la excepcion
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns> retorna el profesor </returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {

            for (int i = 0; i < u.Profesores.Count; i++)
            {
                if (u.Profesores[i] == clase)
                {
                    return u.Profesores[i];

                }

            }

            throw new SinProfesorException();


        }
        /// <summary>
        /// Compara al primer  profesor que tenga una clase distinta a  la pasada por parametro si no lanza la excepcion
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns> retorna el profesor </returns>
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

        /// <summary>
        /// Agrega una nueva jornada a la universidad con el profesor y alumnos de misma clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna la universidad</returns>
        public static Universidad operator +(Universidad u, EClases clase)
        {

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

        /// <summary>
        /// Agrega un alumno si no existe en la lista de alumnos si no lanza una excepcion
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns>Retorna objeto la universidad</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }

        /// <summary>
        /// Agrega un profesor si no existe en la lista de profesores 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns>Retorna objeto la universidad</returns>
        public static Universidad operator +(Universidad u, Profesor p)
        {
            if (u != p)
            {
                u.Profesores.Add(p);

                return u;
            }
            return u;
        }
        /// <summary>
        /// Muestra los datos de la universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>Retorna los datos en cadena de texto</returns>
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

        /// <summary>
        /// Muestra los datos de la universidad
        /// </summary>
        /// <returns>Devuelve los datos en cadena de texto</returns>
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

            if (archivo.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Universidad.xml", uni))
            {
                return true;
            }
            else
            {
                throw new Exception("Error al Guardar el Archivo");

            }


        }
        /// <summary>
        /// Genera un Archivo Xml con los datos de la Universidad
        /// </summary>
        /// <returns>Retorna la nueva universida leida</returns>
        public Universidad Leer()
        {
            Xml<Universidad> archivo = new Xml<Universidad>();
            Universidad nueva;

            if (archivo.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Universidad.xml", out nueva))
            {
                return nueva;
            }
            else
            {
                throw new Exception("Error al Guardar el Archivo");

            }
        }
    }
}
