using Microsoft.EntityFrameworkCore;
using MostraSQL.Console.Domain;
using System.Diagnostics;

namespace MostraSQL.Console.Data
{
    public class EfCoreContext : DbContext
    {

        public DbSet<Produto>? Produtos { get; set; }

        private readonly StreamWriter _logStream = new StreamWriter("mylog.txt", append: true);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SLT-002411\\SQLEXPRESS;Database=EfCoreDb;Trusted_Connection=True");
            
            //Log Console
            optionsBuilder.LogTo(System.Console.WriteLine);

            //Log Janela Ouput
            //optionsBuilder.LogTo(message => Debug.WriteLine(message));

            //Log Arquivo
            //optionsBuilder.LogTo(_logStream.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasData(
                new Produto
                {
                    Id = 1,
                    Nome = "Caneta",
                    Estoque = 10,
                    Categoria = "Material Escolar"
                },
                new Produto
                {
                    Id = 2,
                    Nome = "Borracha",
                    Estoque = 15,
                    Categoria = "Material Escolar"
                },
                new Produto
                {
                    Id = 3,
                    Nome = "Estojo",
                    Estoque = 20,
                    Categoria = "Material Escolar"
                });
        }

        public override void Dispose()
        {
            base.Dispose();
            _logStream.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await _logStream.DisposeAsync();
        }
    }
}
