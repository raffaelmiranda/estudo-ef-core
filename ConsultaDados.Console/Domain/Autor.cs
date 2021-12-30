using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaDados.Console.Domain
{
    [Table("Autores")]
    public class Autor
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Nome { get; set; }
        [Required]
        [MaxLength(200)]
        public string? Email { get; set; }
        [Required]
        [MaxLength(80)]
        public string? Pais { get; set; }
        public ICollection<Livro> Livros { get; set; }
    }
}
