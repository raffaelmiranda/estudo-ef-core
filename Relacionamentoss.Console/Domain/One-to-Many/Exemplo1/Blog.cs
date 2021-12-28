namespace Relacionamentos.Console.Domain.One_to_Many.Exemplo1
{
    public class Blog
    {
        public int Id { get; set; }
        public string? Url { get; set; }

        //Propriedade de Navagação de Coleção
        public ICollection<Post>? Posts { get; set; } 
    }
}
