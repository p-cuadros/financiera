using Financiera.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Dominio
{
    public class Tarjeta
    {
        #region Propiedades
        public long NumeroTarjeta { get; private set; }
        public string PinTarjeta { get; private set; }
        public DateTime FechaRegistro { get; private set; }
        public DateTime? FechaActivacion { get; private set; }
        public DateTime FechaVencimiento { get; private set; }
        public byte EstadoTarjeta { get; private set; }
        public int CodigoCliente { get; private set; }
        public virtual Cliente Propietario { get; private set; }
        #endregion

        #region Constructor
        private Tarjeta() { }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que se encarga de registrar una nueva tarjeta
        /// </summary>
        /// <param name="al_num_tarjeta">Número de Tarjeta</param>
        /// <returns>Nueva instancia de la clase Tarjeta</returns>
        public static Tarjeta Registrar(long al_num_tarjeta)
        {
            return new Tarjeta() {
                NumeroTarjeta = al_num_tarjeta,
                EstadoTarjeta = (byte)TarjetaEstado.Registrada,
                FechaRegistro = DateTime.Now,
                FechaVencimiento = DateTime.Now.AddYears(5)
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ao_cliente"></param>
        /// <param name="as_pin_tarjeta"></param>
        public void Activar(Cliente ao_cliente, string as_pin_tarjeta)
        {
            Propietario = ao_cliente;
            CodigoCliente = ao_cliente.CodigoCliente;
            PinTarjeta = as_pin_tarjeta;
            EstadoTarjeta = (byte)TarjetaEstado.Activada;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="as_pin_actual"></param>
        /// <param name="as_pin_nuevo"></param>
        public void CambiarPin(string as_pin_actual, string as_pin_nuevo)
        {
            if (PinTarjeta == as_pin_actual)
                if (as_pin_actual != as_pin_nuevo)
                    PinTarjeta = as_pin_nuevo;
                else
                    throw new Exception("El nuevo PIN debe ser diferente al actual");
            else
                throw new Exception("El PIN actual ingresado no es el correcto");
        }
        /// <summary>
        /// 
        /// </summary>
        public void Bloquear()
        {
            EstadoTarjeta = (byte)TarjetaEstado.Bloqueada;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Anular()
        {
            EstadoTarjeta = (byte)TarjetaEstado.Anulada;
        }
        #endregion
    }
}
