using System;
using System.Collections.Generic;
using System.Linq;
using TechStyle.Dominio.Modelo;

namespace TechStyle.Dados.Repositorio
{
    public class SegmentoRepositorio : BaseRepositorio<Segmento>
    {        

        public bool Incluir(string categoria, string subcategoria)
        {
            var segmento = new Segmento();
            segmento.Cadastrar(categoria, subcategoria);

            if (Existe(segmento))
            {
                return false;
            }

            return base.Incluir(segmento);
        }

        public bool Alterar(int id, string categoria, string subcategoria)
        {
            var segmentoEncontrado = SelecionarPorId(id);            

            if (!Existe(segmentoEncontrado) || ExisteAlteracao(categoria, subcategoria))
            {
                return false;
            }

            segmentoEncontrado.Alterar(id, categoria, subcategoria);

            return base.Alterar(segmentoEncontrado);
        }

        public void AlterarStatus(int id)
        {
            var segmentoEncontrado = SelecionarPorId(id);

            segmentoEncontrado.AlterarStatus(!segmentoEncontrado.Ativo);
            base.Alterar(segmentoEncontrado);
        }       

        public List<Segmento> SelecionarPorCategoria(string categoria)
        {
            return contexto.Segmento.Where(x => x.Categoria.ToUpper() == categoria.Trim().ToUpper()).ToList();
        }        

        public override List<Segmento> SelecionarTudo()
        {
            return base.SelecionarTudo().OrderBy(x => x.Categoria).ToList();
        }

        public bool Existe(Segmento segmento)
        {
            return contexto.Segmento.Any(x => x.Categoria.Trim().ToLower() == segmento.Categoria.Trim().ToLower()
                                            && x.Subcategoria.Trim().ToLower() == segmento.Subcategoria.Trim().ToLower());
        }

        public bool ExisteAlteracao(string categoria, string subcategoria)
        {
            return contexto.Segmento.Any(x => x.Categoria.ToUpper() == categoria.Trim().ToUpper()
                                            && x.Subcategoria.ToUpper() == subcategoria.Trim().ToUpper());
        }
    }
}
