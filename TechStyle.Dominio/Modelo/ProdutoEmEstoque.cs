using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStyle.Dominio.Modelo
{
    class ProdutoEmEstoque
    {
        public int Id { get; set; }
        public int QuantidadeMinima { get; set; }
        public string Local { get; set; }
        public int QunatidadeLocal { get; set; }
        public int QuantidadeTotal { get; set; }
        public Produto Produto { get; set; }
    }
}
