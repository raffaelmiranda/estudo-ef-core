namespace Convencoes.Console.Domain.One_to_One
{
    public class Aluno //entidade principal
    {
        public int AlunoId { get; set; } //PK
        public string? Nome { get; set; }

        //propriedade de navegação
        public Equipamento? Equipamento { get; set; }

        //propriedade de navegação
        public Endereco? Endereco { get; set; }

    }
}
