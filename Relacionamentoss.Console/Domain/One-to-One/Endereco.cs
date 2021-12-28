namespace Relacionamentos.Console.Domain.One_to_One
{
    public class Endereco //entidade dependente
    {
        public int Id { get; set; }
        public string? Local { get; set; }
        public string? Cidade { get; set; }

        public int AlunoId { get; set; }  //FK
        public Aluno? Aluno { get; set; } //propriedade de navegação
    }
}
