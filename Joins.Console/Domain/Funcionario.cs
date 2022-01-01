using System.ComponentModel.DataAnnotations;

namespace Joins.Console.Domain
{

    public class Funcionario
    {
        public int FuncionarioId { get; set; }

        [MaxLength(80)]
        public string? FuncionarioNome { get; set; }

        [MaxLength(80)]
        public string? FuncionarioCargo { get; set; }

        public int? SetorId { get; set; }
    }
}
