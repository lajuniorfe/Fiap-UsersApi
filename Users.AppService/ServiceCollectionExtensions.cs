using Microsoft.Extensions.DependencyInjection;
using Users.App.Usuarios.Services;
using Users.AppService.Auth.Services;
using Users.AppService.Auth.Services.Interfaces;
using Users.AppService.events;


namespace Users.AppService
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAplicationCollection(this IServiceCollection services)
        {
            services.AddTransient<IAuthAppService, AuthAppService>();
            services.AddTransient<IUsuarioAppService, UsuarioAppService>();
            services.AddTransient<IRabbitMqPublisher, RabbitMqPublisher>();


            return services;
        }
    }
}
