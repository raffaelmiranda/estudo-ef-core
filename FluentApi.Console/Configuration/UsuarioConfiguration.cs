using FluentApi.Console.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentApi.Console.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> modelBuilder)
        {
            modelBuilder
                   .HasKey(p => p.Codigo);

            modelBuilder
               .Property(p => p.User)
               .HasColumnName("Usuario")
               .HasMaxLength(80)
               .IsRequired();

            modelBuilder
               .Property(p => p.Password)
               .HasColumnName("Senha")
               .HasMaxLength(80)
               .IsRequired();

            modelBuilder
               .Property(p => p.Email)
               .HasMaxLength(150)
               .IsRequired();
        }
    }
}
