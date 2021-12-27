namespace Convencoes.Console.Domain.Many_to_Many
{
    public class Estudante
    {
        public int EstudanteId { get; set; }
        public string? Nome { get; set; }
        public ICollection<EstudanteCurso>? EstudanteCursos { get; set; }
    }
}
