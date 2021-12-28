using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAnotations.Console.Domain
{
    [Table("ProdutosNovos",Schema = "Admin")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }
        [Column("NomeProduto", TypeName = "varchar(130)")]
        public string? Nome { get; set; }
        [Required]
        [StringLength(200)]
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        [NotMapped]
        public int Estoque { get; set; }
    }
}
