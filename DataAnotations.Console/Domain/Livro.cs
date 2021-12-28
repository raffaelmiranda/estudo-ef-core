using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnotations.Console.Domain
{
    public class Livro
    {
        public int LivroId { get; set; }
        public string? Titulo { get; set; }

        [ForeignKey("AutorFK")]
        public Autor? Autor { get; set; }

        //[ForeignKey("Autor")]
        public int AutorFK { get; set; }
    }
}
