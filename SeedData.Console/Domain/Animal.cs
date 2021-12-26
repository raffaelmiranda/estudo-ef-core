namespace SeedData.Console.Domain
{
    public class Animal
    {
        public Animal() { }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
