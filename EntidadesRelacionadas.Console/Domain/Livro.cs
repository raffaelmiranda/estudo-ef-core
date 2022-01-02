namespace EntidadesRelacionadas.Console.Domain
{
    public class Livro
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Tipo { get; set; }
        public int AnoLancamento { get; set; }

        public virtual Autor? Autor { get; set; }
        public int AutorId { get; set; }

        public int? EditorId { get; set; }
        public virtual Editor? Editor { get; set; }

        public override string ToString()
        {
            return Titulo;
        }
    }
}
