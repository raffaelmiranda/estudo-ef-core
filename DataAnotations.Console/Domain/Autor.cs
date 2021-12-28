using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnotations.Console.Domain
{
    public class Autor
    {
        public int AutorId { get; set; }
        public string? Nome { get; set; }

        //[ForeignKey("AutorFK")]
        public ICollection<Livro>? Livro { get; set; }
    }
}
