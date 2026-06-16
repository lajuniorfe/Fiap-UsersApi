using Microsoft.Extensions.DependencyInjection;
using Users.Dominio.Usuarios.Repository;
using Users.Infra.Usuarios.Repositories;

namespace Users.Infra
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryCollection(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        
            return services;
        }
    }
}
