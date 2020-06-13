using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

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

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {

                j.Alumnos.Add(a);
                return j;
            }
            return j;
        }

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

           
            datos.Append($"CLASE DE {this.clase} POR");
            datos.AppendLine(this.Instructor.ToString());

            foreach (Alumno item in this.Alumnos)
            {
                datos.Append(item.ToString());
            }
            


            return datos.ToString();
        }
    }
}
