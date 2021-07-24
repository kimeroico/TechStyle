using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Map
{
    public class ItemVendasMap : IEntityTypeConfiguration<ItemVendas>
    {
        public void Configure(EntityTypeBuilder<ItemVendas> builder)
        {
            builder.ToTable("ItemVendas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ValorUnitario).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(x => x.Quantidade).HasColumnType("int").IsRequired();
        }
    }
}
