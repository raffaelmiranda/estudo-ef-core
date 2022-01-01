using EntidadesRelacionadas.Console.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntidadesRelacionadas.Console.Configuration
{
    public class BiografiaConfiguration : IEntityTypeConfiguration<Biografia>
    {
        public void Configure(EntityTypeBuilder<Biografia> modelBuilder)
        {
            modelBuilder.HasKey(a => a.Id);

            modelBuilder
                .Property(p => p.BiografiaAutor)
                .HasMaxLength(400)
                .IsRequired();

            modelBuilder
                .Property(p => p.Nacionalidade)
                .HasMaxLength(80)
                .IsRequired();
        }
    }
}
