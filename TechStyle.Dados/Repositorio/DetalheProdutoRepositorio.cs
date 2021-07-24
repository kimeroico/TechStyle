using System.Linq;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Repositorio
{
    public class DetalheProdutoRepositorio : BaseRepositorio<DetalheProduto>
    {
        internal bool Incluir(string material, string cor, string marca, string modelo, string tamanho, int idProduto)
        {
            DetalheProduto novoDetalhe = new DetalheProduto();
            novoDetalhe.Cadastrar(idProduto, material, cor, marca, modelo, tamanho);

            return base.Incluir(novoDetalhe);
        }

        internal bool Alterar(string material, string cor, string marca, string modelo, string tamanho, int idProduto)
        {
            var dpEncontrado = SelecionarPorProduto(idProduto);

            dpEncontrado.Alterar(material, cor, marca, modelo, tamanho);

            return base.Alterar(dpEncontrado);
        }

        internal DetalheProduto SelecionarPorProduto(int idProduto)
        {
            return contexto.DetalheProdutos.FirstOrDefault(x => x.IdProduto == idProduto);
        }
    }
}
