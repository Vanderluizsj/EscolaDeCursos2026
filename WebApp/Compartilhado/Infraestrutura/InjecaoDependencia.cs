using EscolaDeCursos.WebApp.Modulos.ModuloAluno.Dominio;
using EscolaDeCursos.WebApp.Modulos.ModuloInstrutor.Dominio;
using EscolaDeCursos.WebApp.Compartilhado.Infraestrutura.Arquivos;
using EscolaDeCursos.WebApp.Modulos.ModuloAluno.Infraestrutura;
using EscolaDeCursos.WebApp.Modulos.ModuloInstrutor.Infraestrutura;
using Microsoft.EntityFrameworkCore;
using EscolaDeCursos.WebApp.Compartilhado.Infraestrutura.Orm;
using EscolaDeCursos.WebApp.Modulos.ModuloCurso.Dominio;
using EscolaDeCursos.WebApp.Modulos.ModuloTurma.Dominio;
using EscolaDeCursos.WebApp.Modulos.ModuloMatricula.Dominio;
using EscolaDeCursos.WebApp.Modulos.ModuloCurso.Infraestrutura;
using EscolaDeCursos.WebApp.Modulos.ModuloTurma.Infraestrutura;
using EscolaDeCursos.WebApp.Modulos.ModuloMatricula.Infraestrutura;
using WebApp.Modulos.ModuloInstrutor.Infraestrutura;
using WebApp.Modulos.ModuloAluno.Infraestrutura;

namespace EscolaDeCursos.WebApp.Compartilhado.Infraestrutura;

public static class InjecaoDependencia
{
    public static void AddInfraRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        //Config persistencia em DB
        services.AddDbContext<ContextoDb>(options =>
        {
            string? connectionString = configuration.GetConnectionString("SqlServer");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'SqlServer' not found.");
            }
            options.UseSqlServer(connectionString, config =>
            {
                config.EnableRetryOnFailure(3); //Latencia de rede, falha temporária, etc. (retries)
            });
        });

        services.AddScoped<IRepositorioInstrutor, RepositorioInstrutorEmOrm>();
        services.AddScoped<IRepositorioAluno, RepositorioAlunoEmOrm>();        
        services.AddScoped<IRepositorioCurso, RepositorioCursoEmOrm>();
        services.AddScoped<IRepositorioAula, RepositorioAulaEmOrm>();
        services.AddScoped<IRepositorioTurma, RepositorioTurmaEmOrm>();
        services.AddScoped<IRepositorioMatricula, RepositorioMatriculaEmOrm>();
    }
}
