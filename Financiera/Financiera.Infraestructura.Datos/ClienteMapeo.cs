using Financiera.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Infraestructura.Datos
{
    public class ClienteMapeo : EntityTypeConfiguration<Cliente>
    {
        public ClienteMapeo()
        {
            ToTable("CLIENTES","CC");
            HasKey(k => k.CodigoCliente);
            Property(p => p.CodigoCliente).HasColumnName("COD_CLIENTE").IsRequired();
            Property(p => p.NombreCliente).HasColumnName("NOM_CLIENTE").IsRequired();
            Property(p => p.TipoCliente).HasColumnName("TIP_CLIENTE").IsRequired();
        }
    }
}
