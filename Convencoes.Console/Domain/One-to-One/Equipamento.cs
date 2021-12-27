namespace Convencoes.Console.Domain.One_to_One
{
    public class Equipamento //entidade dependente
    {
        public int Id { get; set; } //PK
        public string? Local { get; set; }

        
        public int AlunoId { get; set; }  //FK
        public Aluno? Aluno { get; set; } //propriedade de navegação
    }
}
