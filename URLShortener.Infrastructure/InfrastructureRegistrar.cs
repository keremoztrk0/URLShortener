using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using URLShortener.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Application.Abstracts;

namespace URLShortener.Infrastructure
{
    public static class InfrastructureRegistrar
    {

        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<UrlShortenerDbContext>((provider, builder) =>
            {
                string connectionString = configuration.GetConnectionString("SqlServer")!;
                builder.UseSqlServer(connectionString);
            });
            services.AddScoped<IUrlShortenerDbContext, UrlShortenerDbContext>();
            return services;
        } 
    }
}
