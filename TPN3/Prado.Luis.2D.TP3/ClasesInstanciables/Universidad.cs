﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

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

        public static bool operator ==(Universidad u, EClases clase)
        {
            int indice =0;
            for (int i=0;i<u.Profesores.Count;i++)
            {
                if (u.Profesores[i] == clase)
                {
                    indice = i;

                }

            }

            if(indice != 0)
            {
                return u.Profesores[indice];
            }
            
        }

        public static Universidad operator +(Universidad u, EClases clase)
        {
            int indice=0;
            
            for (int i=0;i<u.Profesores.Count;i++)
            {
                if (u.Profesores[i] == clase)
                {
                    indice = i;

                }

            }
            Jornada nueva = new Jornada(clase, u.Profesores[indice]);
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


    }
}
