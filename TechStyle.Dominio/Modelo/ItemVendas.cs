using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStyle.Dominio.Modelo
{
    class ItemVendas
    {
        public int Id { get; set; }
        public int IdVenda { get; set; }
        public int IdProduto { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }

        internal void Cadastrar(int id, int idVenda, int idProduto, decimal valorUnitario, int quantidade)
        {
            Id = id;
            IdVenda = idVenda;
            IdProduto = idProduto;
            ValorUnitario = valorUnitario;
            Quantidade = quantidade;
        }

    }
}
