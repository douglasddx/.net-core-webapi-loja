using loja.Entities;
using Microsoft.EntityFrameworkCore;

namespace loja.Data
{
    public class LojaContexto : DbContext
    {
        public LojaContexto(DbContextOptions<LojaContexto> opcoes) : base(opcoes)
        {
        }
        public DbSet<Categoria> Categoria { get; set; }
    }
}