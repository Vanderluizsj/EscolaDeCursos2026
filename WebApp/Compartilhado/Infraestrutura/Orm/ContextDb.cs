using EscolaDeCursos.WebApp.Modulos.ModuloAluno.Dominio;
using EscolaDeCursos.WebApp.Modulos.ModuloCurso.Dominio;
using EscolaDeCursos.WebApp.Modulos.ModuloCurso.Infraestrutura;
using EscolaDeCursos.WebApp.Modulos.ModuloInstrutor.Dominio;
using Microsoft.EntityFrameworkCore;
using WebApp.Modulos.ModuloAluno.Infraestrutura;
using WebApp.Modulos.ModuloInstrutor.Infraestrutura;

namespace EscolaDeCursos.WebApp.Compartilhado.Infraestrutura.Orm;

public sealed class ContextoDb : DbContext
{
    public ContextoDb(DbContextOptions<ContextoDb> options) : base(options)
    {
    }

    public DbSet<Aluno> Alunos => Set<Aluno>();
    public DbSet<Instrutor> Instrutores => Set<Instrutor>();
    public DbSet<Curso> Cursos => Set<Curso>();
    public DbSet<Aula> Aulas => Set<Aula>();
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AlunoConfiguration());
        modelBuilder.ApplyConfiguration(new InstrutorConfiguration());

        modelBuilder.ApplyConfiguration(new CursoConfiguration());
        modelBuilder.ApplyConfiguration(new AulaConfiguration());
    }
}