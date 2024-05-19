using LeagueOfDraven.Data;
using LeagueOfDraven.Models;
using LeagueOfDraven.Repository;
using LeagueOfDraven.Repository.Interface;
using LeagueOfDraven.Services;
using LeagueOfDraven.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeagueOfDraven
{
    public static class Injector
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ISummonerService, SummonerService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IChampionsService, ChampionsService>();
            services.AddTransient<RiotApiService>();
            services.AddTransient<AuthenticationService>();

            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
