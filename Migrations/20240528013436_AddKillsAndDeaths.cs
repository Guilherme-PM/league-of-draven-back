using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeagueOfDraven.Migrations
{
    /// <inheritdoc />
    public partial class AddKillsAndDeaths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WonMatch",
                table: "MATCHES_PLAYER_STATISTICS");

            migrationBuilder.AddColumn<int>(
                name: "Deaths",
                table: "MATCHES_PLAYER_STATISTICS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Kills",
                table: "MATCHES_PLAYER_STATISTICS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Lane",
                table: "MATCHES_PLAYER_STATISTICS",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "MATCHES_PLAYER_STATISTICS",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "TotalDamageDealt",
                table: "MATCHES_PLAYER_STATISTICS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalDamageDealtToChampions",
                table: "MATCHES_PLAYER_STATISTICS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalDamageTaken",
                table: "MATCHES_PLAYER_STATISTICS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalHeal",
                table: "MATCHES_PLAYER_STATISTICS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VisionScore",
                table: "MATCHES_PLAYER_STATISTICS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WardsKilled",
                table: "MATCHES_PLAYER_STATISTICS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WardsPlaced",
                table: "MATCHES_PLAYER_STATISTICS",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deaths",
                table: "MATCHES_PLAYER_STATISTICS");

            migrationBuilder.DropColumn(
                name: "Kills",
                table: "MATCHES_PLAYER_STATISTICS");

            migrationBuilder.DropColumn(
                name: "Lane",
                table: "MATCHES_PLAYER_STATISTICS");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "MATCHES_PLAYER_STATISTICS");

            migrationBuilder.DropColumn(
                name: "TotalDamageDealt",
                table: "MATCHES_PLAYER_STATISTICS");

            migrationBuilder.DropColumn(
                name: "TotalDamageDealtToChampions",
                table: "MATCHES_PLAYER_STATISTICS");

            migrationBuilder.DropColumn(
                name: "TotalDamageTaken",
                table: "MATCHES_PLAYER_STATISTICS");

            migrationBuilder.DropColumn(
                name: "TotalHeal",
                table: "MATCHES_PLAYER_STATISTICS");

            migrationBuilder.DropColumn(
                name: "VisionScore",
                table: "MATCHES_PLAYER_STATISTICS");

            migrationBuilder.DropColumn(
                name: "WardsKilled",
                table: "MATCHES_PLAYER_STATISTICS");

            migrationBuilder.DropColumn(
                name: "WardsPlaced",
                table: "MATCHES_PLAYER_STATISTICS");

            migrationBuilder.AddColumn<bool>(
                name: "WonMatch",
                table: "MATCHES_PLAYER_STATISTICS",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
