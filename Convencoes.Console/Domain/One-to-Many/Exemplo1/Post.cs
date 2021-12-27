namespace Convencoes.Console.Domain.One_to_Many.Exemplo1
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime Published { get; set; }

        //FK
        public int BlogId { get; set; }

        //Propriedade de Navegação de Referência
        public Blog? Blog { get; set; }
    }
}
