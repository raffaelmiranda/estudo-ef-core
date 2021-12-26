namespace SeedData.Console.Domain
{
    public class Cliente
    {
        public Cliente() { }
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public DateTime DataCadastro { get; set; }

        public ICollection<Animal> Animais { get; set; }

    }
}
