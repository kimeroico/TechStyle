namespace TechStyle.Dominio.Modelo
{
    public class ItemVendas : IEntity
    {
        public int Id { get; set; }
        public int IdVendas { get; set; }
        public Vendas Vendas { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }

        public void Cadastrar(int id, Vendas idVenda, Produto idProduto, decimal valorUnitario, int quantidade)
        {
            Id = id;
            Vendas = idVenda;
            Produto = idProduto;
            ValorUnitario = valorUnitario;
            Quantidade = quantidade;
        }

    }
}
