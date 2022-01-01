using System.ComponentModel.DataAnnotations;

namespace Joins.Console.Domain
{

    public class Setor
    {
        public int SetorId { get; set; }
        [MaxLength(80)]
        public string? SetorNome { get; set; }
    }
}
