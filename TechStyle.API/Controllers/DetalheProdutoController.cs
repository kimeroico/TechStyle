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
    public class DetalheProdutoController : ControllerBase
    {
        private readonly DetalheProdutoRepositorio _repo;

        public DetalheProdutoController()
        {
            _repo = new DetalheProdutoRepositorio();
        }

        // GET: api/<DetalheProdutoController>
        [HttpGet]
        public IEnumerable<DetalheProduto> Get()
        {
            return _repo.SelecionarTudo();
        }

        // GET api/<DetalheProdutoController>/5
        [HttpGet("{id}")]
        public DetalheProduto Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST api/<DetalheProdutoController>
        [HttpPost]
        public void Post([FromBody] DetalheProdutoDTO dto)
        {
            var detalhe = new DetalheProduto();
            detalhe.Cadastrar(dto.Material, dto.Cor, dto.Marca, dto.Modelo, dto.Tamanho, dto.IdProduto);

            _repo.Incluir(detalhe);
        }

        // PUT api/<DetalheProdutoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DetalheProdutoDTO dto)
        {
            var detalhe = new DetalheProduto();
            detalhe.Alterar(id, dto.Material, dto.Cor, dto.Marca, dto.Modelo, dto.Tamanho);

            _repo.Alterar(detalhe);
        }

        // DELETE api/<DetalheProdutoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
