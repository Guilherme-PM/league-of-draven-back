using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeagueOfDraven.Migrations
{
    /// <inheritdoc />
    public partial class AddGameModeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GameMode",
                table: "USER_MATCHES",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameMode",
                table: "USER_MATCHES");
        }
    }
}
