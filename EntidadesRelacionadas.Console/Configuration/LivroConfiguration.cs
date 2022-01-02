using EntidadesRelacionadas.Console.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntidadesRelacionadas.Console.Configuration
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> modelBuilder)
        {
            modelBuilder.HasKey(a => a.Id);

            modelBuilder
                .Property(p => p.Titulo)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder
                .Property(p => p.Tipo)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder
               .Property(p => p.EditorId)
               .HasColumnType("int")
               .IsRequired(false);

            //um-para-muitos :  Livros - Autor
            modelBuilder
              .HasOne(s => s.Autor)
                .WithMany(g => g.Livros)
                   .HasForeignKey(s => s.AutorId);

            //um-para-muitos :  Livro-Editor
            modelBuilder
                .HasOne(s => s.Editor)
                  .WithMany(g => g.Livros);
        }
    }
}
