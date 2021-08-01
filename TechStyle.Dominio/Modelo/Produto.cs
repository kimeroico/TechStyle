using System.Collections.Generic;

namespace TechStyle.Dominio.Modelo
{
    public class Produto : IEntity
    {
        public int Id { get; set; }
        public decimal ValorVenda { get; private set; }
        public string Nome { get; private set; }
        public string SKU { get; private set; }
        public int IdSegmento { get; set; }
        public Segmento Segmento { get; private set; }
        public DetalheProduto DetalheProduto { get; private set; }
        public bool Ativo { get; private set; }
        public Loja Loja { get; set; }

        public List<ItemVendas> ItemVendas { get; set; }
        public ProdutoEmEstoque Estoque { get; set; }

        public void Cadastrar(decimal valorVenda, string nome, string sku, int idSegmento)
        {
            ValorVenda = valorVenda;
            Nome = nome;
            SKU = sku;
            IdSegmento = idSegmento;
            Ativo = false;
            IdSegmento = idSegmento;
        }

        public void Alterar(int id, decimal valorVenda, string nome, int idSegmento)
        {
            Id = id;
            ValorVenda = (valorVenda <= 0) ? ValorVenda : valorVenda;
            Nome = string.IsNullOrEmpty(nome.Trim()) ? Nome : nome;
            IdSegmento = idSegmento;
        }

        public void AlterarStatus(bool ativo)
        {
            Ativo = ativo;
        }

        public override string ToString()
        {
            return $"{ValorVenda} | {Nome} | {SKU} | {Segmento} | {DetalheProduto}";
        }
    }
}
