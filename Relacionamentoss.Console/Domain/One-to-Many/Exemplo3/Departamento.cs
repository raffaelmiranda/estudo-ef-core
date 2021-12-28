namespace Relacionamentos.Console.Domain.One_to_Many.Exemplo3
{
    public class Departamento //entidade principal
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public ICollection<Funcionario>? Funcionarios { get; set; }
    }
}
