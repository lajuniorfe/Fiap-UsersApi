using UsersApi.Infra.Logger;

namespace UsersApi
{
    public static class ApiCollectionExtensions
    {
        public static IServiceCollection AddCorrelationIdGenerator(this IServiceCollection services)
        {
            return services.AddTransient<ICorrelationIdGenerator, CorrelationIdGenerator>();
        }
    }
}
