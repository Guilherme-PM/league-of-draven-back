using AutoMapper;
using LeagueOfDraven.AutoMapper.Profiles;

namespace LeagueOfDraven.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMappers(this IServiceCollection services, MapperConfigurationExpression mce)
        {
            IMapper mapper = new MapperConfiguration(mce).CreateMapper();

            services.AddSingleton(mapper);
        }

        public static MapperConfigurationExpression AddAutoMapperLeagueOfDraven(this MapperConfigurationExpression mce)
        {
            mce.AddProfile<ProfileMatch>();

            return mce;
        }

        public static MapperConfigurationExpression CreateExpression()
        {
            return new MapperConfigurationExpression();
        }
    }
}
