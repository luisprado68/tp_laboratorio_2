using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;


namespace ClasesInstanciables
{

    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        /// <summary>
        /// Construcor statico
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor profesor
        /// </summary>
        public Profesor() : base()
        {

        }
        /// <summary>
        /// Construcor Profesor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            RandomClases();

        }

        /// <summary>
        /// Agregar de forma random dos clase de tipo eclase
        /// </summary>
        private void RandomClases()
        {

            int numero1 = random.Next(0, 3);
            int numero2 = random.Next(0, 3);

            this.clasesDelDia.Enqueue((Universidad.EClases)numero1);
            this.clasesDelDia.Enqueue((Universidad.EClases)numero2);
        }
        /// <summary>
        /// Muestra los datos de el profesor
        /// </summary>
        /// <returns>retorna los datos en cadena de texto</returns>
        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();


            datos.Append(base.ToString());
            datos.AppendLine(ParticiparEnClase());


            return datos.ToString();
        }

        /// <summary>
        /// Muestra los datos del profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.Append(MostrarDatos());

            return datos.ToString();
        }

        /// <summary>
        /// Muestra las clases que da el profesor
        /// </summary>
        /// <returns>retorna los datos tipo string</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine($"CLASES DEL DIA");
            foreach (Universidad.EClases item in clasesDelDia)
            {
                datos.AppendLine($"{item}");
            }

            return datos.ToString();
        }

        /// <summary>
        /// Compara las clases del profesor con la clase en parametro
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>retorna true si son iguales y false si es lo contrario</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
                {
                    return true;
                }
            }


            return false;
        }
        /// <summary>
        /// Compara las clases del profesor con la clase en parametro
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>sin no son iguales retorna true</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
