namespace Convencoes.Console.Domain.Many_to_Many
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public ICollection<EstudanteCurso>? EstudanteCursos { get; set; }
    }
}
