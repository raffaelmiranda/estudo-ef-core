using System.ComponentModel.DataAnnotations;

namespace EntidadesDesconectadas.Console.Domain
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        [Required]
        [MaxLength(80)]
        public string? Nome { get; set; }

        public Endereco? Endereco { get; set; }
        public ICollection<Curso>? Cursos { get; set; }
    }
}
