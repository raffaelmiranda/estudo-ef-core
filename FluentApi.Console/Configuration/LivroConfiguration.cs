using FluentApi.Console.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentApi.Console.Configuration
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> modelBuilder)
        {
            modelBuilder
                .Property(p => p.Titulo)
                .HasColumnName("Descricao")
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder
                .Property(p => p.Autor)
                .HasColumnType("varchar(100)")
                .IsConcurrencyToken(); //define que a propriedade vai tomar parte no gerenciamento de concorrencia

            modelBuilder
                .Property(p => p.Avaliacao)
                .HasDefaultValue(3);

            modelBuilder
                .ToTable("LivrosAutores", "Biblioteca")
                .HasKey(l => l.LivroId);

            modelBuilder
                .Property(p => p.LivroId)
                .ValueGeneratedNever(); //Especifica que o valor para a propriedade nunca será gerado automaticamento pelo banco de dados

            modelBuilder
               .Property(p => p.DataExpurgo)
               .ValueGeneratedOnAdd(); //Indica que o valor para a propriedade selecionada é gerada pelo banco de dados sempre que uma nova entidade for adicionada ao banco de dados

            modelBuilder
               .Property(p => p.UltimoAcesso)
               .ValueGeneratedOnAddOrUpdate(); //Indica que o valor para a propriedade selecionada é gerada pelo banco de dados sempre que uma nova entidade for adicionada ao banco de dados ou uma entidade existente for modificada

            modelBuilder
                .HasIndex(l => l.Isbn);
        }
    }
}
