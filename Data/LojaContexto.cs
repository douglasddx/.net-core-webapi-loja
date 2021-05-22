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
        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Categoria>().ToTable("Categoria");
            builder.Entity<Categoria>().Property(x => x.Id);
            builder.Entity<Categoria>().Property(x => x.Nome).HasMaxLength(50).HasColumnType("varchar(50)");
        }
    }
}