namespace Relacionamentos.Console.Domain.Exemplo2
{
    public class Animal
    {
        public Animal() { }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public DateTime DataCadastro { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
