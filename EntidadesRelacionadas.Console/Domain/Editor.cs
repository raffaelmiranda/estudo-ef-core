namespace EntidadesRelacionadas.Console.Domain
{
    public class Editor
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public virtual ICollection<Livro>? Livros { get; set; }
    }
}
