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
            modelBuilder
                .HasDefaultSchema("Admin")
                .Ignore<Usuario>();

            modelBuilder.Entity<Autor>()
               .ToTable("AutoresPremiados", "Biblioteca")
               .HasKey(a => new { a.AutorId, a.SiglaNome });

            modelBuilder.Entity<Autor>()
                .HasAlternateKey(a => a.Cpf);



            modelBuilder.Entity<Livro>()
                .ToTable("LivrosAutores","Biblioteca")
                .HasKey(l => l.LivroId);

            modelBuilder.Entity<Livro>()
                .Property(p => p.LivroId)
                .ValueGeneratedNever(); //Especifica que o valor para a propriedade nunca será gerado automaticamento pelo banco de dados

            modelBuilder.Entity<Livro>()
               .Property(p => p.DataExpurgo)
               .ValueGeneratedOnAdd();  //Indica que o valor para a propriedade selecionada é gerada pelo banco de dados sempre que uma nova entidade for adicionada ao banco de dados

            modelBuilder.Entity<Livro>()
              .Property(p => p.UltimoAcesso)
              .ValueGeneratedOnAddOrUpdate(); //Indica que o valor para a propriedade selecionada é gerada pelo banco de dados sempre que uma nova entidade for adicionada ao banco de dados ou uma entidade existente for modificada

            modelBuilder.Entity<Livro>()
                .HasIndex(l => l.Isbn);

            modelBuilder.Entity<Livro>()
                .Property(l => l.Titulo)
                .HasColumnName("Descricao")
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Livro>()
                .Property(l => l.Autor)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsConcurrencyToken(); //define que a propriedade vai tomar parte no gerenciamento de concorrencia

            modelBuilder.Entity<Livro>()
               .Property(l => l.Avaliacao)
               .HasDefaultValue(3);

        }
    }
}
