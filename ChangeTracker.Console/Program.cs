using ChangeTracker.Console.Data;
using ChangeTracker.Console.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using (var contexto = new EfCoreContext())
{
    MostrarProdutos(contexto);

    IncluirProduto(contexto);

    AlterandoProduto(contexto);

    Console.ReadKey();
}



void MostrarProdutos(EfCoreContext contexto)
{
    Console.WriteLine(Environment.NewLine);
    Console.WriteLine("Mostrar os Produtos");

    var produtos = contexto.Produtos;

    foreach (var p in produtos)
        Console.WriteLine(p.Nome);
   
}

void ExibirEstado(IEnumerable<EntityEntry> entries)
{
    Console.WriteLine(Environment.NewLine);

    foreach (var entrada in entries)
        Console.WriteLine($"Estado da entidade : {entrada.State}");
    
}

void IncluirProduto(EfCoreContext contexto)
{
    Console.WriteLine(Environment.NewLine);
    Console.WriteLine("========= Incluindo um novo produto ===========");

    Produto novoProduto = new Produto();
    novoProduto.Nome = "Produto Novo";
    novoProduto.Estoque = 10;
    novoProduto.Categoria = "Nova categoria";

    contexto.Produtos?.Add(novoProduto);
    //contexto.SaveChanges();

    MostrarProdutos(contexto);

    ExibirEstado(contexto.ChangeTracker.Entries());
}

void AlterandoProduto(EfCoreContext contexto)
{
    Console.WriteLine(Environment.NewLine);
    Console.WriteLine("=========== Alterando o produto 1 ===========");

    var produtoAlterar = contexto.Produtos.Find(1);
    produtoAlterar.Nome = "Nome produto alterado";

    //contexto.SaveChanges();

    MostrarProdutos(contexto);

    ExibirEstado(contexto.ChangeTracker.Entries());
}