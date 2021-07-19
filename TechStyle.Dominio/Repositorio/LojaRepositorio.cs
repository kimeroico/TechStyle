using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.Repositorio
{
    public class LojaRepositorio
    {
        private List<Loja> listaDaLoja;

        public LojaRepositorio()
        {
            listaDaLoja = new List<Loja>();
        }

        public bool Incluir(Produto produto, int quantidadeLocal, int quantidadeMinima)
        {
            var produtoLoja = new Loja();
            produtoLoja.Cadastrar(listaDaLoja.Count + 1, produto, quantidadeLocal, quantidadeMinima);

            if (ValidandoDuplicidade(produtoLoja))
            {
                return false;
            }

            listaDaLoja.Add(produtoLoja);
            return true;
        }

        private bool ValidandoDuplicidade(Loja loja)
        {
            return listaDaLoja.Any(x => x.Produto == loja.Produto);
        }
        
    }
}
