namespace EntidadesRelacionadas.Console.Domain
{
    public class Autor
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Livro>? Livros { get; set; }
        public virtual Biografia? Biografia { get; set; }
    }
}
