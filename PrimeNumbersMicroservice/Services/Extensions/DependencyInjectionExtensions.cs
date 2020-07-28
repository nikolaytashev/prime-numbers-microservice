using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

namespace Services.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPrimeNumbersService, PrimeNumbersService>();
            services.AddScoped<IPrimeNumbersCacheService, PrimeNumbersCacheService>();
        }
    }
}
