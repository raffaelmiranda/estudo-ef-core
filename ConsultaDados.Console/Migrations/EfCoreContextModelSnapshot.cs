﻿// <auto-generated />
using ConsultaDados.Console.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsultaDados.Console.Migrations
{
    [DbContext(typeof(EfCoreContext))]
    partial class EfCoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ConsultaDados.Console.Domain.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Autores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "agaha@email.com",
                            Nome = "Agatha Christie",
                            Pais = "Inglaterra"
                        },
                        new
                        {
                            Id = 2,
                            Email = "hermann@email.com",
                            Nome = "Hermann Hesse ",
                            Pais = "Alemanha"
                        },
                        new
                        {
                            Id = 3,
                            Email = "tolstoy@email.com",
                            Nome = "Leon Tolstoy",
                            Pais = "Russia"
                        },
                        new
                        {
                            Id = 4,
                            Email = "coelho@email.com",
                            Nome = "Paulo Coelho",
                            Pais = "Brasil"
                        },
                        new
                        {
                            Id = 5,
                            Email = "lewis@email.com",
                            Nome = "C.S.Lewis",
                            Pais = "Inglaterra"
                        },
                        new
                        {
                            Id = 6,
                            Email = "stephen@email.com",
                            Nome = "Stephen King",
                            Pais = "USA"
                        },
                        new
                        {
                            Id = 7,
                            Email = "lewis@email.com",
                            Nome = "Lewis Carrol",
                            Pais = "Irlanda"
                        },
                        new
                        {
                            Id = 8,
                            Email = "ian@email.com",
                            Nome = "Ian Fleming",
                            Pais = "Inglaterra"
                        },
                        new
                        {
                            Id = 9,
                            Email = "masashi@email.com",
                            Nome = "Masashi Kshimoto",
                            Pais = "Japão"
                        },
                        new
                        {
                            Id = 10,
                            Email = "tolkien@email.com",
                            Nome = "J R. R. Tolkien",
                            Pais = "Inglaterra"
                        },
                        new
                        {
                            Id = 11,
                            Email = "dan@email.com",
                            Nome = "Dan Brown",
                            Pais = "USA"
                        });
                });

            modelBuilder.Entity("ConsultaDados.Console.Domain.Livro", b =>
                {
                    b.Property<int>("LivroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LivroId"), 1L, 1);

                    b.Property<int>("AnoLancamento")
                        .HasColumnType("int");

                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("LivroId");

                    b.HasIndex("AutorId");

                    b.ToTable("Livros");

                    b.HasData(
                        new
                        {
                            LivroId = 1,
                            AnoLancamento = 1934,
                            AutorId = 1,
                            Preco = 35.4m,
                            Tipo = "Misterio",
                            Titulo = "Assasinato no Oriente Express",
                            Url = "http://www.livro.agathachristie.com"
                        },
                        new
                        {
                            LivroId = 2,
                            AnoLancamento = 1941,
                            AutorId = 1,
                            Preco = 25.2m,
                            Tipo = "Ficção",
                            Titulo = "Os cincos porquinhos",
                            Url = "http://www.livro.agathachristie.com"
                        },
                        new
                        {
                            LivroId = 3,
                            AnoLancamento = 1922,
                            AutorId = 2,
                            Preco = 12.5m,
                            Tipo = "Romance",
                            Titulo = "Sidarta",
                            Url = "http://www.livro.hemanhese.com"
                        },
                        new
                        {
                            LivroId = 4,
                            AnoLancamento = 1919,
                            AutorId = 2,
                            Preco = 20.0m,
                            Tipo = "Ficção",
                            Titulo = "Demian",
                            Url = "http://www.livro.hemanhese.com"
                        },
                        new
                        {
                            LivroId = 5,
                            AnoLancamento = 1927,
                            AutorId = 2,
                            Preco = 15.8m,
                            Tipo = "Romance",
                            Titulo = "O Lobo da estepe",
                            Url = "http://www.livro.hemanhese.com"
                        },
                        new
                        {
                            LivroId = 6,
                            AnoLancamento = 1867,
                            AutorId = 3,
                            Preco = 35.2m,
                            Tipo = "Romance",
                            Titulo = "Guerra e Paz",
                            Url = "http://www.livro.leontolstoy.com"
                        },
                        new
                        {
                            LivroId = 7,
                            AnoLancamento = 1877,
                            AutorId = 3,
                            Preco = 18.9m,
                            Tipo = "Romance",
                            Titulo = "Anna Karenina",
                            Url = "http://www.livro.leontolstoy.com"
                        },
                        new
                        {
                            LivroId = 8,
                            AnoLancamento = 1988,
                            AutorId = 4,
                            Preco = 30.25m,
                            Tipo = "Ficção",
                            Titulo = "O Alquimista",
                            Url = "http://www.livro.paulocoelho.com"
                        },
                        new
                        {
                            LivroId = 9,
                            AnoLancamento = 1987,
                            AutorId = 4,
                            Preco = 16.8m,
                            Tipo = "Ficção",
                            Titulo = "O diário de um mago",
                            Url = "http://www.livro.paulocoelho.com"
                        },
                        new
                        {
                            LivroId = 10,
                            AnoLancamento = 2001,
                            AutorId = 4,
                            Preco = 17.0m,
                            Tipo = "Ficção",
                            Titulo = "Onze Minutos",
                            Url = "http://www.livro.paulocoelho.com"
                        },
                        new
                        {
                            LivroId = 11,
                            AnoLancamento = 1960,
                            AutorId = 5,
                            Preco = 18.45m,
                            Tipo = "Filosofia",
                            Titulo = "Os quatro amores",
                            Url = "http://www.livro.cslewis.com"
                        },
                        new
                        {
                            LivroId = 12,
                            AnoLancamento = 1961,
                            AutorId = 5,
                            Preco = 19.2m,
                            Tipo = "Filosofia",
                            Titulo = "A anatomia de uma dor",
                            Url = "http://www.livro.cslewis.com"
                        },
                        new
                        {
                            LivroId = 13,
                            AnoLancamento = 1974,
                            AutorId = 6,
                            Preco = 12.5m,
                            Tipo = "Terror",
                            Titulo = "Carrie",
                            Url = "http://www.livro.stephen.com"
                        },
                        new
                        {
                            LivroId = 14,
                            AnoLancamento = 1865,
                            AutorId = 7,
                            Preco = 13.9m,
                            Tipo = "Fantasia",
                            Titulo = "Alice no pais das maravilhas",
                            Url = "http://www.livro.carrol.com"
                        },
                        new
                        {
                            LivroId = 15,
                            AnoLancamento = 1953,
                            AutorId = 8,
                            Preco = 20.25m,
                            Tipo = "Romance",
                            Titulo = "Cassino Royale",
                            Url = "http://www.livro.ian.com"
                        },
                        new
                        {
                            LivroId = 16,
                            AnoLancamento = 2000,
                            AutorId = 9,
                            Preco = 10m,
                            Tipo = "Fantasia",
                            Titulo = "Naruto",
                            Url = "http://www.livro.naruto.com"
                        },
                        new
                        {
                            LivroId = 17,
                            AnoLancamento = 1937,
                            AutorId = 10,
                            Preco = 25.25m,
                            Tipo = "Ficção",
                            Titulo = "O Hobit",
                            Url = "http://www.livro.hobbit.com"
                        },
                        new
                        {
                            LivroId = 18,
                            AnoLancamento = 1954,
                            AutorId = 10,
                            Preco = 40.5m,
                            Tipo = "Fantasia",
                            Titulo = "O senhor dos anéis",
                            Url = "http://www.livro.aneis.com"
                        },
                        new
                        {
                            LivroId = 19,
                            AnoLancamento = 2017,
                            AutorId = 11,
                            Preco = 12.6m,
                            Tipo = "Ficção",
                            Titulo = "Origem",
                            Url = "http://www.livro.dan.com"
                        },
                        new
                        {
                            LivroId = 20,
                            AnoLancamento = 2009,
                            AutorId = 11,
                            Preco = 11.4m,
                            Tipo = "Ficção",
                            Titulo = "O Simbolo perdido",
                            Url = "http://www.livro.dan.com"
                        },
                        new
                        {
                            LivroId = 21,
                            AnoLancamento = 2003,
                            AutorId = 11,
                            Preco = 30.8m,
                            Tipo = "Ficção",
                            Titulo = "O Código da Vinci",
                            Url = "http://www.livro.dan.com"
                        });
                });

            modelBuilder.Entity("ConsultaDados.Console.Domain.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estoque")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Categoria = "Material Escolar",
                            Estoque = 10,
                            Nome = "Caneta"
                        },
                        new
                        {
                            Id = 2,
                            Categoria = "Material Escolar",
                            Estoque = 15,
                            Nome = "Borracha"
                        },
                        new
                        {
                            Id = 3,
                            Categoria = "Material Escolar",
                            Estoque = 20,
                            Nome = "Estojo"
                        });
                });

            modelBuilder.Entity("ConsultaDados.Console.Domain.Livro", b =>
                {
                    b.HasOne("ConsultaDados.Console.Domain.Autor", "Autor")
                        .WithMany("Livros")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("ConsultaDados.Console.Domain.Autor", b =>
                {
                    b.Navigation("Livros");
                });
#pragma warning restore 612, 618
        }
    }
}
