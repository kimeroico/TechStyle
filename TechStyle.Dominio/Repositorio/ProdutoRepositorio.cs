using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.Repositorio
{
    public class ProdutoRepositorio
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
            novoProduto.Cadastrar(listaDeProdutos.Count + 1, valorVenda, nome, sku, segmento, 
                listaDeProdutos.Count + 1, material, cor, marca, modelo, tamanho);

            if (VerificarDuplicidade(novoProduto))
            {
                return false;
            }

            listaDeProdutos.Add(novoProduto);

            return true;
        }

        public bool AtualizarProduto(string sku, decimal valorVenda, string nome, Segmento segmento,
            string material, string cor, string marca, string modelo, string tamanho)
        {
            var produto = SelecionarPorSKU(sku);

            if (!VerificarDuplicidade(produto) || ExisteAlteracao(nome, material, cor, marca, modelo, tamanho))
            {
                return false;
            }

            produto.Alterar(valorVenda, nome, segmento, material, cor, marca, modelo, tamanho);
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

        public List<Produto> SelecionarTudo()
        {
            return listaDeProdutos.OrderBy(x => x.Nome).ToList();
        }

        private bool VerificarDuplicidade(Produto produto)
        {
            return listaDeProdutos.Any(x => x.Nome.Trim().ToLower() == produto.Nome.Trim().ToLower() 
            && x.DetalheProduto.Material.Trim().ToLower() == produto.DetalheProduto.Material.Trim().ToLower()
            && x.DetalheProduto.Cor.Trim().ToLower() == produto.DetalheProduto.Cor.Trim().ToLower()
            && x.DetalheProduto.Marca.Trim().ToLower() == produto.DetalheProduto.Marca.Trim().ToLower()
            && x.DetalheProduto.Modelo.Trim().ToLower() == produto.DetalheProduto.Modelo.Trim().ToLower()
            && x.DetalheProduto.Tamanho.Trim().ToLower() == produto.DetalheProduto.Tamanho.Trim().ToLower()
            );
        }

        private bool ExisteAlteracao(string nome, string material, string cor, string marca, string modelo, string tamanho)
        {
            return listaDeProdutos.Any(x => x.Nome.ToUpper() == nome.Trim().ToUpper()
                                            && x.DetalheProduto.Material.ToUpper() == material.Trim().ToUpper()
                                            && x.DetalheProduto.Cor.ToUpper() == cor.Trim().ToUpper()
                                            && x.DetalheProduto.Marca.ToUpper() == marca.Trim().ToUpper()
                                            && x.DetalheProduto.Modelo.ToUpper() == modelo.Trim().ToUpper()
                                            && x.DetalheProduto.Tamanho.ToUpper() == tamanho.Trim().ToUpper());
        }
    }
}
