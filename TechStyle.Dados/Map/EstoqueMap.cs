using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Map
{
    public class EstoqueMap : IEntityTypeConfiguration<ProdutoEmEstoque>
    {
        public void Configure(EntityTypeBuilder<ProdutoEmEstoque> builder)
        {
            builder.ToTable("Estoque");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.QuantidadeMinima).HasColumnType("int").IsRequired();
            builder.Property(x => x.Local).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.QuantidadeLocal).HasColumnType("int").IsRequired();
            builder.Property(x => x.QuantidadeTotal).HasColumnType("int").IsRequired();

            builder.HasOne<Produto>(p => p.Produto)
                .WithOne(d => d.Estoque)
                .HasForeignKey<ProdutoEmEstoque>(i => i.IdProduto);
        }
    }
}
