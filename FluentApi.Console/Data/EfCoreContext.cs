using FluentApi.Console.Configuration;
using FluentApi.Console.Domain;
using Microsoft.EntityFrameworkCore;

namespace Convencoes.Console.Data
{
    public class EfCoreContext : DbContext
    {
        public EfCoreContext()
        {

        }
        public EfCoreContext(DbContextOptions<EfCoreContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Autor> Autores { get; set; } = null!;
        public virtual DbSet<Livro> Livros { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SLT-002411\\SQLEXPRESS;Database=EfCoreDb;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LivroConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());

            modelBuilder
                .HasDefaultSchema("Admin")
                .Ignore<Usuario>();

            modelBuilder.Entity<Autor>()
               .ToTable("AutoresPremiados", "Biblioteca")
               .HasKey(a => new { a.AutorId, a.SiglaNome });

            modelBuilder.Entity<Autor>()
                .HasAlternateKey(a => a.Cpf);

        }
    }
}
