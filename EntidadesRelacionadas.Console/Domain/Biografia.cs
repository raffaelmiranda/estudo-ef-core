namespace EntidadesRelacionadas.Console.Domain
{
    public class Biografia
    {
        public int Id { get; set; }
        public string? BiografiaAutor { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Nacionalidade { get; set; }

        public int AutorId { get; set; }
        public virtual Autor? Autor { get; set; }
    }
}
