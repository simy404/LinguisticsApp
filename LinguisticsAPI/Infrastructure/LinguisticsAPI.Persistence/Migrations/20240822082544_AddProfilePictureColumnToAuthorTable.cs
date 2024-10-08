﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinguisticsAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddProfilePictureColumnToAuthorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Authors");
        }
    }
}
