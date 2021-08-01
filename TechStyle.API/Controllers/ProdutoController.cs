using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStyle.API.DTO;
using TechStyle.Dados.Repositorio;
using TechStyle.Dominio.Modelo;

namespace TechStyle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoRepositorio _repo;

        public ProdutoController()
        {
            _repo = new ProdutoRepositorio();
        }

        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            return _repo.SelecionarTudo();
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public Produto Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public void Post([FromBody] ProdutoDTO dto)
        {
            var produto = new Produto();
            produto.Cadastrar(dto.ValorVenda, dto.Nome, dto.SKU, dto.IdSegmento);

            _repo.Incluir(produto,);
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProdutoDTO dto)
        {
            Produto p = new Produto();
            p.Alterar(1, 1, "~t", 1);
          
            _repo.Alterar(id, dto.ValorVenda, dto.Nome, dto.IdSegmento);

        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
