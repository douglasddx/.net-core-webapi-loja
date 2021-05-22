using System.Collections.Generic;
using System.Linq;
using loja.Data;
using loja.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace loja.Controllers
{
    [Route("Produto")]
    public class ProdutoController : Controller
    {
        private readonly LojaContexto _contexto;

        public ProdutoController(LojaContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        [Route("todos")]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var listaProduto = _contexto.Produto.AsEnumerable();
            if (listaProduto.Count() < 1)
                return NotFound(new { mensagem = "Não foram encontrados produtos" });
            return Ok(listaProduto);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _contexto.Produto.Where(c => c.Id == id).SingleOrDefault();
            if (produto == null)
                return NotFound(new { mensagem = "Não foi possivel localizar o produto" });
            return Ok(produto);
        }

        [HttpPost]
        [Route("")]
        public ActionResult Post([FromBody] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _contexto.Produto.Add(produto);
                _contexto.SaveChanges();
                return Ok();
            }
            else
                return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("")]
        public ActionResult Put([FromBody] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _contexto.Entry<Produto>(produto).State = EntityState.Modified;
                _contexto.SaveChanges();
                return Ok(new { mensagem = "Produto atualizado com sucesso" });
            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var produto = _contexto.Produto.Where(c => c.Id == id).SingleOrDefault();
            if (produto == null)
                return NotFound(new { mensagem = "Produto não encontrado" });
            else
            {
                _contexto.Produto.Remove(produto);
                _contexto.SaveChanges();
                return Ok(new { mensagem = "Produto excluído com sucesso" });
            }
        }
    }
}