using Financiera.Dominio;
using Financiera.Infraestructura.Datos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Pruebas
{
    [TestClass]
    public class TarjetaPruebasIntegrales
    {
        private Cliente io_cliente;
        private long il_num_tarjeta;
        public TarjetaPruebasIntegrales()
        {
            var repositorio = new RepositorioGenerico<Cliente>();
            var io_cliente = repositorio
                .ObtenerPorExpresion(p => p.NombreCliente.Contains("Hector"), null, 0).FirstOrDefault();
            if (io_cliente == null)
            {
                repositorio.Adicionar(Cliente.DarAlta("Hector Maquera", 1));
                repositorio.GuardarCambios();
            }
            int aleatorio = new Random().Next();
            il_num_tarjeta = (long)(1000000010000000) * (long)aleatorio;
        }
        [TestMethod]
        public void RegistrarTarjetaSatisfactorio()
        {
            bool resultado = false;
            var repositorio = new RepositorioGenerico<Tarjeta>();
            var tarjeta_existente = repositorio
                .ObtenerPorExpresion(p => p.NumeroTarjeta == il_num_tarjeta).FirstOrDefault();
            if (tarjeta_existente == null)
            {
                repositorio.Adicionar(Tarjeta.Registrar(il_num_tarjeta));
                resultado = repositorio.GuardarCambios();
                Assert.IsTrue(resultado);
            }
        }
        [TestMethod]
        public void ActivarTarjetaSatisfactorio()
        {
            bool resultado = false;
            var repositorio = new RepositorioGenerico<Tarjeta>();
            var tarjeta = repositorio
                .ObtenerPorExpresion(p => p.EstadoTarjeta == (byte)TarjetaEstado.Registrada).FirstOrDefault();
            tarjeta.Activar(io_cliente, "1234");
            resultado = repositorio.GuardarCambios();
            Assert.IsTrue(resultado);
        }
    }
}
