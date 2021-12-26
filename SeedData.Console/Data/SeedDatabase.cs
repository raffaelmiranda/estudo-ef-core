using SeedData.Console.Domain;

namespace SeedData.Console.Data
{
    public static class SeedDatabase
    {
        public static void SeedData(VeterinariaContext db)
        {
            if (!db.Clientes.Any())
            {
                var clientes = new List<Cliente>
                {
                    new Cliente { Nome = "Nome01",Cpf = "123123123", DataCadastro = DateTime.Now },
                    new Cliente { Nome = "Nome02",Cpf = "456456456", DataCadastro = DateTime.Now },
                    new Cliente { Nome = "Nome03",Cpf = "789789789", DataCadastro = DateTime.Now }
                };

                db.AddRange(clientes);
                db.SaveChanges();
            }
        }
    }
}
