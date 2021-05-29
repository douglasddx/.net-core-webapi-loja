using System.Collections.Generic;
using System.Linq;
using loja.Data;
using loja.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace loja.Controllers
{
    [Route("usuario")]
    public class UsuarioController : Controller
    {
        private readonly LojaContexto _contexto;

        public UsuarioController(LojaContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        [Route("todos")]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            var usuarios = _contexto.Usuario.AsEnumerable();
            if (usuarios.Count() == 0)
                return NotFound(new { mensagem = "Não foram encontrados usuários" });
            return Ok(usuarios);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            var usuario = _contexto.Usuario.Where(c => c.Id == id).SingleOrDefault();
            if (usuario == null)
                return NotFound(new { mensagem = "Não foi possivel localizar o usuário" });
            return Ok(usuario);
        }

        [HttpPost]
        [Route("")]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _contexto.Usuario.Add(usuario);
                _contexto.SaveChanges();
                return Ok();
            }
            else
                return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("")]
        public ActionResult Put([FromBody] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _contexto.Entry<Usuario>(usuario).State = EntityState.Modified;
                _contexto.SaveChanges();
                return Ok(new { mensagem = "Usuário atualizado com sucesso" });
            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var usuario = _contexto.Usuario.Where(c => c.Id == id).SingleOrDefault();
            if (usuario == null)
                return NotFound(new { mensagem = "Usuário não encontrado" });
            else
            {
                _contexto.Usuario.Remove(usuario);
                _contexto.SaveChanges();
                return Ok(new { mensagem = "Usuário excluído com sucesso" });
            }
        }
    }
}