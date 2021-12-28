﻿// <auto-generated />
using ChangeTracker.Console.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChangeTracker.Console.Migrations
{
    [DbContext(typeof(EfCoreContext))]
    [Migration("20211228114356_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ChangeTracker.Console.Domain.Produto", b =>
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
#pragma warning restore 612, 618
        }
    }
}
