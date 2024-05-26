using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LeagueOfDraven.Models.RIOT.Matchs;
using LeagueOfDraven.Models;

namespace LeagueOfDraven.Data.Configuration.Matchs
{
    public class MatchesPlayerStatisticsConfiguration : IEntityTypeConfiguration<MatchesPlayerStatistics>
    {
        public void Configure(EntityTypeBuilder<MatchesPlayerStatistics> builder)
        {
            builder.ToTable("MATCHES_PLAYER_STATISTICS").HasKey(x => new { x.UserMatchId, x.ParticipantId });
            builder.HasMany(x => x.Items).WithOne(x => x.PlayerStatistics).HasForeignKey(x => new { x.UserMatchId, x.ParticipantId }).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
