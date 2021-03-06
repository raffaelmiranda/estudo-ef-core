
using Joins.Console.Data;

var contexto = new EfCoreContext();

//PopulaBancoDados(contexto);

//Query Sintax
//InnerJoin1(contexto);
//LeftJoin1(contexto);
//RightJoin1(contexto);
//FullOutterJoin1(contexto);
//CrossJoin1(contexto);
//GroupJoin1(contexto);

//Method Sintax
//InnerJoin2A(contexto);
//InnerJoin2B(contexto);
//LeftJoin2A(contexto);
//LeftJoin2B(contexto);
GroupJoin2(contexto);

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

//Query Sintax
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
                        join s in contexto.Setores on f.SetorId equals s.SetorId into grouping
                        from setor in grouping.DefaultIfEmpty()
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

void RightJoin1(EfCoreContext contexto)
{
    Console.WriteLine("============= Righ Join 1 =============");
    var rightOuterJoin = from s in contexto.Setores
                        join f in contexto.Funcionarios on s.SetorId equals f.SetorId into funci
                        from funcionario in funci.DefaultIfEmpty()
                        select new
                        {
                            Nome = funcionario.FuncionarioNome,
                            Cargo = funcionario.FuncionarioCargo,
                            Setor = s.SetorNome
                        };

    Console.WriteLine("Funcionario\t\tCargo\t\tSetor");
    foreach (var resultado in rightOuterJoin)
    {
        Console.WriteLine(resultado.Setor + "\t\t" + resultado.Nome + "\t\t" + resultado.Cargo);
    }
}

void FullOutterJoin1(EfCoreContext contexto)
{
    var leftOuterJoin = from f in contexto.Funcionarios
                        join s in contexto.Setores on f.SetorId equals s.SetorId into set
                        from setor in set.DefaultIfEmpty()
                        select new
                        {
                            Nome = f.FuncionarioNome,
                            Cargo = f.FuncionarioCargo,
                            Setor = setor.SetorNome
                        };

    var rightOuterJoin = from s in contexto.Setores
                         join f in contexto.Funcionarios on s.SetorId equals f.SetorId into funci
                         from funcionario in funci.DefaultIfEmpty()
                         select new
                         {
                             Nome = funcionario.FuncionarioNome,
                             Cargo = funcionario.FuncionarioCargo,
                             Setor = s.SetorNome
                         };

    var outterJoin = leftOuterJoin.Union(rightOuterJoin);

    Console.WriteLine("Funcionario\t\tCargo\t\tSetor");
    foreach (var resultado in outterJoin)
    {
        if (!string.IsNullOrEmpty(resultado.Nome))
            Console.WriteLine(resultado.Nome + "\t\t" + resultado.Cargo + "\t" + resultado.Setor);
        else
            Console.WriteLine(resultado.Nome + "\t\t" + resultado.Cargo + "\t\t" + resultado.Setor);
    }
}

void CrossJoin1(EfCoreContext contexto)
{
    var crossJoin = from f in contexto.Funcionarios
                    from s in contexto.Setores 
                    orderby f.FuncionarioNome
                    select new
                    {
                        Nome = f.FuncionarioNome,
                        Cargo = f.FuncionarioCargo,
                        Setor = s.SetorNome
                    }
                    ;

    Console.WriteLine("Funcionario\t\tCargo\t\t\tSetor");

    Console.WriteLine("Funcionario\t\tCargo\t\tSetor");
    foreach (var resultado in crossJoin)
    {
        Console.WriteLine(resultado.Nome + "\t\t" + resultado.Cargo + "\t\t" + resultado.Setor);
    }
}

void GroupJoin1(EfCoreContext contexto)
{
    var groupJoin = from s in contexto.Setores
                    join e in contexto.Funcionarios on s.SetorId equals e.SetorId into funci
                    select new
                    {
                        CodigoSetor = s.SetorId,
                        NomeSetor = s.SetorNome,
                        Funcionarios = funci
                    };

    foreach (var resultado in groupJoin)
    {
        Console.WriteLine("Setor:" + resultado.CodigoSetor + " - " + resultado.NomeSetor);

        if (resultado.Funcionarios != null && resultado.Funcionarios.Count() > 0)
        {
            Console.WriteLine("Nome\t\t\tCargo");

            foreach (var funci in resultado.Funcionarios)
            {
                Console.WriteLine(funci.FuncionarioNome + "\t\t" + funci.FuncionarioCargo);
            }
        }
        else
        {
            Console.WriteLine("Setor não tem funcionários.");
        }
        Console.WriteLine("");
    }
}

//Method Sintax
void InnerJoin2A(EfCoreContext contexto)
{
    Console.WriteLine("============= Inner Join 2 - A =============");

    var innerJoin1 = contexto.Funcionarios                  //tabela externa
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

void GroupJoin2(EfCoreContext contexto)
{
    var groupJoin = contexto.Setores.GroupJoin(contexto.Funcionarios,
                                s => s.SetorId,         
                                f => f.SetorId,       
                                (f, funcionariosGrupo) => new
                                {
                                    Funcionarios = funcionariosGrupo,
                                    NomeSetor = f.SetorNome
                                });

    foreach (var item in groupJoin)
    {
        Console.WriteLine(item.NomeSetor);

        foreach (var stud in item.Funcionarios)
            Console.WriteLine($"\t {stud.FuncionarioNome}");
    }
}

Console.ReadKey();

