using System.ComponentModel.DataAnnotations;

namespace EntidadesDesconectadas.Console.Domain
{
    public class Endereco
    {
        public int EnderecoId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Cidade { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Pais { get; set; }

        public Aluno? Aluno { get; set; }
        public int AlunoId { get; set; }
    }
}
