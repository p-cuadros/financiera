using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Dominio
{
    public class CuentaCorriente
    {
        public int NumeroCuenta { get; set; }
        public string CodigoCuenta { get; set; }
        public string CodigoCliente { get; set; }
        public decimal SaldoCuenta { get; set; }
        public DateTime FechaApertura { get; set; }
        public byte EstadoCuenta { get; set; }

        public virtual Cliente Propietario { get; set; }

        public CuentaCorriente Aperturar()
        {
            return null;
        }
        public void Cancelar()
        {
        }

        public void Bloquear()
        {
            EstadoCuenta = 2;
        }

        public void Desbloquear()
        { }
    }
}
