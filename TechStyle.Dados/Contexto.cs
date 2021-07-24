using Microsoft.EntityFrameworkCore;
using TechStyle.Dados.Map;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados
{
    public class Contexto : DbContext

    {
        public DbSet<Segmento> Segmento { get; set; }
        public DbSet<DetalheProduto> DetalheProdutos { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ProdutoEmEstoque> ProdutoEmEstoques { get; set; }
        public DbSet<Loja> Loja { get; set; }
        public DbSet<ItemVendas> ItemVendas { get; set; }
        public DbSet<Vendas> Vendas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ACNTB3RKLD53; Database=TechStyle; Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SegmentoMap());
            modelBuilder.ApplyConfiguration(new DetalheDeProdutoMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new EstoqueMap());
            modelBuilder.ApplyConfiguration(new LojaMap());
            modelBuilder.ApplyConfiguration(new ItemVendasMap());
            modelBuilder.ApplyConfiguration(new VendasMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
