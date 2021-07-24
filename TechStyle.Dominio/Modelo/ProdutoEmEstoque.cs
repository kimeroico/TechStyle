using System;

namespace TechStyle.Dominio.Modelo
{
    public class ProdutoEmEstoque : IEntity
    {
        public int Id { get; set; }
        public int QuantidadeMinima { get; set; }
        public string Local { get; set; }
        public int QuantidadeLocal { get; set; }
        public int QuantidadeTotal { get; set; }
        public Produto Produto { get; set; }
        public int IdProduto { get; set; }

        public void Cadastrar(int id, int quantidadeMinima, string local, int quantidadeLocal, 
            int quantidadeTotal, Produto produto)
        {
            Id = id;
            QuantidadeMinima = quantidadeMinima;
            Local = local;
            QuantidadeLocal = quantidadeLocal;
            QuantidadeTotal = quantidadeTotal;
            Produto = produto;
        }

        public void AlterarEstoque(int quantidadeMinima, string local, int quantidadeLocal, int quantidadeTotal)
        {
            QuantidadeMinima = (quantidadeMinima <= 0) ? QuantidadeMinima : quantidadeMinima;
            Local = string.IsNullOrEmpty(local.Trim()) ? Local : local;
            QuantidadeLocal = (quantidadeLocal <= 0) ? QuantidadeLocal : quantidadeLocal;
            QuantidadeTotal = (quantidadeTotal <= 0) ? QuantidadeTotal : quantidadeTotal;
        }

        public void NotificarNecessidadeDeCompra()
        {
            if (QuantidadeTotal == QuantidadeMinima)
            {
                Console.WriteLine("Produto atingiu a quantidade mínima em estoque." +
                    "\nPor favor solicitar reposição ao setor de compras");
            }
        }

        public void TransferirProdutoParaLoja(int numeroDePecas)
        {
            QuantidadeLocal -= numeroDePecas;
        }

        public void IncluirQuantidade(int numeroDePecas)
        {
            QuantidadeLocal += numeroDePecas;
            QuantidadeTotal += numeroDePecas;
        }

        public override string ToString()
        {
            return $"{QuantidadeMinima} | {Local} | {QuantidadeLocal} | {QuantidadeTotal} | {Produto}";
        }
    }
}
