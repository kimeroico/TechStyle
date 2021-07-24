using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Repositorio
{
    public class LojaRepositorio
    {
        private List<Loja> listaDaLoja;

        public LojaRepositorio()
        {
            listaDaLoja = new List<Loja>();
        }

        public bool Incluir(int idProduto, int quantidadeLocal, int quantidadeMinima)
        {
            var produtoLoja = new Loja();
            produtoLoja.Cadastrar(listaDaLoja.Count + 1, idProduto, quantidadeLocal, quantidadeMinima);

            if (ValidandoDuplicidade(produtoLoja.IdProduto))
            {
                return false;
            }

            listaDaLoja.Add(produtoLoja);
            return true;
        }

        public bool Alterar(int idProduto, int quantidadeLocal, int quantidadeMinima)
        {
            var objeto = SelecionePorIdProduto(idProduto);
            if (!ValidandoDuplicidade(objeto.IdProduto))
            {
                return false;
            }

            objeto.Alterar(quantidadeLocal, quantidadeMinima);
            return true;
        }

        public void ReceberProdutoDoEstoque(int id, int quantidadeRecebida)
        {
            var produto = SelecionePorIdProduto(id);
            produto.AdicionarProduto(quantidadeRecebida);
        }

        public Loja SelecionePorIdProduto(int idProduto)
        {
            return listaDaLoja.FirstOrDefault(x => x.IdProduto == idProduto);
        }

        public Loja SelecionePorId(int id)
        {
            return listaDaLoja.FirstOrDefault(x => x.Id == id);
        }

        private bool ValidandoDuplicidade(int idProduto)
        {
            return listaDaLoja.Any(x => x.IdProduto == idProduto);
        }
        
    }
}
