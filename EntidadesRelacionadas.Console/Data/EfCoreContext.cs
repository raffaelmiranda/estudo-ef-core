using EntidadesRelacionadas.Console.Configuration;
using EntidadesRelacionadas.Console.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntidadesRelacionadas.Console.Data
{
    public class EfCoreContext : DbContext
    {
        public DbSet<Autor>? Autores { get; set; }
        public DbSet<Livro>? Livros { get; set; }
        public DbSet<Biografia>? Biografias { get; set; }
        public DbSet<Editor>? Editores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=SLT-002411\\SQLEXPRESS;Database=EfCoreDb;Trusted_Connection=True");

            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(b => b.AddConsole().AddFilter("", LogLevel.Information)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LivroConfiguration());
            modelBuilder.ApplyConfiguration(new AutorConfiguration());
            modelBuilder.ApplyConfiguration(new BiografiaConfiguration());
            modelBuilder.ApplyConfiguration(new EditorConfiguration());

            modelBuilder.Entity<Biografia>().HasData(
                new Biografia { Id = 1, BiografiaAutor = "Herman Hesse", DataNascimento = new DateTime(1877, 7, 2), Nacionalidade = "Alemanha", AutorId = 1 },
                new Biografia { Id = 2, BiografiaAutor = "Agatha Christie", DataNascimento = new DateTime(1890, 9, 12), Nacionalidade = "Inglaterra", AutorId = 2 },
                new Biografia { Id = 3, BiografiaAutor = "Paulo Coelho", DataNascimento = new DateTime(1847, 8, 24), Nacionalidade = "Brasil", AutorId = 3 },
                new Biografia { Id = 4, BiografiaAutor = "Leon Tolstoy", DataNascimento = new DateTime(1828, 7, 10), Nacionalidade = "Russia", AutorId = 4 },
                new Biografia { Id = 5, BiografiaAutor = "Fernando Pessoa", DataNascimento = new DateTime(1900, 1, 5), Nacionalidade = "Portugal", AutorId = 5 });

            modelBuilder.Entity<Editor>().HasData(
                new Editor { Id = 1, Nome = "Amazon" },
                new Editor { Id = 2, Nome = "Americanas" },
                new Editor { Id = 3, Nome = "Saraiva" });

            modelBuilder.Entity<Autor>().HasData(
                 new Autor { Id = 1, Nome = "Hermann Hesse ", Email = "hermann@email.com" },
                 new Autor { Id = 2, Nome = "Agatha Christie", Email = "agaha@email.com" },
                 new Autor { Id = 3, Nome = "Paulo Coelho", Email = "coelho@email.com" },
                 new Autor { Id = 4, Nome = "Leon Tolstoy", Email = "tolstoy@email.com" },
                 new Autor { Id = 5, Nome = "Fernando Pessoa", Email = "fernando@email.com" });

            modelBuilder.Entity<Livro>().HasData(
                new Livro { Id = 1, Titulo = "Sidarta", Tipo = "Romance", AnoLancamento = 1922, AutorId = 1, EditorId = 1,  },
                new Livro { Id = 2, Titulo = "Demain", Tipo = "Romance", AnoLancamento = 1919, AutorId = 1, EditorId = 1 },
                new Livro { Id = 3, Titulo = "Assassinato no Oriente Express", Tipo = "Romance", AnoLancamento = 1934, AutorId = 2, EditorId = 1 },
                new Livro { Id = 4, Titulo = "O caso dos dez negrinhos", Tipo = "Romance", AnoLancamento = 1968, AutorId = 2, EditorId = 1 },
                new Livro { Id = 5, Titulo = "O Alquimista", Tipo = "Romance", AnoLancamento = 1988, AutorId = 3, EditorId = 1 },
                new Livro { Id = 6, Titulo = "Ana Karenina", Tipo = "Romance", AnoLancamento = 1977, AutorId = 4, EditorId = 2 },
                new Livro { Id = 7, Titulo = "Guerra e Paz", Tipo = "Romance", AnoLancamento = 1967, AutorId = 4, EditorId = 2 },
                new Livro { Id = 8, Titulo = "O Guardador de rebanhos", Tipo = "Poesias", AnoLancamento = 1925, AutorId = 5, EditorId = 1 },
                new Livro { Id = 9, Titulo = "Poesias", Tipo = "Poesias", AnoLancamento = 1930, AutorId = 5, EditorId = 3 },
                new Livro { Id = 10, Titulo = "E não sobrou nenhum", Tipo = "Ficção", AnoLancamento = 1939, AutorId = 4, EditorId = 3 },
                new Livro { Id = 11, Titulo = "O lobo da estepe", Tipo = "Romance", AnoLancamento = 1927, AutorId = 1, EditorId = 3 });
        }
    }
}
