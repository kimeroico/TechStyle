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
    }
}
