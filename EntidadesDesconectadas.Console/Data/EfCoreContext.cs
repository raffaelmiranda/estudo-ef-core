using EntidadesDesconectadas.Console.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace EntidadesDesconectadas.Console.Data
{
    public class EfCoreContext : DbContext
    {
        public DbSet<Aluno>? Alunos { get; set; }
        public DbSet<Endereco>? Enderecos { get; set; }
        public DbSet<Curso>? Cursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseSqlServer("Server=SLT-002411\\SQLEXPRESS;Database=EfCoreDb;Trusted_Connection=True");

            optionsBuilder
                .LogTo(System.Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information, DbContextLoggerOptions.SingleLine | DbContextLoggerOptions.UtcTime)
                .EnableSensitiveDataLogging(true)
                .EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().HasData(
                new Aluno { AlunoId = 1, Nome = "Maria" },
                new Aluno { AlunoId = 2, Nome = "Janice" },
                new Aluno { AlunoId = 3, Nome = "Jefferson" },
                new Aluno { AlunoId = 4, Nome = "Jessica" },
                new Aluno { AlunoId = 5, Nome = "Pedro" });

            modelBuilder.Entity<Curso>().HasData(
                new Curso { CursoId = 1, Nome = "Matematica", AlunoId = 1 },
                new Curso { CursoId = 2, Nome = "Moda", AlunoId = 4 },
                new Curso { CursoId = 3, Nome = "Web Design", AlunoId = 2 },
                new Curso { CursoId = 4, Nome = "Engenharia", AlunoId = 3 },
                new Curso { CursoId = 5, Nome = "Musica", AlunoId = 4 });

            modelBuilder.Entity<Endereco>().HasData(
                new Endereco { EnderecoId = 1, Cidade = "Goiânia", Pais = "Brasil", AlunoId = 4},
                new Endereco { EnderecoId = 2, Cidade = "São Paulo", Pais = "Brasil", AlunoId = 2 },
                new Endereco { EnderecoId = 3, Cidade = "Santos", Pais = "Brasil", AlunoId = 1 },
                new Endereco { EnderecoId = 4, Cidade = "Toronto", Pais = "Canada", AlunoId = 3 },
                new Endereco { EnderecoId = 5, Cidade = "Lins", Pais = "Brasil", AlunoId = 5 });

          //um-para-muitos :  Aluno - Curso
          modelBuilder.Entity<Curso>()
              .HasOne(s => s.Aluno)
                .WithMany(g => g.Cursos)
                   .HasForeignKey(s => s.AlunoId);

            //um-para-um :  Aluno-Endereco
            modelBuilder.Entity<Aluno>()
              .HasOne(s => s.Endereco)
                .WithOne(ad => ad.Aluno)
                  .HasForeignKey<Endereco>(ad => ad.AlunoId);
        }
    }
}
