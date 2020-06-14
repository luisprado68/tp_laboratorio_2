using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        /// <summary>
        /// Obitiene  o Setea la lista de alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        /// <summary>
        /// Obtiene o Setea la clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        /// <summary>
        /// Obtiene o Setea el profesor
        /// </summary>
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        /// <summary>
        /// constructor jornada 
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }
        /// <summary>
        /// constructor jornada
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        /// <summary>
        /// Compara la lista de alumnos de jornada con el alumno
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>retorna true si es igual caso contrario false</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {

            foreach (Alumno item in j.Alumnos)
            {
                if (item == a)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Compara la lista de alumnos de jornada con el alumno
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>Si es distinto retorna true</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agreag un alumno a la lista de alumnos de jornada si este no existe
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>retorna la jornda</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {

                j.Alumnos.Add(a);
                return j;
            }
            return j;
        }

        /// <summary>
        /// Muestra los datos de la jornada
        /// </summary>
        /// <returns>retorna los datos en cadena de texto</returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

           
            datos.Append($"CLASE DE {this.clase} POR ");
            datos.AppendLine(this.Instructor.ToString());

            foreach (Alumno item in this.Alumnos)
            {
                datos.Append(item.ToString());
            }
            
            return datos.ToString();
        }


        /// <summary>
        /// Llama a la interface IArchivo para generar un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>True en caso de que se haya creado el archivo</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            
            if(texto.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Jornada.txt", jornada.ToString()))
            {
                return true;
            }
            else
            {
                 throw new ArchivosException(new Exception("Error al Guardar el Archivo"));
                return false;
            }
             
        }

        /// <summary>
        /// Llama a la interface IArchivo para leer un archivo de texto
        /// </summary>
        /// <returns>el texto con el contenido del archivo</returns>
        public string Leer()
        {
            string leido;
            Texto texto = new Texto();

            if(texto.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Jornada.txt", out leido))
            {
                return leido;
            }
            else
            {
                throw new Exception("Error al leer el Archivo");
            }

        }
    }
}
