using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Financiera.Dominio;
using Financiera.Infraestructura.Datos;

namespace Financiera.Pruebas
{
    [TestClass]
    public class ClientePruebasIntegrales
    {
        [TestMethod]
        public void DarAltaPrimeraVezSatisfactorio()
        {
            bool resultado = false;
            var cliente = Cliente.DarAlta("Hector Maquera", 1);
            //var cliente2 = new Cliente() { NombreCliente = "Hector Maquera", TipoCliente = 1 };
            var repositorio = new RepositorioGenerico<Cliente>();
            var cliente_existente = repositorio
                .ObtenerPorExpresion(p => p.NombreCliente.Contains("Hector"), null, 0).FirstOrDefault();
            if (cliente_existente == null)
            {
                repositorio.Adicionar(cliente);
                resultado = repositorio.GuardarCambios();
                Assert.IsTrue(resultado);
            }
            else
                Assert.IsFalse(resultado);
        }
    }
}
