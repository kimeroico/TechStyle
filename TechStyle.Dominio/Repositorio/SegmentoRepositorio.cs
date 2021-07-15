using System;
using System.Collections.Generic;
using System.Linq;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dominio.Repositorio
{
    public class SegmentoRepositorio
    {
        private List<Segmento> listaDeSegmentos;

        public SegmentoRepositorio()
        {
            listaDeSegmentos = new List<Segmento>();
        }

        public bool Incluir(string categoria, string subcategoria)
        {
            var segmento = new Segmento();
            segmento.Cadastrar(listaDeSegmentos.Count + 1, categoria, subcategoria);

            if (Existe(segmento))
            {
                return false;
            }

            listaDeSegmentos.Add(segmento);
            return true;
        }

        public bool Alterar(int id, string categoria, string subcategoria)
        {
            var segmentoEncontrado = SelecionarPorId(id);
            //var segmento = new Segmento();
            //segmento.Cadastrar(listaDeSegmentos.Count + 1, categoria, subcategoria);

            if (!Existe(segmentoEncontrado) || ExisteAlteracao(categoria, subcategoria))
            {
                return false;
            }

            segmentoEncontrado.Alterar(categoria, subcategoria);
            return true;
        }

        public void AlterarStatus(int id)
        {
            var segmentoEncontrado = SelecionarPorId(id);
            var status = segmentoEncontrado.Ativo;        

            segmentoEncontrado.AlterarStatus(!status);
        }

        public Segmento SelecionarPorId(int id)
        {
            return listaDeSegmentos.FirstOrDefault(x => x.Id == id);
        }

        public List<Segmento> SelecionarPorCategoria(string categoria)
        {
            return listaDeSegmentos.Where(x => x.Categoria.ToUpper() == categoria.Trim().ToUpper()).ToList();
        }

        

        public List<Segmento> SelecionarTudo()
        {
            return listaDeSegmentos.OrderBy(x => x.Categoria).ToList();
        }

        public bool Existe(Segmento segmento)
        {
            return listaDeSegmentos.Any(x => x.Categoria.Trim().ToLower() == segmento.Categoria.Trim().ToLower()
                                            && x.Subcategoria.Trim().ToLower() == segmento.Subcategoria.Trim().ToLower());
        }

        public bool ExisteAlteracao(string categoria, string subcategoria)
        {
            return listaDeSegmentos.Any(x => x.Categoria.ToUpper() == categoria.Trim().ToUpper()
                                            && x.Subcategoria.ToUpper() == subcategoria.Trim().ToUpper());
        }

    }
}
