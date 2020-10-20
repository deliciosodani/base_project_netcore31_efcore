using eClinica.Core.Interfaces;
using eClinica.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eClinica.Core.Extensions
{
    public static class ScopedServiceCollection
    {
        public static IServiceCollection AddCoreScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IAtencionDelDiaService, AtencionDelDiaService>();
            return services;
        }
    }
}