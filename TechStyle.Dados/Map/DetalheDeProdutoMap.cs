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
    public class DetalheDeProdutoMap : IEntityTypeConfiguration<DetalheProduto>
    {
        public void Configure(EntityTypeBuilder<DetalheProduto> builder)
        {
            builder.ToTable("DetalhesProduto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Material).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Cor).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Marca).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Modelo).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Tamanho).HasColumnType("varchar(100)").IsRequired();

        }
    }
}
