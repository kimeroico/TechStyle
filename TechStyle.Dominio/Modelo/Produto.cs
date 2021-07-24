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

        public Produto()
        {
            //DetalheProduto = new DetalheProduto();
        }

        public void Cadastrar(decimal valorVenda, string nome, string sku, int idSegmento)
        {            
            ValorVenda = valorVenda;
            Nome = nome;
            SKU = sku;                     
            Ativo = false;
            IdSegmento = idSegmento;

            // ValidarDuplicidade

            // chamar insercao no banco
            // ID, CATEGORIA,    SUB       = A SOMA DE TUDO É O SEGMENTO
            /* 1, moda feminina, praia */
            /* 2, moda feminina, casual */
            /* 3, moda feminina, social */
            /* 4, moda feminina, fitness */
            /* 5, moda feminina, lingerie */
        }

        public void Alterar(decimal valorVenda, string nome, int idSegmento)
        {
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
