using LeagueOfDraven.Data.Configuration;
using LeagueOfDraven.Data.Configuration.Matchs;
using LeagueOfDraven.Models;
using LeagueOfDraven.Models.RIOT.Matchs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeagueOfDraven.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<IdentityUserClaim<string>> UserClaims { get; set; }
        public DbSet<IdentityUserRole<string>> UserRoles { get; set; }
        public DbSet<UserMatches> UserMatches { get; set; }
        public DbSet<MatchesChampions> MatchesChampions { get; set; }
        public DbSet<MatchesPlayerStatistics> MatchesPlayerStatistics { get; set; }
        public DbSet<MatchesPlayerItems> MatchesPlayerItems {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().ToTable("Roles").HasKey(r => r.Id);
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles").HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins").HasKey(ul => new { ul.LoginProvider, ul.ProviderKey });
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens").HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserMatchesConfiguration());
            modelBuilder.ApplyConfiguration(new MatchesChampionsConfiguration());
            modelBuilder.ApplyConfiguration(new MatchesPlayerStatisticsConfiguration());
            modelBuilder.ApplyConfiguration(new MatchesPlayerItemsConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
