namespace Relacionamentos.Console.Domain.Many_to_Many
{
    public class EstudanteCurso
    {
        public int CursoId { get; set; }
        public Curso? Curso { get; set; }
        public int EstudanteId { get; set; }
        public Estudante? Estudante { get; set; }
    }
}
