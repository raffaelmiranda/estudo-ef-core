using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaDados.Console.Domain
{
    [Table("Livros")]
    public class Livro
    {
        public int LivroId { get; set; }
        [Required]
        [MaxLength(200)]
        public string? Titulo { get; set; }
        public int AnoLancamento { get; set; }
        [Required]
        [MaxLength(200)]
        public string? Url { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Tipo { get; set; }
        public decimal Preco { get; set; }
        public int AutorId { get; set; }
        public Autor? Autor { get; set; }
    }
}
