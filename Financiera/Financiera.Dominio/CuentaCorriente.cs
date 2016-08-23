using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Dominio
{
    /// <summary>
    /// Clase de Dominio que representa las Cuentas Corrientes
    /// </summary>
    public class CuentaCorriente
    {
        #region Propiedades

        /// <summary>
        /// Propiedad Unica de cada Cuenta
        /// </summary>
        public int NumeroCuenta { get; set; }
        public string CodigoCuenta { get; set; }
        public int CodigoCliente { get; set; }
        public decimal SaldoCuenta { get; set; }
        public DateTime FechaApertura { get; set; }
        public byte EstadoCuenta { get; set; }
        public virtual Cliente Propietario { get; set; }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que devuelve una cuenta corriente nueva
        /// </summary>
        /// <param name="as_cod_cuenta">Codigo de la Cuenta</param>
        /// <param name="ao_cliente">Cliente de Cuenta</param>
        /// <returns>Nueva Cuenta corriente</returns>
        public static CuentaCorriente Aperturar(string as_cod_cuenta, Cliente ao_cliente)
        {
            return new CuentaCorriente()
            {
                CodigoCuenta = as_cod_cuenta,
                CodigoCliente = ao_cliente.CodigoCliente,
                SaldoCuenta = 0,
                FechaApertura = DateTime.Now,
                EstadoCuenta = 1,
                Propietario = ao_cliente
            };
        }
        public void Cancelar()
        {
            SaldoCuenta = 0;
            EstadoCuenta = 4;
        }
        public void Bloquear()
        {
            EstadoCuenta = 2;
        }
        public void Desbloquear()
        {
            EstadoCuenta = 3;
        }

        #endregion
    }
}
