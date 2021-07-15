using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.Repositorio
{
    class ProdutoRepositorio
    {
        private List<Produto> listaDeProdutos;

        public ProdutoRepositorio()
        {
            listaDeProdutos = new List<Produto>();
        }

        public bool Incluir(decimal valorVenda, string nome, string sku, Segmento segmento, 
            string material, string cor, string marca, string modelo, string tamanho)
        {
            var novoProduto = new Produto();
            novoProduto.Cadastrar(valorVenda, nome, sku, segmento, listaDeProdutos.Count + 1, 
                material, cor, marca, modelo, tamanho);

            if (VerificarDuplicidade(novoProduto))
            {
                return false;
            }

            listaDeProdutos.Add(novoProduto);

            return true;
        }

        public void AlterarStatus(string sku)
        {
            var produto = SelecionarPorSKU(sku);
            var status = produto.Ativo;
            produto.AlterarStatus(!status);

        }

        public Produto SelecionarPorSKU(string sku)
        {
            return listaDeProdutos.FirstOrDefault(x => x.SKU == sku);
        }

        public List<Produto> SelecionarPorNome(string nome)
        {
            return listaDeProdutos.Where(x => x.Nome.Trim().ToUpper() == nome.Trim().ToUpper()).ToList();
        }

        private bool VerificarDuplicidade(Produto produto)
        {
            return listaDeProdutos.Any(x => x.SKU.Trim().ToLower() == produto.SKU.Trim().ToLower());
        }
    }
}
