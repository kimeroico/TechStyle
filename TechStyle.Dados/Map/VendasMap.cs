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
    public class VendasMap : IEntityTypeConfiguration<Vendas>
    {
        public void Configure(EntityTypeBuilder<Vendas> builder)
        {
            builder.ToTable("Vendas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ValorTotal).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(x => x.Desconto).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(x => x.DataDaVenda).HasColumnType("smalldatetime").IsRequired();//??
            builder.HasMany<ItemVendas>(p => p.ItemVendas).WithOne(s => s.Vendas).HasForeignKey(i => i.IdVendas);
        }
    }
}
