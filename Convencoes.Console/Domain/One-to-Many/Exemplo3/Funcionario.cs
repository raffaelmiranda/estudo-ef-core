namespace Convencoes.Console.Domain.One_to_Many.Exemplo3
{
    public class Funcionario //entidade dependente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        //Se não colocar a propridade DepartamentoId, 
        //a tabela Funcionario a FK DepartamentoId no banco será opcional, permitindo nulo
        public int DepartamentoId { get; set; }  //Propriedade que vai representar a FK no banco
        public Departamento? Departamento { get; set; }
    }
}
