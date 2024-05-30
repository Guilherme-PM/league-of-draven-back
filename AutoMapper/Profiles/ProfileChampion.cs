using AutoMapper;
using LeagueOfDraven.DTO.Summoner;
using LeagueOfDraven.Models.RIOT.Champions;

namespace LeagueOfDraven.AutoMapper.Profiles
{
    public class ProfileChampion : Profile
    {
        public ProfileChampion() 
        {
            CreateMap<ChampionMasteries, SummonerMasteryDTO>()
                .ForMember(x => x.ChampionName, y => y.MapFrom(z => z.ChampionId)).ReverseMap();
        }
    }
}
