using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Repositorio
{
    public class ProdutoRepositorio : BaseRepositorio<Produto>
    {        

        public bool Incluir(decimal valorVenda, string nome, string sku, Segmento segmento, 
            string material, string cor, string marca, string modelo, string tamanho)
        {

            var novoProduto = new Produto();
            novoProduto.Cadastrar(valorVenda, nome, sku, segmento.Id);

            if (VerificarDuplicidade(novoProduto))
            {
                return false;
            }

            if(base.Incluir(novoProduto))
            {
                return new DetalheProdutoRepositorio().Incluir(material, cor, marca, modelo, tamanho, novoProduto.Id);
            }

            return false;
        }

        public bool AtualizarProduto(int id, decimal valorVenda, string nome, Segmento segmento,
            string material, string cor, string marca, string modelo, string tamanho)
        {
            var produto = SelecionarPorId(id);            

            if (ExisteAlteracao(nome, material, cor, marca, modelo, tamanho))
            {
                return false;
            }

            produto.Alterar(valorVenda, nome, segmento.Id);

            if(base.Alterar(produto))
            {
                return new DetalheProdutoRepositorio().Alterar(material, cor, marca, modelo, tamanho, produto.Id);
            }

            return false;
        }

        public void AlterarStatus(int id)
        {
            var produto = SelecionarPorId(id);
            var status = produto.Ativo;
            produto.AlterarStatus(!status);

        }

        public Produto SelecionarPorSKU(string sku)
        {
            return contexto.Produto.FirstOrDefault(x => x.SKU == sku);
        }

        public List<Produto> SelecionarPorNome(string nome)
        {
            return contexto.Produto.Where(x => x.Nome.Trim().ToUpper() == nome.Trim().ToUpper()).ToList();
        }

        private bool VerificarDuplicidade(Produto produto)
        {
            if (string.IsNullOrEmpty(produto.DetalheProduto?.Tamanho)) return false;

            return contexto.Produto.Any(x => x.Nome.Trim().ToLower() == produto.Nome.Trim().ToLower()
            && x.DetalheProduto.Material.Trim().ToLower() == produto.DetalheProduto.Material.Trim().ToLower()
            && x.DetalheProduto.Cor.Trim().ToLower() == produto.DetalheProduto.Cor.Trim().ToLower()
            && x.DetalheProduto.Marca.Trim().ToLower() == produto.DetalheProduto.Marca.Trim().ToLower()
            && x.DetalheProduto.Modelo.Trim().ToLower() == produto.DetalheProduto.Modelo.Trim().ToLower()
            && x.DetalheProduto.Tamanho.Trim().ToLower() == produto.DetalheProduto.Tamanho.Trim().ToLower()
            );
        }

        private bool ExisteAlteracao(string nome, string material, string cor, string marca, string modelo, string tamanho)
        {
            return contexto.Produto.Include(x => x.DetalheProduto).Any(x => x.Nome.ToUpper() == nome.Trim().ToUpper()
                                                                        && x.DetalheProduto.Material.ToUpper() == material.Trim().ToUpper()
                                                                        && x.DetalheProduto.Cor.ToUpper() == cor.Trim().ToUpper()
                                                                        && x.DetalheProduto.Marca.ToUpper() == marca.Trim().ToUpper()
                                                                        && x.DetalheProduto.Modelo.ToUpper() == modelo.Trim().ToUpper()
                                                                        && x.DetalheProduto.Tamanho.ToUpper() == tamanho.Trim().ToUpper());
        }

        public Produto SelecionarPorIdCompleto(int id)
        {
            return contexto.Produto.Include(x => x.DetalheProduto).FirstOrDefault(x => x.Id == id);
        }
    }
}
