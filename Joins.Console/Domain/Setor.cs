using System.ComponentModel.DataAnnotations;

namespace Joins.Console.Domain
{
    //entidade dependente(filha)
    public class Setor
    {
        public int SetorId { get; set; }
        [MaxLength(80)]
        public string? SetorNome { get; set; }

        //prop. de navegação de coleção
        //public ICollection<Funcionario> Funcionarios { get; set; }
    }
}
