using AutoMapper;
using eClinica.Core.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace eClinica.Core.Extensions
{
    public static class MapperService
    {
        public static IServiceCollection AddMapperService(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
