using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Dominio
{
    /// <summary>
    /// 
    /// </summary>
    public class Cliente
    {
        #region Propiedades

        /// <summary>
        /// 
        /// </summary>
        public int CodigoCliente { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NombreCliente { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte TipoCliente { get; set; }

        #endregion

        #region Metodos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="as_nombre"></param>
        /// <param name="aby_tipo"></param>
        /// <returns></returns>
        public Cliente DarAlta(string as_nombre, byte aby_tipo)
        {
            return new Cliente() { NombreCliente = as_nombre, TipoCliente = aby_tipo  };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="as_nuevo_nombre"></param>
        public void CambiarNombre(string as_nuevo_nombre)
        {

            NombreCliente = as_nuevo_nombre;
        }

        #endregion
    }
}
