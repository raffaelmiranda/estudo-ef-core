using Microsoft.EntityFrameworkCore;
using Relacionamentos.Console.Domain.Exemplo2;
using Relacionamentos.Console.Domain.Many_to_Many;
using Relacionamentos.Console.Domain.One_to_Many.Exemplo1;
using Relacionamentos.Console.Domain.One_to_Many.Exemplo3;
using Relacionamentos.Console.Domain.One_to_One;

namespace Relacionamentos.Console.Data
{
    public class EfCoreContext : DbContext
    {
        public EfCoreContext()
        {

        }
        public EfCoreContext(DbContextOptions<EfCoreContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Aluno> Alunos { get; set; } = null!;
        public virtual DbSet<Equipamento> Equipamentos { get; set; } = null!;
        public virtual DbSet<Endereco> Enderecos { get; set; } = null!;

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Animal> Animais { get; set; } = null!;

        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;

        public virtual DbSet<Funcionario> Funcionarios { get; set; } = null!;
        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;

        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<Estudante> Estudantes { get; set; } = null!;
        public virtual DbSet<EstudanteCurso> EstudanteCursos { get; set; } = null!;



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SLT-002411\\SQLEXPRESS;Database=EfCoreDb;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Relacionamento UM-PARA-UM

            //Aluno - Endereco
            modelBuilder
                //Aluno - Entidade principal / Aluno
                .Entity<Aluno>()
                //tem um endereço - Propriedade endereço na entidade principal  - Aluno
                .HasOne(e => e.Endereco)
                //com um aluno / Propridade aluno na entidade dependente - Endereco
                .WithOne(a => a.Aluno)
                //Propridade que representa a FK na entidade dependente - Endereco
                .HasForeignKey<Endereco>(a => a.AlunoId);

            //Aluno - Equipamento
            modelBuilder
               //Aluno - Entidade principal / Aluno
               .Entity<Aluno>()
               //tem um equipamento / Propriedade equipamento na entidade principal - Aluno
               .HasOne(e => e.Equipamento)
               //com um aluno / Propridade aluno na entidade dependente - Equipamento
               .WithOne(a => a.Aluno)
               //Propridade que representa a FK na entidade dependente - Equipamento
               .HasForeignKey<Equipamento>(a => a.AlunoId);

            #endregion

            #region Relacionamento UM-PARA-MUITOS

            //Departamento -< Funcionarios
            modelBuilder
                .Entity<Departamento>() //Configuração na entidade principal - opção 01
                .HasMany(f => f.Funcionarios)
                .WithOne(d => d.Departamento)
                //.HasForeignKey(p => p.DepartamentoId)  //Se não colocar a propridade DepartamentoId, a tabela Funcionario a FK DepartamentoId no banco será opcional, permitindo nulo.
                //.IsRequired()                          //Se for definido como Requerido OnDelete será Cascade.
                .OnDelete(DeleteBehavior.ClientSetNull); //Se DepartamentoId for opcional na tabela dependente, quando for excluido o registro na tabela principal o EF Core ira setar nulo na FK.


            //modelBuilder
            //    .Entity<Funcionario>() //Configuração na entidade dependente  - opção 02
            //    .HasOne(d => d.Departamento)
            //    .WithMany(f => f.Funcionarios);          //Se não colocar a propridade DepartamentoId, a tabela Funcionario a FK DepartamentoId no banco será opcional, permitindo nulo
            //    //.HasForeignKey(p => p.DepartamentoId);
            #endregion

            #region Relacionamento MUITOS-PARA-MUITOS
            modelBuilder.Entity<EstudanteCurso>()
                .HasKey(ac => new { ac.EstudanteId, ac.CursoId });

            modelBuilder.Entity<EstudanteCurso>()
                .HasOne(e => e.Estudante)
                .WithMany(ac => ac.EstudanteCursos)
                .HasForeignKey(e => e.EstudanteId);

            modelBuilder.Entity<EstudanteCurso>()
               .HasOne(e => e.Curso)
               .WithMany(ac => ac.EstudanteCursos)
               .HasForeignKey(e => e.CursoId);
            #endregion
        }
    }
}
