﻿using ConsultaDados.Console.Data;
using ConsultaDados.Console.Domain;

var contexto = new EfCoreContext();

//QuerySintax(contexto);

//MethodSintax(contexto);

//ConsultaDiferida(contexto);

//ConsultaImediata(contexto);

//ConsultaElementoUnico(contexto);

//ConsultaElementoAgregacao(contexto);

FiltraDados(contexto);

void QuerySintax(EfCoreContext contexto)
{
    Console.WriteLine("========== Query Sintax ==========");
    var resultado = from p in contexto.Produtos
                    where p.Estoque >= 15
                    orderby p.Nome
                    select p;

    foreach (var produto in resultado)
        Console.WriteLine(produto.Nome);
}

void MethodSintax(EfCoreContext contexto)
{
    Console.WriteLine("========== Method Sintax ==========");
    var produtos = contexto.Produtos
                    .Where(p => p.Estoque >= 15)
                    .OrderBy(p => p.Nome);

    foreach (var produto in produtos)
        Console.WriteLine(produto.Nome);
}

void ConsultaDiferida(EfCoreContext contexto)
{
    Console.WriteLine("========== Consulta Diferida ==========");

    var produtos = contexto.Produtos;

    produtos.Add(new Produto { Nome = "Teste", Estoque = 99, Categoria = "Teste" });

    foreach (var p in produtos) //A consulta de produtos será disparada no momento do for each
    {
        Console.WriteLine(p.Nome);
    }
}

void ConsultaImediata(EfCoreContext contexto)
{
    Console.WriteLine("========== Consulta Diferida ==========");

    var produtos = contexto.Produtos.ToList();  //A consulta de produtos será disparada no momento do ToList()

    produtos.Add(new Produto { Nome = "Teste", Estoque = 99, Categoria = "Teste" });

    foreach (var p in produtos)
    {
        Console.WriteLine(p.Nome);
    }
}

void ConsultaElementoUnico(EfCoreContext contexto)
{
    Console.WriteLine("========== Consulta de Elemento Único ==========");

    var livro1 = contexto.Livros.First();
    Console.WriteLine(livro1.Titulo);

    var livro2 = contexto.Livros.First(l => l.Preco < 20); //Caso não encontre o elemento, irá disparar uma exceção
    Console.WriteLine(livro2.Titulo);

    var livro3 = contexto.Livros.FirstOrDefault();
    Console.WriteLine(livro3?.Titulo);

    var livro4 = contexto.Livros.FirstOrDefault(l => l.Preco < 20);
    Console.WriteLine(livro4.Titulo);

    var livro5 = contexto.Livros.Single(l => l.LivroId == 4);  //Caso não encontre o elemento, irá disparar uma exceção
    Console.WriteLine(livro5.Titulo);

    var livro6 = contexto.Livros.SingleOrDefault(l => l.LivroId == 4);
    Console.WriteLine(livro6.Titulo);

    var livro7 = contexto.Livros.Last();  //Caso não encontre o elemento, irá disparar uma exceção
    Console.WriteLine(livro7.Titulo);

    var livro8 = contexto.Livros.LastOrDefault();
    Console.WriteLine(livro8.Titulo);

    var livro9 = contexto.Livros.Find(3);
    Console.WriteLine(livro9.Titulo);

}

void ConsultaElementoAgregacao(EfCoreContext contexto)
{
    Console.WriteLine("========== Consulta de Elemento com Agregação ==========");

    var precosMaiorQue20 = contexto.Livros.Count(l => l.Preco > 20);
    Console.WriteLine("Valor : " + precosMaiorQue20.ToString());

    var livros = contexto.Livros.Count();
    Console.WriteLine("Valor : " + livros.ToString());

    var maisCaro = contexto.Livros.Max(l => l.Preco);
    Console.WriteLine("Valor : " + maisCaro);

    var maisRecente = contexto.Livros.Max(l => l.AnoLancamento);
    Console.WriteLine("Valor : " + maisRecente);

    var maisBarato = contexto.Livros.Min(l => l.Preco);
    Console.WriteLine("Valor : " + maisBarato);

    var maisAntigo = contexto.Livros.Min(l => l.AnoLancamento);
    Console.WriteLine("Valor : " + maisAntigo);

    var valorTotalLivros = contexto.Livros.Sum(l => l.Preco);
    Console.WriteLine("Valor : " + valorTotalLivros);

    Console.WriteLine("========== Quantificação ==========");

    if (contexto.Livros.Any(l => l.Preco < 10)) //verifica se algum o elemento da condição são atendidas
        Console.WriteLine("Existem livros mais baratos que 10...");
    else
        Console.WriteLine("Não existem livros mais baratos que 10...");

    if (contexto.Livros.All(l => l.AnoLancamento > 1800)) //verifica se todos os elementos da condição são atendidas
        Console.WriteLine("Todos os livros foram lançados deposis de 1800...");
    else
        Console.WriteLine("Nem todos os livros foram lançados deposis de 1800...");
}

void FiltraDados(EfCoreContext contexto)
{
    Console.WriteLine("============ Consulta 01 ============");

    var livros1 = contexto.Livros.Where(l => l.AnoLancamento > 1970);
    foreach (var l in livros1)
        Console.Write($"{l.Titulo}\n");

    Console.WriteLine("============ Consulta 02 ============");
    var livros2 = contexto.Livros.Where(l => l.AnoLancamento > 1970).Count();
    Console.Write($"{livros2}\n");

    Console.WriteLine("============ Consulta 03 ============");

    var livros3 = contexto.Livros
        .Where(l => l.AnoLancamento > 1970 && l.Preco > 25)
        .OrderBy(l => l.Preco)
        .ThenBy(l => l.Preco);

    foreach (var l in livros3)
        Console.Write($"{l.Titulo}\n");

    Console.WriteLine("============ Consulta 04 ============");
    var livros4 = contexto.Livros
        .Where(l => l.AnoLancamento > 1970)
        .OrderByDescending(l => l.AnoLancamento)
        .Select(l => new { TituloLivro = l.Titulo, Lancamento = l.AnoLancamento });

    foreach (var l in livros4)
        Console.Write($"{l.TituloLivro} - {l.Lancamento}\n");

    Console.WriteLine("============ Consulta 05 ============");
    var resultado1 = contexto.Autores
        .Where(a => a.Pais == "Brasil")
        .OrderBy(a => a.Nome)
        .Select(a => a.Livros);

    foreach (var l in resultado1)
        foreach (var livro in l)
        {
            Console.Write($"{livro.Titulo}\n");
        }

    Console.WriteLine("============ Consulta 06 ============");
    var resultado2 = contexto.Autores
        .Where(a => a.Pais == "Brasil")
        .OrderBy(a => a.Nome)
        .SelectMany(a => a.Livros);

    foreach (var l in resultado2)
        Console.Write($"{l.Titulo}\n");

    Console.WriteLine("============ Consulta 07 ============");
    var resultado3 = contexto.Livros.AsEnumerable().GroupBy(l => l.Tipo);
    foreach (var grupo in resultado3)
    {
        Console.Write(grupo.Key);

        foreach (var livro in grupo)
        {
            Console.Write($"\t{livro.Titulo}\n");
        }
    }


}

Console.ReadKey();
