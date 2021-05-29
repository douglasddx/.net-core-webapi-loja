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
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Categoria>().ToTable("Categoria");
            builder.Entity<Categoria>().Property(x => x.Id);
            builder.Entity<Categoria>().Property(x => x.Nome).HasMaxLength(50).HasColumnType("varchar(50)");

            builder.Entity<Produto>().ToTable("Produto");
            builder.Entity<Produto>().Property(x => x.Id);
            builder.Entity<Produto>().Property(x => x.Nome).HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Entity<Produto>().Property(x => x.Preco).HasColumnType("decimal").HasPrecision(18, 2);

            builder.Entity<Perfil>().ToTable("Perfil");
            builder.Entity<Perfil>().Property(x => x.Id);
            builder.Entity<Perfil>().Property(x => x.Nome).HasMaxLength(50).HasColumnType("varchar(50)");

            builder.Entity<Usuario>().ToTable("Usuario");
            builder.Entity<Usuario>().Property(x => x.Id);
            builder.Entity<Usuario>().Property(x => x.Email).HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Entity<Usuario>().Property(x => x.Senha).HasMaxLength(8).HasColumnType("varchar(8)");


        }
    }
}