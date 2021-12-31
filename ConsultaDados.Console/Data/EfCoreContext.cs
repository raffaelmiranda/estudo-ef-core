using ConsultaDados.Console.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConsultaDados.Console.Data
{
    public class EfCoreContext : DbContext
    {
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Autor>? Autores { get; set; }
        public DbSet<Livro>? Livros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SLT-002411\\SQLEXPRESS;Database=EfCoreDb;Trusted_Connection=True");
            optionsBuilder
              .UseLoggerFactory(LoggerFactory.Create(b => b.AddConsole().AddFilter("", LogLevel.Information)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>().HasData(            
                new Autor { Id = 1, Nome = "Agatha Christie", Email = "agaha@email.com", Pais = "Inglaterra" },
                new Autor { Id = 2, Nome = "Hermann Hesse ", Email = "hermann@email.com", Pais = "Alemanha" },
                new Autor { Id = 3, Nome = "Leon Tolstoy", Email = "tolstoy@email.com", Pais = "Russia" },
                new Autor { Id = 4, Nome = "Paulo Coelho", Email = "coelho@email.com", Pais = "Brasil" },
                new Autor { Id = 5, Nome = "C.S.Lewis", Email = "lewis@email.com", Pais = "Inglaterra" },
                new Autor { Id = 6, Nome = "Stephen King", Email = "stephen@email.com", Pais = "USA" },
                new Autor { Id = 7, Nome = "Lewis Carrol", Email = "lewis@email.com", Pais = "Irlanda" },
                new Autor { Id = 8, Nome = "Ian Fleming", Email = "ian@email.com", Pais = "Inglaterra" },
                new Autor { Id = 9, Nome = "Masashi Kshimoto", Email = "masashi@email.com", Pais = "Japão" },
                new Autor { Id = 10, Nome = "J R. R. Tolkien", Email = "tolkien@email.com", Pais = "Inglaterra" },
                new Autor { Id = 11, Nome = "Dan Brown", Email = "dan@email.com", Pais = "USA" });

            modelBuilder.Entity<Livro>().HasData(
                new Livro { LivroId = 1, Titulo = "Assasinato no Oriente Express", AnoLancamento = 1934, Url = "http://www.livro.agathachristie.com", Preco = 35.4M, AutorId = 1, Tipo = "Misterio" },
                new Livro { LivroId = 2, Titulo = "Os cincos porquinhos", AnoLancamento = 1941, Url = "http://www.livro.agathachristie.com", Preco = 25.2M, AutorId = 1, Tipo = "Ficção" },
                new Livro { LivroId = 3, Titulo = "Sidarta", AnoLancamento = 1922, Url = "http://www.livro.hemanhese.com", Preco = 12.5M, AutorId = 2, Tipo = "Romance" },
                new Livro { LivroId = 4, Titulo = "Demian", AnoLancamento = 1919, Url = "http://www.livro.hemanhese.com", Preco = 20.0M, AutorId = 2, Tipo = "Ficção" },
                new Livro { LivroId = 5, Titulo = "O Lobo da estepe", AnoLancamento = 1927, Url = "http://www.livro.hemanhese.com", Preco = 15.8M, AutorId = 2, Tipo = "Romance" },
                new Livro { LivroId = 6, Titulo = "Guerra e Paz", AnoLancamento = 1867, Url = "http://www.livro.leontolstoy.com", Preco = 35.2M, AutorId = 3, Tipo = "Romance" },
                new Livro { LivroId = 7, Titulo = "Anna Karenina", AnoLancamento = 1877, Url = "http://www.livro.leontolstoy.com", Preco = 18.9M, AutorId = 3, Tipo = "Romance" },
                new Livro { LivroId = 8, Titulo = "O Alquimista", AnoLancamento = 1988, Url = "http://www.livro.paulocoelho.com", Preco = 30.25M, AutorId = 4, Tipo = "Ficção" },
                new Livro { LivroId = 9, Titulo = "O diário de um mago", AnoLancamento = 1987, Url = "http://www.livro.paulocoelho.com", Preco = 16.8M, AutorId = 4, Tipo = "Ficção" },
                new Livro { LivroId = 10, Titulo = "Onze Minutos", AnoLancamento = 2001, Url = "http://www.livro.paulocoelho.com", Preco = 17.0M, AutorId = 4, Tipo = "Ficção" },
                new Livro { LivroId = 11, Titulo = "Os quatro amores", AnoLancamento = 1960, Url = "http://www.livro.cslewis.com", Preco = 18.45M, AutorId = 5, Tipo = "Filosofia" },
                new Livro { LivroId = 12, Titulo = "A anatomia de uma dor", AnoLancamento = 1961, Url = "http://www.livro.cslewis.com", Preco = 19.2M, AutorId = 5, Tipo = "Filosofia" },
                new Livro { LivroId = 13, Titulo = "Carrie", AnoLancamento = 1974, Url = "http://www.livro.stephen.com", Preco = 12.5M, AutorId = 6, Tipo = "Terror" },
                new Livro { LivroId = 14, Titulo = "Alice no pais das maravilhas", AnoLancamento = 1865, Url = "http://www.livro.carrol.com", Preco = 13.9M, AutorId = 7, Tipo = "Fantasia" },
                new Livro { LivroId = 15, Titulo = "Cassino Royale", AnoLancamento = 1953, Url = "http://www.livro.ian.com", Preco = 20.25M, AutorId = 8, Tipo = "Romance" },
                new Livro { LivroId = 16, Titulo = "Naruto", AnoLancamento = 2000, Url = "http://www.livro.naruto.com", Preco = 10M, AutorId = 9, Tipo = "Fantasia" },
                new Livro { LivroId = 17, Titulo = "O Hobit", AnoLancamento = 1937, Url = "http://www.livro.hobbit.com", Preco = 25.25M, AutorId = 10, Tipo = "Ficção" },
                new Livro { LivroId = 18, Titulo = "O senhor dos anéis", AnoLancamento = 1954, Url = "http://www.livro.aneis.com", Preco = 40.5M, AutorId = 10, Tipo = "Fantasia" },
                new Livro { LivroId = 19, Titulo = "Origem", AnoLancamento = 2017, Url = "http://www.livro.dan.com", Preco = 12.6M, AutorId = 11, Tipo = "Ficção" },
                new Livro { LivroId = 20, Titulo = "O Simbolo perdido", AnoLancamento = 2009, Url = "http://www.livro.dan.com", Preco = 11.4M, AutorId = 11, Tipo = "Ficção" },
                new Livro { LivroId = 21, Titulo = "O Código da Vinci", AnoLancamento = 2003, Url = "http://www.livro.dan.com", Preco = 30.8M, AutorId = 11, Tipo = "Ficção" });


            modelBuilder.Entity<Produto>().HasData(
                 new Produto { Id = 1, Nome = "Caneta", Estoque = 10, Categoria = "Material Escolar" },
                 new Produto { Id = 2, Nome = "Borracha", Estoque = 15, Categoria = "Material Escolar" },
                 new Produto { Id = 3, Nome = "Estojo", Estoque = 20, Categoria = "Material Escolar" });
        }
    }
}
