namespace FluentApi.Console.Domain
{
    public class Livro
    {
        public int LivroId { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public int Avaliacao { get; set; }
        public DateTime DataExpurgo { get; set; }
        public DateTime UltimoAcesso { get; set; }
        public string? Isbn { get; set; }

    }
}
