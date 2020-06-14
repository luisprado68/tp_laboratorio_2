using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using Excepciones;

namespace Pruebas
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]//espera una excepcion de persona sin dni
        public void AlumnoRepetido()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            uni += a1;

            Alumno a3 = new Alumno(3, "José", "Gutierrez", "12234456",
              EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
              Alumno.EEstadoCuenta.Becado);
            uni += a3;


        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]//espera una excepcion de persona sin dni
        public void NacionalidadInvalida()
        {
            Universidad uni = new Universidad();

            Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458",
              EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
              Alumno.EEstadoCuenta.Deudor);
            uni += a2;


        }

        [TestMethod]
        public void ValidarListaAlumnos()
        {
            
            Jornada jornada = new Jornada(Universidad.EClases.Laboratorio,new Profesor());
            
            Assert.IsNotNull(jornada.Alumnos);

        }
    }
}
