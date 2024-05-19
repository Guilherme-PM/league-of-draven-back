using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeagueOfDraven.Migrations
{
    /// <inheritdoc />
    public partial class Descrição : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "USER",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "USER",
                newName: "SecurityStamp");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "USER",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "USER",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "USER",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "USER",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "USER",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "USER",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "USER",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "USER",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "USER",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "USER",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "USER",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "USER",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "USER",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "USER");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "USER",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "SecurityStamp",
                table: "USER",
                newName: "Password");
        }
    }
}
