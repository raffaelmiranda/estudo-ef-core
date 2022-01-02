
using EntidadesRelacionadas.Console.Data;
using EntidadesRelacionadas.Console.Domain;
using Microsoft.EntityFrameworkCore;

var contexto = new EfCoreContext();

//SemEagerLoding(contexto);
//EagerLoding(contexto);
//EagerLodingMaisIncludes(contexto);
//EagerLodingIncludeThenInclude(contexto);
//EagerLodingComWhere(contexto);

//ExplicitLoading(contexto);
//ExplicitLoadingComQuery(contexto);
//ExplicitLoadingComIsLoaded(contexto);

//LazyLoading(contexto);

//SalvarEntidadesRelacionadas(contexto);
//SalvarEntidadesRelacionadas2(contexto);
//SalvarEntidadesRelacionadas3(contexto);

void SemEagerLoding(EfCoreContext contexto)
{
    var autor = contexto.Autores.Single(c => c.Id == 1);

    Console.WriteLine(autor.Nome);
    foreach (var item in autor.Livros)
    {
        Console.WriteLine("\t" + item.Titulo);
    }
}

void EagerLoding(EfCoreContext contexto)
{
    var autor = contexto.Autores
        .Include(l => l.Livros)
        .Single(c => c.Id == 1);

    Console.WriteLine($"{autor.Nome}");

    foreach (var item in autor.Livros)
    {
        Console.WriteLine("\t" + item.Titulo);
    }
}

void EagerLodingMaisIncludes(EfCoreContext contexto)
{
    var autor = contexto.Autores
        .Include(l => l.Livros)
        .Include(l => l.Biografia)
        .Single(c => c.Id == 1);

    Console.WriteLine($"{autor.Nome} \t {autor.Biografia.Nacionalidade}");

    foreach (var item in autor.Livros)
    {
        Console.WriteLine("\t" + item.Titulo);
    }
}

void EagerLodingIncludeThenInclude(EfCoreContext contexto)
{
    var resultado = contexto.Livros
        .Include(l => l.Autor)
        .ThenInclude(a => a.Biografia).ToList();

    foreach (var item in resultado)
    {
        Console.WriteLine($"{item.Titulo} -> {item.Autor.Nome} -> {item.Autor.Biografia.Nacionalidade}");
    }
}

void EagerLodingComWhere(EfCoreContext contexto)
{
    var resultado = contexto.Autores
                    .Where(s => s.Nome == "Herman Hesse")
                    .Include(s => s.Biografia)
                    .FirstOrDefault();

    Console.WriteLine($"{resultado.Nome} -> {resultado.Biografia.DataNascimento.ToShortDateString()} -> {resultado.Biografia.Nacionalidade}");
}

void ExplicitLoading(EfCoreContext contexto)
{
    var resultado = contexto.Autores.Single(b => b.Id == 1);


    contexto.Entry(resultado).Collection(b => b.Livros).Load();

    contexto.Entry(resultado).Reference(b => b.Biografia).Load();

    Console.WriteLine(resultado.Nome);
    Console.WriteLine(resultado.Biografia.Nacionalidade);

    foreach (var item in resultado.Livros)
    {
        Console.WriteLine($"\t{item.Titulo}");
    }
}

void ExplicitLoadingComQuery(EfCoreContext contexto)
{
    var resultado = contexto.Autores.Single(b => b.Id == 1);

    contexto.Entry(resultado)
         .Collection(b => b.Livros)
         .Query().Where(l => l.AnoLancamento > 1920)
         .Load();

    contexto.Entry(resultado)
         .Reference(b => b.Biografia)
         .Load();

    Console.WriteLine(resultado.Nome);
    Console.WriteLine(resultado.Biografia.Nacionalidade);
    foreach (var item in resultado.Livros)
    {
        Console.WriteLine($"\t{item.Titulo}");
    }
}

void ExplicitLoadingComIsLoaded(EfCoreContext contexto)
{
    var resultado = contexto.Autores.Single(b => b.Id == 1);


    if (!contexto.Entry(resultado).Collection(b => b.Livros).IsLoaded)
        contexto.Entry(resultado).Collection(b => b.Livros).Load(); //Carregando explicitamenteo a propriedade de coleção livros

    if (!contexto.Entry(resultado).Reference(b => b.Biografia).IsLoaded)
        contexto.Entry(resultado).Reference(b => b.Biografia).Load(); //Carregando explicitamenteo a propriedade de referencia biografia

    Console.WriteLine(resultado.Nome);
    Console.WriteLine(resultado.Biografia.Nacionalidade);

    foreach (var item in resultado.Livros)
    {
        Console.WriteLine($"\t{item.Titulo}");
    }
}

void LazyLoading(EfCoreContext contexto)
{
    var resultado = contexto.Autores;

    foreach (var item in resultado)
    {
        Console.WriteLine($"{item.Nome}");
        Console.WriteLine($"\t{item.Biografia.Nacionalidade}");

        foreach (var l in item.Livros)
        {
            Console.WriteLine("\t\t" + l.Titulo);
        }
    }
}

void SalvarEntidadesRelacionadas(EfCoreContext contexto)
{
    //Entidade autor nova com entidades livros novas
    var autor = new Autor
    {
        Nome = "Clarice Lispector",
        Email = "clarice@email.com",
        Livros = new List<Livro>
        {
            new Livro { Titulo = "Água viva", Tipo = "Romance", AnoLancamento = 1973 },
            new Livro { Titulo = "Laço de Familia", Tipo = "Contos", AnoLancamento = 1960 }
        }
    };

    contexto.Autores.Add(autor);
    contexto.SaveChanges();
}

void SalvarEntidadesRelacionadas2(EfCoreContext contexto)
{
    //Entidade autor ja existente
    //Entidade livro novo
    var autor = contexto.Autores.Include(l => l.Livros).First();
    var livro = new Livro { Titulo = "Perto do coração selvagem", Tipo = "Romance", AnoLancamento = 1943 };
    
    autor.Livros.Add(livro);
    contexto.SaveChanges();
}

void SalvarEntidadesRelacionadas3(EfCoreContext contexto)
{
    //Entidade autor novo
    //Entidade livro existente
    var autor = new Autor { Nome = "Fernando Pessoa", Email = "pessoa@email.com" };
    var livro = contexto.Livros.OrderBy(l => l.Id).Last();
  
    livro.Autor = autor;
    contexto.SaveChanges();
}

Console.ReadKey();