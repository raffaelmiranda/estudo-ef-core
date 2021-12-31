
using Joins.Console.Data;

var contexto = new EfCoreContext();

//PopulaBancoDados(contexto);

#region Query Sintax
InnerJoin(contexto);
#endregion

#region Method Sintax
InnerJoin2(contexto);
#endregion

void PopulaBancoDados(EfCoreContext contexto)
{
    using (contexto)
    {
        try
        {
            SeedDatabase.PopulaDB(contexto);
            Console.WriteLine("Concluído com sucesso");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro : " + ex.Message);
        }
    }
}

#region Query Sintax
void InnerJoin(EfCoreContext contexto)
{
    var innerJoin = from f in contexto.Funcionarios
                    join s in contexto.Setores on f.SetorId equals s.SetorId
                    select new
                    {
                        Nome = f.FuncionarioNome,
                        Cargo = f.FuncionarioCargo,
                        Setor = s.SetorNome
                    };

    Console.WriteLine("Funcionario\t\tCargo\t\tSetor");
    foreach (var resultado in innerJoin)
    {
        Console.WriteLine(resultado.Nome + "\t\t" + resultado.Cargo + "\t\t" + resultado.Setor);
    }
}
#endregion

#region Method Sintax
void InnerJoin2(EfCoreContext contexto)
{
    var innerJoin = contexto.Funcionarios                   //tabela externa
                        .Join(contexto.Setores,             //tabela interna
                            f => f.SetorId, s => s.SetorId, //condição para unir as tabelas: 1 argumento é a tabela externa e o segundo argumento é a tabela interna
                            (f, s) => new                   //Projeção do resultado para um novo tipo
                            {
                                Nome = f.FuncionarioNome,
                                Cargo = f.FuncionarioCargo,
                                Setor = s.SetorNome
                            });
      
}
#endregion

Console.ReadKey();

