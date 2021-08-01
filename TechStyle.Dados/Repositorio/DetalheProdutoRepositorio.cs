using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Repositorio
{
    public class DetalheProdutoRepositorio : BaseRepositorio<DetalheProduto>
    {
        internal bool Incluir(string material, string cor, string marca, string modelo, string tamanho, int idProduto)
        {
            DetalheProduto novoDetalhe = new DetalheProduto();
            novoDetalhe.Cadastrar(material, cor, marca, modelo, tamanho, idProduto);

            return base.Incluir(novoDetalhe);
        }

        internal bool Alterar(int idProduto, string material, string cor, string marca, string modelo, string tamanho)
        {
            var dpEncontrado = SelecionarPorProduto(idProduto);

            dpEncontrado.Alterar(idProduto, material, cor, marca, modelo, tamanho);

            return base.Alterar(dpEncontrado);
        }

        internal DetalheProduto SelecionarPorProduto(int idProduto)
        {
            return contexto.DetalheProdutos.FirstOrDefault(x => x.IdProduto == idProduto);
        }
    }
}
