using System.Collections.Generic;

namespace TechStyle.Dominio.Modelo
{
    public class Segmento : IEntity
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public bool Ativo { get; set; }
        public List<Produto> Produtos { get; set; }

        public void Cadastrar(string categoria, string subcategoria)
        {
            Categoria = categoria;
            Subcategoria = subcategoria;
            Ativo = true;
        }

        public void Alterar(string categoria, string subcategoria)
        {
            Categoria = string.IsNullOrEmpty(categoria.Trim()) ? Categoria : categoria;
            Subcategoria = string.IsNullOrEmpty(subcategoria.Trim()) ? Subcategoria : subcategoria;
        }

        public void AlterarStatus(bool ativo)
        {
            Ativo = ativo;
        }

        public override string ToString()
        {
            return Categoria + " | " + Subcategoria;
        }

    }
}
