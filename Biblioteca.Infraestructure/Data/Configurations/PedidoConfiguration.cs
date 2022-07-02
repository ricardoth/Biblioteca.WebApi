using Biblioteca.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infraestructure.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> entity)
        {
            entity.HasKey(e => e.IdPedido);

            entity.ToTable("Pedido");

            entity.Property(e => e.DetalleSolicitud)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.FechaEntrega).HasColumnType("datetime");

            entity.Property(e => e.FechaRecepcion).HasColumnType("datetime");

            entity.Property(e => e.GlosaSolicitud)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.MontoSolicitud).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedido_Usuario");
        }
    }
}
