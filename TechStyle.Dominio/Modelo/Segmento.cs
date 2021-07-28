using System.Collections.Generic;

namespace TechStyle.Dominio.Modelo
{
    public class Segmento : IEntity
    {
        public int Id { get; private set; }
        public string Categoria { get; private set; }
        public string Subcategoria { get; private set; }
        public bool Ativo { get; private set; }
        public List<Produto> Produtos { get; set; }

        public void Cadastrar(string categoria, string subcategoria)
        {            
            Categoria = categoria;
            Subcategoria = subcategoria;
            Ativo = true;
        }

        public void Alterar(int id, string categoria, string subcategoria)
        {
            Id = id;
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
