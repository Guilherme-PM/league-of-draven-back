using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeagueOfDraven.Migrations
{
    /// <inheritdoc />
    public partial class AddMatchTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USER_MATCHES",
                columns: table => new
                {
                    UserMatchId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Puuid = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MatchDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MatchDuration = table.Column<TimeSpan>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_MATCHES", x => x.UserMatchId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MATCHES_CHAMPIONS",
                columns: table => new
                {
                    UserMatchId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParticipantId = table.Column<long>(type: "bigint", nullable: false),
                    ChampionName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Puuid = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATCHES_CHAMPIONS", x => new { x.UserMatchId, x.ParticipantId });
                    table.ForeignKey(
                        name: "FK_MATCHES_CHAMPIONS_USER_MATCHES_UserMatchId",
                        column: x => x.UserMatchId,
                        principalTable: "USER_MATCHES",
                        principalColumn: "UserMatchId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MATCHES_PLAYER_STATISTICS",
                columns: table => new
                {
                    UserMatchId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParticipantId = table.Column<long>(type: "bigint", nullable: false),
                    Puuid = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Farm = table.Column<int>(type: "int", nullable: false),
                    WonMatch = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    WonLane = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATCHES_PLAYER_STATISTICS", x => new { x.UserMatchId, x.ParticipantId });
                    table.ForeignKey(
                        name: "FK_MATCHES_PLAYER_STATISTICS_USER_MATCHES_UserMatchId",
                        column: x => x.UserMatchId,
                        principalTable: "USER_MATCHES",
                        principalColumn: "UserMatchId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MATCHES_PLAYER_ITEMS",
                columns: table => new
                {
                    MatchPlayerItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserMatchId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParticipantId = table.Column<long>(type: "bigint", nullable: false),
                    ItemName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATCHES_PLAYER_ITEMS", x => x.MatchPlayerItemId);
                    table.ForeignKey(
                        name: "FK_MATCHES_PLAYER_ITEMS_MATCHES_PLAYER_STATISTICS_UserMatchId_P~",
                        columns: x => new { x.UserMatchId, x.ParticipantId },
                        principalTable: "MATCHES_PLAYER_STATISTICS",
                        principalColumns: new[] { "UserMatchId", "ParticipantId" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MATCHES_PLAYER_ITEMS_UserMatchId_ParticipantId",
                table: "MATCHES_PLAYER_ITEMS",
                columns: new[] { "UserMatchId", "ParticipantId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MATCHES_CHAMPIONS");

            migrationBuilder.DropTable(
                name: "MATCHES_PLAYER_ITEMS");

            migrationBuilder.DropTable(
                name: "MATCHES_PLAYER_STATISTICS");

            migrationBuilder.DropTable(
                name: "USER_MATCHES");
        }
    }
}
