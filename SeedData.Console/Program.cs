
using SeedData.Console.Data;

using (var db = new VeterinariaContext())
{
    //Console.WriteLine("Alimentando o banco de dados");
    //SeedDatabase.SeedData(db);

    var clientes = db.Clientes.ToList();
    if (clientes.Count > 0)
    {
        foreach (var c in clientes)
        {
            Console.WriteLine($"{c.Nome}\t{c.DataCadastro}");
        }
    }
}
