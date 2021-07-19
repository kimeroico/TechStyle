﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStyle.Dominio.Modelo
{
    public class Loja
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public int QuantidadeLocal { get; set; }
        public int QuantidadeMinima { get; set; }

        internal void Cadastrar(int id, int idProduto, int quantidadeLocal, int quantidadeMinima)
        {
            Id = id;
            IdProduto = idProduto;
            QuantidadeLocal = quantidadeLocal;
            QuantidadeMinima = quantidadeMinima;
        }

        internal void Alterar(int quantidadeLocal, int quantidadeMinima)
        {
            QuantidadeLocal = (quantidadeLocal < 0) || (quantidadeLocal < quantidadeMinima) ? QuantidadeLocal : quantidadeLocal;
            QuantidadeMinima = (quantidadeMinima < 0) ? QuantidadeMinima : quantidadeMinima;
        }

        internal void AdicionarProduto(int quantidade)
        {
            QuantidadeLocal += quantidade;
        }

        internal void NotificarNecessidadeDeReposicao()
        {
            if (QuantidadeLocal <= QuantidadeMinima)
            {
                Console.WriteLine("Necessario solicitar reposição do estoque!");
            }
        }
    }
}
