using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStyle.Dominio.Modelo
{
    public class Produto
    {
        public int Id { get; set; }
        public decimal ValorVenda { get; private set; }
        public string Nome { get; private set; }
        public string SKU { get; private set; }
        public Segmento Segmento { get; private set; }
        public DetalheProduto DetalheProduto { get; private set; }
        public bool Ativo { get; private set; }

        public Produto()
        {
            DetalheProduto = new DetalheProduto();
        }

        internal void Cadastrar(int id, decimal valorVenda, string nome, string sku, Segmento segmento, 
            int idDetalhe, string material, string cor, string marca, string modelo, string tamanho)
        {
            Id = id;
            ValorVenda = valorVenda;
            Nome = nome;
            SKU = sku;
            Segmento = segmento;
            DetalheProduto.Cadastrar(idDetalhe, material, cor, marca, modelo, tamanho);
            Ativo = false;

            // ValidarDuplicidade

            // chamar insercao no banco
            // ID, CATEGORIA,    SUB       = A SOMA DE TUDO É O SEGMENTO
            /* 1, moda feminina, praia */
            /* 2, moda feminina, casual */
            /* 3, moda feminina, social */
            /* 4, moda feminina, fitness */
            /* 5, moda feminina, lingerie */
        }

        internal void Alterar(decimal valorVenda, string nome, Segmento segmento,
            string material, string cor, string marca, string modelo, string tamanho)
        {
            ValorVenda = (valorVenda <= 0) ? ValorVenda : valorVenda;
            Nome = string.IsNullOrEmpty(nome.Trim()) ? Nome : nome;
            Segmento = (segmento == null) ? Segmento : segmento;
            DetalheProduto.Alterar(material, cor, marca, modelo, tamanho);
        }

        internal void AlterarStatus(bool ativo)
        {
            Ativo = ativo;
        }
    }
}
