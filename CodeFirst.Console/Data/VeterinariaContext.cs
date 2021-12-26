using CodeFirst.Console.Domain;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Console.Data
{
    public class VeterinariaContext : DbContext
    {
        public VeterinariaContext()
        {

        }
        public VeterinariaContext(DbContextOptions<VeterinariaContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Animal> Animais { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SLT-002411\\SQLEXPRESS;Database=VeterinariaDb;Trusted_Connection=True");
        }
    }
}
