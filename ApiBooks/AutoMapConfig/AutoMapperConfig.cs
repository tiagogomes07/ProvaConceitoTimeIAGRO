using Books.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Books.API.AutoMapConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
        }
    }
}
