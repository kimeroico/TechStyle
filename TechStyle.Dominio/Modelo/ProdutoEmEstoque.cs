using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStyle.Dominio.Modelo
{
    public class ProdutoEmEstoque
    {
        public int Id { get; set; }
        public int QuantidadeMinima { get; set; }
        public string Local { get; set; }
        public int QuantidadeLocal { get; set; }
        public int QuantidadeTotal { get; set; }
        public Produto Produto { get; set; }

        internal void Cadastrar(int id, int quantidadeMinima, string local, int quantidadeLocal, 
            int quantidadeTotal, Produto produto)
        {
            Id = id;
            QuantidadeMinima = quantidadeMinima;
            Local = local;
            QuantidadeLocal = quantidadeLocal;
            QuantidadeTotal = quantidadeTotal;
            Produto = produto;
        }

        internal void AlterarEstoque(int quantidadeMinima, string local, int quantidadeLocal, int quantidadeTotal)
        {
            QuantidadeMinima = (quantidadeMinima <= 0) ? QuantidadeMinima : quantidadeMinima;
            Local = string.IsNullOrEmpty(local.Trim()) ? Local : local;
            QuantidadeLocal = (quantidadeLocal <= 0) ? QuantidadeLocal : quantidadeLocal;
            QuantidadeTotal = (quantidadeTotal <= 0) ? QuantidadeTotal : quantidadeTotal;
        }

        internal void NotificarNecessidadeDeCompra()
        {
            if (QuantidadeTotal == QuantidadeMinima)
            {
                Console.WriteLine("Produto atingiu a quantidade mínima em estoque." +
                    "\nPor favor solicitar reposição ao setor de compras");
            }
        }

        internal void TransferirProdutoParaLoja(int numeroDePecas)
        {
            QuantidadeLocal -= numeroDePecas;
        }

        internal void IncluirQuantidade(int numeroDePecas)
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
