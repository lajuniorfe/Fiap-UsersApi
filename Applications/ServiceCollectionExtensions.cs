using UsersApi.Applications.Auth.Services;
using UsersApi.Applications.Auth.Services.Interfaces;
using UsersApi.Applications.UsuarioApp.Services;
using UsersApi.Applications.UsuarioApp.Services.Interface;

namespace UsersApi.Applications
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAplicationCollection(this IServiceCollection services)
        {
            services.AddTransient<IAuthAppService, AuthAppService>();
            services.AddTransient<IUsuarioAppService, UsuarioAppService>();
            

            return services;
        }
    }
}
