using System;
using System.Collections.Generic;
using System.Linq;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Repositorio
{
    public class EstoqueRepositorio : BaseRepositorio<ProdutoEmEstoque>
    {
        public bool IncluirNoEstoque(int quantidadeMinima, string local, int quantidadeLocal,
            int quantidadeTotal, Produto produto)
        {
            var novoNoEstoque = new ProdutoEmEstoque();
            novoNoEstoque.Cadastrar(quantidadeMinima, local, quantidadeLocal, quantidadeTotal, produto.Id);

            if (Existe(novoNoEstoque))
            {
                return false;
            }

            return base.Incluir(novoNoEstoque);
        }

        public bool AtualizarNoEstoque(int id, int quantidadeMinima, string local, int quantidadeLocal, int quantidadeTotal)
        {
            var produtoEmEstoque = SelecionarPorId(id);

            if (!Existe(produtoEmEstoque) || LocalEstaOcupado(local))
            {
                return false;
            }

            produtoEmEstoque.AlterarEstoque(quantidadeMinima, local, quantidadeLocal, quantidadeTotal);
            return true;
        }

        public bool TransferenciaParaLoja(int id, int quantidade, LojaRepositorio listaLoja)
        {
            var produtoEmEstoque = SelecionarPorId(id);
            

            if (VerificacaoDeQuantidade(produtoEmEstoque, quantidade))
            {
                return false;
            }
                        
            produtoEmEstoque.TransferirProdutoParaLoja(quantidade);
            var prodId = produtoEmEstoque.Produto.Id;

            listaLoja.ReceberProdutoDoEstoque(prodId, quantidade);
            return true;
        }

        public void AdicionarQuantidade(int id, int quantidade)
        {
            var produtoEmEstoque = SelecionarPorId(id);
            produtoEmEstoque.IncluirQuantidade(quantidade);
        }

        public List<ProdutoEmEstoque> SelecionarTudo()
        {
            return base.SelecionarTudo().OrderBy(x => x.Produto).ToList();
        }


        private bool Existe(ProdutoEmEstoque estoque)
        {
            return contexto.ProdutoEmEstoques.Any(x => x.Local.Trim().ToLower() == estoque.Local.Trim().ToLower()
            && x.Produto == estoque.Produto);
        }

        private bool LocalEstaOcupado(string local)
        {
            return contexto.ProdutoEmEstoques.Any(x => x.Local.Trim().ToLower() == local.Trim().ToLower());
        }

        private bool VerificacaoDeQuantidade(ProdutoEmEstoque produto, int quantidade)
        {
            if (produto.QuantidadeLocal < quantidade)
            {
                return true;
            }
            else if (produto.QuantidadeLocal == quantidade || (produto.QuantidadeLocal - quantidade) <= produto.QuantidadeMinima)
            {
                produto.NotificarNecessidadeDeCompra();
                return false;
            }
            else
            {
                return false;
            }            
        }

    }
}
