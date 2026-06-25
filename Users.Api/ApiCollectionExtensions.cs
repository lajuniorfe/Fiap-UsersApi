
using Users.Api.AppService.Usuarios.Services;
using Users.AppService.events;
using Users.Dominio.Usuarios.Repository;
using Users.Infra.Logger;
using Users.Infra.Usuarios.Repositories;

namespace Users.Api
{
    public static class ApiCollectionExtensions
    {
        public static IServiceCollection AddCorrelationIdGenerator(this IServiceCollection services)
        {
            services.AddTransient<ICorrelationIdGenerator, CorrelationIdGenerator>();
            services.AddTransient<IUsuarioAppService, UsuarioAppService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IRabbitMqPublisher, RabbitMqPublisher>();

            return services;
        }
    }
}
