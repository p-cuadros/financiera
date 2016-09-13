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
            //var cliente2 = new Cliente() { NombreCliente = "Hector Maquera", TipoCliente = 1 };
            Assert.IsNotNull(cliente);
            //Assert.IsNotNull(cliente2);
        }
    }
}
