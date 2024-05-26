using LeagueOfDraven.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LeagueOfDraven.Data.Configuration.Matchs
{
    public class MatchesPlayerItemsConfiguration : IEntityTypeConfiguration<MatchesPlayerItems>
    {
        public void Configure(EntityTypeBuilder<MatchesPlayerItems> builder)
        {
            builder.ToTable("MATCHES_PLAYER_ITEMS").HasKey(x => x.MatchPlayerItemId);
        }
    }
}
