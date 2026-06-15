using UsersApi.Entities.Usuarios.Repository;
using UsersApi.Infra.Usuarios.Repositories;

namespace UsersApi.Infra
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
