using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStyle.Dominio.Modelo;

namespace TechStyle.API.DTO
{
    public class ProdutoDTO
    {
        public decimal ValorVenda { get; set; }
        public string Nome { get; set; }
        public string SKU { get; set; }
        public int IdSegmento { get; set; }
    }
}
