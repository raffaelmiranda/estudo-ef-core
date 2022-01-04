using EntidadesDesconectadas.Console.Data;
using EntidadesDesconectadas.Console.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;

var enderecoAluno = new Endereco { Cidade = "Campinas", Pais = "Brasil" };
var aluno = new Aluno { Nome = "Novo Aluno 4", Endereco = enderecoAluno };

var contexto = new EfCoreContext();

ExibirEstadoEntidade(aluno, contexto);

//contexto.Attach(aluno);
contexto.Add(aluno);

ExibirEstadoEntidade(aluno, contexto);

ExibirEstado(contexto.ChangeTracker.Entries());

contexto.SaveChanges();

Console.ReadKey();

void ExibirEstado(IEnumerable<EntityEntry> entries)
{
    foreach (var entry in entries)
    {
        Console.WriteLine($"\nEntidade => {entry.Entity.GetType().Name}, State = " +
            $"{ entry.State.ToString()}");
    }
}

void ExibirEstadoEntidade(Aluno aluno, EfCoreContext contexto)
{
    var entry = contexto.Entry(aluno);
    Console.WriteLine(entry.Entity.GetType().Name + " - " + entry.State);
}
