using Microsoft.EntityFrameworkCore;
using MostraSQL.Console.Domain;

namespace MostraSQL.Console.Data
{
    public class EfCoreContext : DbContext
    {


        public DbSet<Produto>? Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SLT-002411\\SQLEXPRESS;Database=EfCoreDb;Trusted_Connection=True");
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
    }
}
