using Microsoft.EntityFrameworkCore;
using SeedData.Console.Domain;

namespace SeedData.Console.Data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedDatabase(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasData(
               new Animal
               {
                   Id = 4,
                   Nome = "animal 04",
                   DataCadastro = DateTime.Now,
                   Idade = 4
               },
               new Animal
               {
                   Id = 5,
                   Nome = "animal 05",
                   DataCadastro = DateTime.Now,
                   Idade = 9
               });
        }
    }
}
