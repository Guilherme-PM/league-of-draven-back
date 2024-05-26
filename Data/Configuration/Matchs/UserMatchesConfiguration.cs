using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LeagueOfDraven.Models;

namespace LeagueOfDraven.Data.Configuration.Matchs
{
    public class UserMatchesConfiguration : IEntityTypeConfiguration<UserMatches>
    {
        public void Configure(EntityTypeBuilder<UserMatches> builder)
        {
            builder.ToTable("USER_MATCHES").HasKey(x => x.UserMatchId);
            builder.HasMany(x => x.Champions).WithOne(x => x.UserMatch).HasForeignKey(x => x.UserMatchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.PlayerStatistics).WithOne(x => x.UserMatch).HasForeignKey(x => x.UserMatchId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
