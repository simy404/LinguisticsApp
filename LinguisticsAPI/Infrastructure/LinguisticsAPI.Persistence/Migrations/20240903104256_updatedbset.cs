using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinguisticsAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatedbset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTranslations_Articles_ArticleId",
                table: "ArticleTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTranslations_Languages_LanguageId",
                table: "ArticleTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsTranslation_Languages_LanguageId",
                table: "NewsTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsTranslation_News_NewsId",
                table: "NewsTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsTranslation",
                table: "NewsTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleTranslations",
                table: "ArticleTranslations");

            migrationBuilder.RenameTable(
                name: "NewsTranslation",
                newName: "NewsTranslations");

            migrationBuilder.RenameTable(
                name: "ArticleTranslations",
                newName: "ArticleTranslation");

            migrationBuilder.RenameIndex(
                name: "IX_NewsTranslation_NewsId",
                table: "NewsTranslations",
                newName: "IX_NewsTranslations_NewsId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsTranslation_LanguageId",
                table: "NewsTranslations",
                newName: "IX_NewsTranslations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleTranslations_LanguageId",
                table: "ArticleTranslation",
                newName: "IX_ArticleTranslation_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleTranslations_ArticleId",
                table: "ArticleTranslation",
                newName: "IX_ArticleTranslation_ArticleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsTranslations",
                table: "NewsTranslations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleTranslation",
                table: "ArticleTranslation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTranslation_Articles_ArticleId",
                table: "ArticleTranslation",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTranslation_Languages_LanguageId",
                table: "ArticleTranslation",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsTranslations_Languages_LanguageId",
                table: "NewsTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsTranslations_News_NewsId",
                table: "NewsTranslations",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTranslation_Articles_ArticleId",
                table: "ArticleTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTranslation_Languages_LanguageId",
                table: "ArticleTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsTranslations_Languages_LanguageId",
                table: "NewsTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsTranslations_News_NewsId",
                table: "NewsTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsTranslations",
                table: "NewsTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleTranslation",
                table: "ArticleTranslation");

            migrationBuilder.RenameTable(
                name: "NewsTranslations",
                newName: "NewsTranslation");

            migrationBuilder.RenameTable(
                name: "ArticleTranslation",
                newName: "ArticleTranslations");

            migrationBuilder.RenameIndex(
                name: "IX_NewsTranslations_NewsId",
                table: "NewsTranslation",
                newName: "IX_NewsTranslation_NewsId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsTranslations_LanguageId",
                table: "NewsTranslation",
                newName: "IX_NewsTranslation_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleTranslation_LanguageId",
                table: "ArticleTranslations",
                newName: "IX_ArticleTranslations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleTranslation_ArticleId",
                table: "ArticleTranslations",
                newName: "IX_ArticleTranslations_ArticleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsTranslation",
                table: "NewsTranslation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleTranslations",
                table: "ArticleTranslations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTranslations_Articles_ArticleId",
                table: "ArticleTranslations",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTranslations_Languages_LanguageId",
                table: "ArticleTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsTranslation_Languages_LanguageId",
                table: "NewsTranslation",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsTranslation_News_NewsId",
                table: "NewsTranslation",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
