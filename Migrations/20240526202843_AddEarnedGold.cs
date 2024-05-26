using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeagueOfDraven.Migrations
{
    /// <inheritdoc />
    public partial class AddEarnedGold : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoldEarned",
                table: "MATCHES_PLAYER_STATISTICS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoldSpent",
                table: "MATCHES_PLAYER_STATISTICS",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoldEarned",
                table: "MATCHES_PLAYER_STATISTICS");

            migrationBuilder.DropColumn(
                name: "GoldSpent",
                table: "MATCHES_PLAYER_STATISTICS");
        }
    }
}
