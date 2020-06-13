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

        static Profesor()
        {
            random = new Random();
        }
        public Profesor() : base()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
        }

        public Profesor(int id, string nombre, string apellido, int dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {

            RandomClases();

        }

        private void RandomClases()
        {

            int numero1 = random.Next(0, 3);
            int numero2 = random.Next(0, 3);

            this.clasesDelDia.Enqueue((Universidad.EClases)numero1);
            this.clasesDelDia.Enqueue((Universidad.EClases)numero2);
        }
        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();


            datos.Append(base.ToString());



            return datos.ToString();
        }

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.Append(MostrarDatos());

            return datos.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine($"CLASES DEL DIA");
            foreach (Universidad.EClases item in clasesDelDia)
            {
                datos.AppendLine($":{item}");
            }

            return datos.ToString();
        }

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
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
