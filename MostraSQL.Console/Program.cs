using Microsoft.EntityFrameworkCore.ChangeTracking;
using MostraSQL.Console.Data;
using MostraSQL.Console.Domain;

using (var contexto = new EfCoreContext())
{
    //var produtos = contexto.Produtos.Where(p => p.Estoque >= 15).ToList();

    InserirProduto(contexto);
    AtualizarProduto(contexto);
    ExcluirProduto(contexto);
}

Console.ReadKey();

void InserirProduto(EfCoreContext contexto)
{
    Console.WriteLine("=============== INSERINDO PRODUTO ===============");

    var produtoNovo = new Produto()
    {
        Nome = "Produto Novo",
        Estoque = 11,
        Categoria = "Nova"
    };

    contexto.Add(produtoNovo);
    ExibeEstado(contexto.ChangeTracker.Entries());

    contexto.SaveChanges();
    ExibeEstado(contexto.ChangeTracker.Entries());

    Console.WriteLine(Environment.NewLine);
}


void AtualizarProduto(EfCoreContext contexto)
{
    Console.WriteLine("=============== ATUALIZANDO PRODUTO ===============");

    var produtoAlterar = contexto.Produtos.First();
    produtoAlterar.Nome = "Nome alterado";

    ExibeEstado(contexto.ChangeTracker.Entries());

    contexto.SaveChanges();
    ExibeEstado(contexto.ChangeTracker.Entries());
}

void ExcluirProduto(EfCoreContext contexto)
{
    Console.WriteLine("=============== EXCLUINDO PRODUTO ===============");

    var produtoExcluir = contexto.Produtos.First();
    contexto.Remove(produtoExcluir);

    ExibeEstado(contexto.ChangeTracker.Entries());

    contexto.SaveChanges();
    var entry = contexto.Entry(produtoExcluir);
    Console.WriteLine($">>>>>>> ESTADO DA ENTIDADE EXCLUÍDA: {entry.State}");
}

void ExibeEstado(IEnumerable<EntityEntry> entries)
{
    foreach (var entrada in entries)
    {
        Console.WriteLine($"\n>>>>>>> ENTIDADE: {entrada.Entity.GetType().Name}, " +
                          $"Estado: { entrada.State.ToString() }");
    }
}
