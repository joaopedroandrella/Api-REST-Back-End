using JPCadastro.Core.Interfaces.UoW;
using JPCadastro.Infra.Data.Context;
using JPCadastro.Infra.Data.Repositories;
using JPCadastro.Infra.Data.UoW;
using JPCadastro.Operacional.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace JPCadastro
{
    public static class Setup
    {
        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JPCadastros.WebAPI", Version = "v1" });
            });
        }

        public static void ConfigureDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<JPCadastroContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
        }

        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryAluno, RepositoryAluno>();
            services.AddTransient<IRepositoryProfessor, RepositoryProfessor>();
            services.AddTransient<IRepositoryCurso, RepositoryCurso>();
            services.AddTransient<IRepositoryMatricula, RepositoryMatricula>();
        }

        public static void ConfigureMediatorJPCadastroOperacional(this IServiceCollection services)
        {
            var assemblyJPOperacionalDomain = AppDomain.CurrentDomain.Load("JPCadastro.Operacional");
            services.AddMediatR(assemblyJPOperacionalDomain);
        }
    }
}
