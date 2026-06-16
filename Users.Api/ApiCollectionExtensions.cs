
using Users.Infra.Logger;

namespace Users.Api
{
    public static class ApiCollectionExtensions
    {
        public static IServiceCollection AddCorrelationIdGenerator(this IServiceCollection services)
        {
            return services.AddTransient<ICorrelationIdGenerator, CorrelationIdGenerator>();
        }
    }
}
