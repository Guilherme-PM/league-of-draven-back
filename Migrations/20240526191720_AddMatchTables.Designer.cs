﻿// <auto-generated />
using System;
using LeagueOfDraven.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LeagueOfDraven.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240526191720_AddMatchTables")]
    partial class AddMatchTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LeagueOfDraven.Models.MatchesChampions", b =>
                {
                    b.Property<string>("UserMatchId")
                        .HasColumnType("varchar(255)");

                    b.Property<long>("ParticipantId")
                        .HasColumnType("bigint");

                    b.Property<string>("ChampionName")
                        .HasColumnType("longtext");

                    b.Property<string>("Puuid")
                        .HasColumnType("longtext");

                    b.HasKey("UserMatchId", "ParticipantId");

                    b.ToTable("MATCHES_CHAMPIONS", (string)null);
                });

            modelBuilder.Entity("LeagueOfDraven.Models.MatchesPlayerItems", b =>
                {
                    b.Property<int>("MatchPlayerItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .HasColumnType("longtext");

                    b.Property<long>("ParticipantId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserMatchId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("MatchPlayerItemId");

                    b.HasIndex("UserMatchId", "ParticipantId");

                    b.ToTable("MATCHES_PLAYER_ITEMS", (string)null);
                });

            modelBuilder.Entity("LeagueOfDraven.Models.MatchesPlayerStatistics", b =>
                {
                    b.Property<string>("UserMatchId")
                        .HasColumnType("varchar(255)");

                    b.Property<long>("ParticipantId")
                        .HasColumnType("bigint");

                    b.Property<int>("Farm")
                        .HasColumnType("int");

                    b.Property<string>("Puuid")
                        .HasColumnType("longtext");

                    b.Property<bool>("WonLane")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("WonMatch")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("UserMatchId", "ParticipantId");

                    b.ToTable("MATCHES_PLAYER_STATISTICS", (string)null);
                });

            modelBuilder.Entity("LeagueOfDraven.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Id")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("longtext");

                    b.Property<string>("PUUID")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ProfileId")
                        .HasColumnType("longtext");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("USER", (string)null);
                });

            modelBuilder.Entity("LeagueOfDraven.Models.UserMatches", b =>
                {
                    b.Property<string>("UserMatchId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("datetime(6)");

                    b.Property<TimeSpan>("MatchDuration")
                        .HasColumnType("time(6)");

                    b.Property<string>("Puuid")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("UserMatchId");

                    b.ToTable("USER_MATCHES", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("longtext");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", (string)null);
                });

            modelBuilder.Entity("LeagueOfDraven.Models.MatchesChampions", b =>
                {
                    b.HasOne("LeagueOfDraven.Models.UserMatches", "UserMatch")
                        .WithMany("Champions")
                        .HasForeignKey("UserMatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserMatch");
                });

            modelBuilder.Entity("LeagueOfDraven.Models.MatchesPlayerItems", b =>
                {
                    b.HasOne("LeagueOfDraven.Models.MatchesPlayerStatistics", "PlayerStatistics")
                        .WithMany("Items")
                        .HasForeignKey("UserMatchId", "ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("PlayerStatistics");
                });

            modelBuilder.Entity("LeagueOfDraven.Models.MatchesPlayerStatistics", b =>
                {
                    b.HasOne("LeagueOfDraven.Models.UserMatches", "UserMatch")
                        .WithMany("PlayerStatistics")
                        .HasForeignKey("UserMatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserMatch");
                });

            modelBuilder.Entity("LeagueOfDraven.Models.MatchesPlayerStatistics", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("LeagueOfDraven.Models.UserMatches", b =>
                {
                    b.Navigation("Champions");

                    b.Navigation("PlayerStatistics");
                });
#pragma warning restore 612, 618
        }
    }
}
