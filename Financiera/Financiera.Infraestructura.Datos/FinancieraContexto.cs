using Financiera.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Infraestructura.Datos
{
    public class FinancieraContexto : DbContext
    {
        #region Constructor
        public FinancieraContexto() : base("Conexion")
        {
            //Database.SetInitializer<FinancieraContexto>(null);
        }
        #endregion

        #region Propiedades
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CuentaCorriente> CuentasCorrientes { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        #endregion

        #region Metodos
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ClienteMapeo());
            modelBuilder.Configurations.Add(new CuentaCorrienteMapeo());
            modelBuilder.Configurations.Add(new TarjetaMapeo());
        }
        #endregion
    }
}
