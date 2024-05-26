using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LeagueOfDraven.Models.RIOT.Matchs;
using LeagueOfDraven.Models;

namespace LeagueOfDraven.Data.Configuration.Matchs
{
    public class MatchesChampionsConfiguration : IEntityTypeConfiguration<MatchesChampions>
    {
        public void Configure(EntityTypeBuilder<MatchesChampions> builder)
        {
            builder.ToTable("MATCHES_CHAMPIONS").HasKey(x => new { x.UserMatchId, x.ParticipantId }); ;
        }
    }
}
