﻿
using Joins.Console.Data;

var contexto = new EfCoreContext();

//PopulaBancoDados(contexto);

#region Query Sintax
InnerJoin1(contexto);
LeftJoin1(contexto);
#endregion

#region Method Sintax
InnerJoin2A(contexto);
InnerJoin2B(contexto);
LeftJoin2A(contexto);
LeftJoin2B(contexto);
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
void InnerJoin1(EfCoreContext contexto)
{
    Console.WriteLine("============= Inner Join 1 =============");
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

void LeftJoin1(EfCoreContext contexto)
{
    Console.WriteLine("============= Left Join 1 =============");
    var leftOuterJoin = from f in contexto.Funcionarios
                        join s in contexto.Setores on f.SetorId equals s.SetorId into set
                        from setor in set.DefaultIfEmpty()
                        select new
                        {
                            Nome = f.FuncionarioNome,
                            Cargo = f.FuncionarioCargo,
                            Setor = setor.SetorNome
                        };

    Console.WriteLine("Funcionario\t\tCargo\t\tSetor");
    foreach (var resultado in leftOuterJoin)
    {
        Console.WriteLine(resultado.Nome + "\t\t" + resultado.Cargo + "\t\t" + resultado.Setor);
    }
}
#endregion

#region Method Sintax
void InnerJoin2A(EfCoreContext contexto)
{
    Console.WriteLine("============= Inner Join 2 - A =============");

    var innerJoin1 = contexto.Funcionarios                   //tabela externa
                        .Join(contexto.Setores,             //tabela interna
                            f => f.SetorId, s => s.SetorId, //condição para unir as tabelas: 1 argumento é a tabela externa e o segundo argumento é a tabela interna
                            (f, s) => new                   //Projeção do resultado para um novo tipo
                            {
                                Nome = f.FuncionarioNome,
                                Cargo = f.FuncionarioCargo,
                                Setor = s.SetorNome
                            });

    Console.WriteLine("Funcionario\t\tCargo\t\tSetor");
    foreach (var resultado in innerJoin1)
    {
        Console.WriteLine(resultado.Nome + "\t\t" + resultado.Cargo + "\t\t" + resultado.Setor);
    }
}

void InnerJoin2B(EfCoreContext contexto)
{
    Console.WriteLine("============= Inner Join 2 - B =============");
    var innerJoin = contexto.Funcionarios.SelectMany(func => contexto.Setores.Where(setor => func.SetorId == setor.SetorId),
                    (f, s) => new {
                        Nome = f.FuncionarioNome,
                        Cargo = f.FuncionarioCargo,
                        Setor = s.SetorNome
                    });

    Console.WriteLine("Funcionario\t\tCargo\t\tSetor");
    foreach (var resultado in innerJoin)
    {
        Console.WriteLine(resultado.Nome + "\t\t" + resultado.Cargo + "\t\t" + resultado.Setor);
    }
}

void LeftJoin2A(EfCoreContext contexto)
{
    Console.WriteLine("============= Left Join 2 - A =============");

    var leftJoin2 = contexto.Funcionarios
                        .GroupJoin(
                            contexto.Setores,
                            f => f.SetorId,
                            s => s.SetorId,
                            (f, s) => new { funcionario = f, setor = s })
                        .SelectMany(
                            x => x.setor.DefaultIfEmpty(),
                            (f, s) => new
                            {
                                Nome = f.funcionario.FuncionarioNome,
                                Cargo = f.funcionario.FuncionarioCargo,
                                Setor = s.SetorNome
                            });



    Console.WriteLine("Funcionario\t\tCargo\t\tSetor");
    foreach (var resultado in leftJoin2)
    {
        Console.WriteLine(resultado.Nome + "\t\t" + resultado.Cargo + "\t\t" + resultado.Setor);
    }

}

void LeftJoin2B(EfCoreContext contexto)
{
    Console.WriteLine("============= Left Join 2 - B =============");

    var leftJoin = contexto.Funcionarios.SelectMany(func => contexto.Setores.Where(setor => func.SetorId == setor.SetorId).DefaultIfEmpty(),
                   (f, s) => new {
                       Nome = f.FuncionarioNome,
                       Cargo = f.FuncionarioCargo,
                       Setor = s.SetorNome
                   });

    Console.WriteLine("Funcionario\t\tCargo\t\tSetor");
    foreach (var resultado in leftJoin)
    {
        Console.WriteLine(resultado.Nome + "\t\t" + resultado.Cargo + "\t\t" + resultado.Setor);
    }
}
#endregion

Console.ReadKey();

