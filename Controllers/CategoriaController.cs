using System.Collections.Generic;
using System.Linq;
using loja.Data;
using loja.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace loja.Controllers
{
    [Route("categoria")]
    public class CategoriaController : Controller
    {
        private readonly LojaContexto _contexto;

        public CategoriaController(LojaContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        [Route("todas")]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var listaCategoria = _contexto.Categoria.AsEnumerable();
            if (listaCategoria.Count() < 1)
                return NotFound(new { mensagem = "Não foram encontradas categorias" });
            return Ok(listaCategoria);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _contexto.Categoria.Where(c => c.Id == id).SingleOrDefault();
            if (categoria == null)
                return NotFound(new { mensagem = "Não foi possivel localizar a categoria" });
            return Ok(categoria);
        }

        [HttpPost]
        [Route("")]
        public ActionResult Post([FromBody] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _contexto.Categoria.Add(categoria);
                _contexto.SaveChanges();
                return Ok();
            }
            else
                return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("")]
        public ActionResult Put([FromBody] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _contexto.Entry<Categoria>(categoria).State = EntityState.Modified;
                _contexto.SaveChanges();
                return Ok(new { mensagem = "Categoria atualizada com sucesso" });
            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var categoria = _contexto.Categoria.Where(c => c.Id == id).SingleOrDefault();
            if (categoria == null)
                return NotFound(new { mensagem = "Categoria não encontrada" });
            else
            {
                _contexto.Categoria.Remove(categoria);
                _contexto.SaveChanges();
                return Ok(new { mensagem = "Categoria excluída com sucesso" });
            }
        }
    }
}