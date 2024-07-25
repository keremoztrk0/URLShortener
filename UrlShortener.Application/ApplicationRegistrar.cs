using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Application.ShortenedUrls;

namespace UrlShortener.Application
{
    public static class ApplicationRegistrar
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddScoped<IUrlShortenerService, UrlShortenerService>();
            return services;
        }
    }
}
