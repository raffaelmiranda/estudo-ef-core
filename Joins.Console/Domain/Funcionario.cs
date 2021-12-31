using System.ComponentModel.DataAnnotations;

namespace Joins.Console.Domain
{
    //Entidade principal (pai)
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        [MaxLength(80)]
        public string? FuncionarioNome { get; set; }
        [MaxLength(80)]
        public string? FuncionarioCargo { get; set; }

        //prop. de navegação inversa
        //public Setor Setor { get; set; }
        //prop. navegacao de referência (chave estrangeira)

        public int? SetorId { get; set; }
    }
}
