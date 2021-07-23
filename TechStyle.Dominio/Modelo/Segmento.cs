using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStyle.Dominio.Modelo
{
    public class Segmento
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public bool Ativo { get; set; }
        public List<Produto> Produtos { get; set; }

        internal void Cadastrar(int id, string categoria, string subcategoria)
        {
            Id = id;
            Categoria = categoria;
            Subcategoria = subcategoria;
            Ativo = true;
        }

        internal void Alterar(string categoria, string subcategoria)
        {
            Categoria = string.IsNullOrEmpty(categoria.Trim()) ? Categoria : categoria;
            Subcategoria = string.IsNullOrEmpty(subcategoria.Trim()) ? Subcategoria : subcategoria;
        }

        internal void AlterarStatus(bool ativo)
        {
            Ativo = ativo;
        }

        public override string ToString()
        {
            return Categoria + " | " + Subcategoria;
        }

    }
}
