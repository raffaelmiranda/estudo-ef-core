using EntidadesRelacionadas.Console.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntidadesRelacionadas.Console.Configuration
{
    public class EditorConfiguration : IEntityTypeConfiguration<Editor>
    {
        public void Configure(EntityTypeBuilder<Editor> modelBuilder)
        {
            modelBuilder.HasKey(e => e.Id);

            modelBuilder
              .Property(p => p.Nome)
              .HasMaxLength(100)
              .IsRequired();
        }
    }
}
