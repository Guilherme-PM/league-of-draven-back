using LeagueOfDraven.Services;
using LeagueOfDraven.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeagueOfDraven
{
    public static class Injector
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ISummonerService, SummonerService>();
            services.AddTransient<RiotApiService>();
        }
    }
}
