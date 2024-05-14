using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using LeagueOfDraven.Models;

namespace LeagueOfDraven.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USER");
            builder.HasKey(x => x.UserId);
            //builder.HasData(new User()
            //{
            //    UserId = 1,
            //    Username = "Master",
            //    Password = 
            //});
        }
    }
}
