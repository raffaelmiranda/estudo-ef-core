using DataAnotations.Console.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAnotations.Console.Data
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

        public virtual DbSet<Produto> Produtos { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SLT-002411\\SQLEXPRESS;Database=EfCoreDb;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .Property(t => t.Descricao)
                .HasMaxLength(100);

        }
    }
}
