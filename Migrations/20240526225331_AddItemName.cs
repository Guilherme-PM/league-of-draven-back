using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeagueOfDraven.Migrations
{
    /// <inheritdoc />
    public partial class AddItemName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "MATCHES_PLAYER_ITEMS",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "MATCHES_PLAYER_ITEMS");
        }
    }
}
