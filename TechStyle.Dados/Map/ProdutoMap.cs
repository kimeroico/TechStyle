using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ValorVenda).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.SKU).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Ativo).IsRequired();
            builder.HasMany<ItemVendas>(p => p.ItemVendas).WithOne(s => s.Produto).HasForeignKey(i => i.IdProduto);
        }
    }
}
