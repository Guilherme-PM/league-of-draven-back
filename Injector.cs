using LeagueOfDraven.Repository;
using LeagueOfDraven.Repository.Interface;
using LeagueOfDraven.Services;
using LeagueOfDraven.Services.Interfaces;

namespace LeagueOfDraven
{
    public static class Injector
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<RiotApiService>();
            services.AddTransient<AuthenticationService>();

            services.AddTransient<ISummonerService, SummonerService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IChampionsService, ChampionsService>();
            services.AddTransient<IMatchesService, MatchesService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserMatchesRepository, UserMatchesRepository>();
            services.AddScoped<IMatchesChampionsRepository, MatchesChampionsRepository>();
        }
    }
}
