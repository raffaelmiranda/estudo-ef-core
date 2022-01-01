using EntidadesRelacionadas.Console.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntidadesRelacionadas.Console.Configuration
{
    public class AutorConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> modelBuilder)
        {
            modelBuilder.HasKey(a => a.Id);

            modelBuilder
                .Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder
                .Property(p => p.Email)
                .HasMaxLength(200)
                .IsRequired();

            //um-para-um :  Autor-Biografia
            modelBuilder
              .HasOne(s => s.Biografia)
                .WithOne(ad => ad.Autor)
                  .HasForeignKey<Biografia>(ad => ad.AutorId);
        }
    }
}
