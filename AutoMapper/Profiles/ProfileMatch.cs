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
                .ForMember(x => x.Farm, y => y.MapFrom(z => z.UserMatch.PlayerStatistics.FirstOrDefault(xx => xx.ParticipantId == z.ParticipantId).Farm))
                .ForMember(x => x.GoldEarned, y => y.MapFrom(z => z.UserMatch.PlayerStatistics.FirstOrDefault(xx => xx.ParticipantId == z.ParticipantId).GoldEarned))
                .ForMember(x => x.GoldSpent, y => y.MapFrom(z => z.UserMatch.PlayerStatistics.FirstOrDefault(xx => xx.ParticipantId == z.ParticipantId).GoldSpent))
                .ForMember(x => x.ChampionImageURL, y => y.MapFrom(z => $"https://ddragon.leagueoflegends.com/cdn/14.10.1/img/champion/{z.ChampionName}.png"))
                .ForMember(x => x.Items, y => y.MapFrom(z => z.UserMatch.PlayerStatistics.FirstOrDefault(xx => xx.ParticipantId == z.ParticipantId).Items))
                .ForMember(x => x.WonMatch, y => y.MapFrom(z => z.UserMatch.PlayerStatistics.FirstOrDefault(xx => xx.ParticipantId == z.ParticipantId).WonMatch))
                .ForMember(x => x.WardsPlaced, y => y.MapFrom(z => z.UserMatch.PlayerStatistics.FirstOrDefault(xx => xx.ParticipantId == z.ParticipantId).WardsPlaced))
                .ForMember(x => x.WardsKilled, y => y.MapFrom(z => z.UserMatch.PlayerStatistics.FirstOrDefault(xx => xx.ParticipantId == z.ParticipantId).WardsKilled))
                .ForMember(x => x.VisionScore, y => y.MapFrom(z => z.UserMatch.PlayerStatistics.FirstOrDefault(xx => xx.ParticipantId == z.ParticipantId).VisionScore))
                .ForMember(x => x.TotalDamageDealtToChampions, y => y.MapFrom(z => z.UserMatch.PlayerStatistics.FirstOrDefault(xx => xx.ParticipantId == z.ParticipantId).TotalDamageDealtToChampions))
                .ForMember(x => x.TotalDamageDealt, y => y.MapFrom(z => z.UserMatch.PlayerStatistics.FirstOrDefault(xx => xx.ParticipantId == z.ParticipantId).TotalDamageDealt))
                .ForMember(x => x.TotalDamageTaken, y => y.MapFrom(z => z.UserMatch.PlayerStatistics.FirstOrDefault(xx => xx.ParticipantId == z.ParticipantId).TotalDamageTaken))
                .ForMember(x => x.TotalHeal, y => y.MapFrom(z => z.UserMatch.PlayerStatistics.FirstOrDefault(xx => xx.ParticipantId == z.ParticipantId).TotalHeal))
                .ForMember(x => x.Deaths, y => y.MapFrom(z => z.UserMatch.PlayerStatistics.FirstOrDefault(xx => xx.ParticipantId == z.ParticipantId).Deaths))
                .ForMember(x => x.Kills, y => y.MapFrom(z => z.UserMatch.PlayerStatistics.FirstOrDefault(xx => xx.ParticipantId == z.ParticipantId).Kills))
                .ForMember(x => x.Lane, y => y.MapFrom(z => z.UserMatch.PlayerStatistics.FirstOrDefault(xx => xx.ParticipantId == z.ParticipantId).Lane))
                .ForMember(x => x.Role, y => y.MapFrom(z => z.UserMatch.PlayerStatistics.FirstOrDefault(xx => xx.ParticipantId == z.ParticipantId).Role));

            CreateMap<MatchesPlayerItems, MatchItemsDTO>()
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.ItemName))
                .ForMember(dest => dest.ItemImageURL, opt => opt.MapFrom(src => $"https://ddragon.leagueoflegends.com/cdn/14.10.1/img/item/{src.ItemId}.png"));
        }
    }
}
