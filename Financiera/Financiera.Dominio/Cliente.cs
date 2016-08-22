using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Dominio
{
    public class Cliente
    {
        public int CodigoCliente { get; set; }
        public string NombreCliente { get; set; }
        public byte TipoCliente { get; set; }

        public Cliente DarAlta(string as_nombre, byte aby_tipo)
        {
            return new Cliente() { NombreCliente = as_nombre, TipoCliente = aby_tipo  };
        }

        public void CambiarNombre(string as_nuevo_nombre)
        {

            NombreCliente = as_nuevo_nombre;
        }
    }
}
