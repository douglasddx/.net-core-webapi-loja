using System.Linq;
using loja.Data;
using loja.Entities;
using Microsoft.AspNetCore.Mvc;

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
        [Route("")]
        public Categoria Get()
        {
            return _contexto.Categoria.SingleOrDefault();
        }

        [HttpPost]
        [Route("")]
        public void Post([FromBody] Categoria categoria)
        {
            _contexto.Categoria.Add(categoria);
            _contexto.SaveChanges();
        }
    }
}