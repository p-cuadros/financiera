using Financiera.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Infraestructura.Datos
{
    public class TarjetaMapeo : EntityTypeConfiguration<Tarjeta>
    {
        public TarjetaMapeo()
        {
            ToTable("TARJETAS", "CC");
            HasKey(k => k.NumeroTarjeta);
            Property(p => p.NumeroTarjeta).HasColumnName("NUM_TARJETA").IsRequired();
            Property(p => p.FechaRegistro).HasColumnName("FEC_REGISTRO").IsRequired();
            Property(p => p.FechaVencimiento).HasColumnName("FEC_VENCIMIENTO").IsRequired();
            Property(p => p.EstadoTarjeta).HasColumnName("EST_TARJETA").IsRequired();
            Property(p => p.CodigoCliente).HasColumnName("COD_CLIENTE");
            Property(p => p.PinTarjeta).HasColumnName("PIN_TARJETA");
            Property(p => p.FechaActivacion).HasColumnName("FEC_ACTIVACION");

            HasOptional(p => p.Propietario).WithMany().HasForeignKey(f => f.CodigoCliente);
        }
    }
}
