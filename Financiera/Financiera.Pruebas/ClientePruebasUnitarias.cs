using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Financiera.Dominio;

namespace Financiera.Pruebas
{
    [TestClass]
    public class ClientePruebasUnitarias
    {
        [TestMethod]
        public void DarAltaSatisfactorio()
        {
            var cliente = Cliente.DarAlta("Hector Maquera",1);
            Assert.IsNotNull(cliente);
        }
    }
}
