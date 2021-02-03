using Microsoft.EntityFrameworkCore;
using WebapiKodig.Domain.Models;

namespace WebapiKodig.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Etiqueta> Etiquetas { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Produto>().ToTable("produtos");
            builder.Entity<Produto>().HasKey(p => p.CODIGO);
            builder.Entity<Produto>().Property(p => p.CODIGO).IsRequired().HasMaxLength(20);
            builder.Entity<Produto>().Property(p => p.TIPO).IsRequired().HasMaxLength(2);
            builder.Entity<Produto>().Property(p => p.UM).IsRequired().HasMaxLength(2);
            builder.Entity<Produto>().Property(p => p.DESCRICAO).IsRequired().HasMaxLength(50);

            builder.Entity<Etiqueta>().ToTable("etiquetas");
            builder.Entity<Etiqueta>().HasKey(p => p.CODIGO);
            builder.Entity<Etiqueta>().Property(p => p.CODIGO).IsRequired().HasMaxLength(15);
            builder.Entity<Etiqueta>().Property(p => p.PRODUTO).IsRequired().HasMaxLength(20);
            builder.Entity<Etiqueta>().Property(p => p.QUANTIDADE).IsRequired();
            builder.Entity<Etiqueta>().Property(p => p.SALDO).IsRequired();
        }
    }
}