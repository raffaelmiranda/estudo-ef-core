using Joins.Console.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Joins.Console.Data
{
    public class EfCoreContext : DbContext
    {
        public DbSet<Funcionario>? Funcionarios { get; set; }
        public DbSet<Setor>? Setores { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SLT-002411\\SQLEXPRESS;Database=EfCoreDb;Trusted_Connection=True");
            optionsBuilder
                .EnableSensitiveDataLogging(true)
                .UseLoggerFactory(LoggerFactory.Create(b => b.AddConsole().AddFilter("", LogLevel.Information)));
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //}
    }
}
