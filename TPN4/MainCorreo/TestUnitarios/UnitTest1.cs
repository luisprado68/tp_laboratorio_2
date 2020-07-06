using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestListaDePaquetesEstanciada()
        {
            Correo c = new Correo();

            Assert.IsNotNull(c.Paquete);
        }

        [ExpectedException(typeof(TrackingIdRepetidoException))]
        [TestMethod]
        public void TestDosPaquetesConMismoTrackingId()
        {
            Correo c = new Correo();
            Paquete p1 = new Paquete("lucas1@hotmail.com", "111-111-1111");
            Paquete p2 = new Paquete("mario2@hotmail.com", "111-111-1111");

            c += p1;
            c += p2;
        }
    }


}
