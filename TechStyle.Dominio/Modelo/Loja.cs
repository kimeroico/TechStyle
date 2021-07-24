using System;

namespace TechStyle.Dominio.Modelo
{
    public class Loja : IEntity
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
        public int QuantidadeLocal { get; set; }
        public int QuantidadeMinima { get; set; }        

        public void Cadastrar(int id, int idProduto, int quantidadeLocal, int quantidadeMinima)
        {
            Id = id;
            IdProduto = idProduto;
            QuantidadeLocal = quantidadeLocal;
            QuantidadeMinima = quantidadeMinima;
        }

        public void Alterar(int quantidadeLocal, int quantidadeMinima)
        {
            QuantidadeLocal = (quantidadeLocal < 0) || (quantidadeLocal < quantidadeMinima) ? QuantidadeLocal : quantidadeLocal;
            QuantidadeMinima = (quantidadeMinima < 0) ? QuantidadeMinima : quantidadeMinima;
        }

        public void AdicionarProduto(int quantidade)
        {
            QuantidadeLocal += quantidade;
        }

        public void NotificarNecessidadeDeReposicao()
        {
            if (QuantidadeLocal <= QuantidadeMinima)
            {
                Console.WriteLine("Necessario solicitar reposição do estoque!");
            }
        }
    }
}
