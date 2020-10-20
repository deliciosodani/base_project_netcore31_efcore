using Microsoft.Extensions.DependencyInjection;

namespace eClinica.Infrastructure.Extensions
{
    public static class ScopedServiceCollection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
