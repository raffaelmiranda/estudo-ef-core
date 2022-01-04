using System.ComponentModel.DataAnnotations;

namespace EntidadesDesconectadas.Console.Domain
{
    public class Curso
    {
        public int CursoId { get; set; }

        [Required]
        [MaxLength(150)]
        public string? Nome { get; set; }

        public Aluno? Aluno { get; set; }
        public int AlunoId { get; set; }
    }
}
