using AutoMapper;
using LeagueOfDraven.DTO.Matches;
using LeagueOfDraven.Models;

namespace LeagueOfDraven.AutoMapper.Profiles
{
    public class ProfileMatch : Profile
    {
        public ProfileMatch() 
        {
            CreateMap<UserMatches, MatchDTO>()
                .ForMember(x => x.Players, y => y.MapFrom(z => z.Champions));

            CreateMap<MatchesChampions, MatchPlayersDTO>()
                .ForMember(x => x.ChampionName, y => y.MapFrom(z => z.ChampionName))
                .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName))
                .ForMember(dest => dest.Farm, opt => opt.MapFrom(src => src.UserMatch.PlayerStatistics.FirstOrDefault(p => p.ParticipantId == src.ParticipantId).Farm))
                .ForMember(dest => dest.GoldEarned, opt => opt.MapFrom(src => src.UserMatch.PlayerStatistics.FirstOrDefault(p => p.ParticipantId == src.ParticipantId).GoldEarned))
                .ForMember(dest => dest.GoldSpent, opt => opt.MapFrom(src => src.UserMatch.PlayerStatistics.FirstOrDefault(p => p.ParticipantId == src.ParticipantId).GoldSpent))
                .ForMember(dest => dest.ChampionImageURL, opt => opt.MapFrom(src => $"https://ddragon.leagueoflegends.com/cdn/14.10.1/img/champion/{src.ChampionName}.png"))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.UserMatch.PlayerStatistics.FirstOrDefault(p => p.ParticipantId == src.ParticipantId).Items));

            CreateMap<MatchesPlayerItems, MatchItemsDTO>()
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.ItemName))
                .ForMember(dest => dest.ItemImageURL, opt => opt.MapFrom(src => $"https://ddragon.leagueoflegends.com/cdn/14.10.1/img/item/{src.ItemId}.png"));
        }
    }
}
