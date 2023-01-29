using Microsoft.EntityFrameworkCore.Migrations;

namespace CTS_System6.Migrations
{
    public partial class cascadefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Languages_ToLanguage",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslatorsLanguages_Languages_ToLanguage",
                table: "TranslatorsLanguages");

            migrationBuilder.RenameColumn(
                name: "ToLanguage",
                table: "TranslatorsLanguages",
                newName: "ToLanguageId");

            migrationBuilder.RenameColumn(
                name: "FromLanguage",
                table: "TranslatorsLanguages",
                newName: "FromLanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_TranslatorsLanguages_ToLanguage",
                table: "TranslatorsLanguages",
                newName: "IX_TranslatorsLanguages_ToLanguageId");

            migrationBuilder.RenameColumn(
                name: "ToLanguage",
                table: "Projects",
                newName: "ToLanguageId");

            migrationBuilder.RenameColumn(
                name: "FromLanguage",
                table: "Projects",
                newName: "FromLanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ToLanguage",
                table: "Projects",
                newName: "IX_Projects_ToLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslatorsLanguages_FromLanguageId",
                table: "TranslatorsLanguages",
                column: "FromLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_FromLanguageId",
                table: "Projects",
                column: "FromLanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Languages_FromLanguageId",
                table: "Projects",
                column: "FromLanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Languages_ToLanguageId",
                table: "Projects",
                column: "ToLanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatorsLanguages_Languages_FromLanguageId",
                table: "TranslatorsLanguages",
                column: "FromLanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatorsLanguages_Languages_ToLanguageId",
                table: "TranslatorsLanguages",
                column: "ToLanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Languages_FromLanguageId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Languages_ToLanguageId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslatorsLanguages_Languages_FromLanguageId",
                table: "TranslatorsLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslatorsLanguages_Languages_ToLanguageId",
                table: "TranslatorsLanguages");

            migrationBuilder.DropIndex(
                name: "IX_TranslatorsLanguages_FromLanguageId",
                table: "TranslatorsLanguages");

            migrationBuilder.DropIndex(
                name: "IX_Projects_FromLanguageId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ToLanguageId",
                table: "TranslatorsLanguages",
                newName: "ToLanguage");

            migrationBuilder.RenameColumn(
                name: "FromLanguageId",
                table: "TranslatorsLanguages",
                newName: "FromLanguage");

            migrationBuilder.RenameIndex(
                name: "IX_TranslatorsLanguages_ToLanguageId",
                table: "TranslatorsLanguages",
                newName: "IX_TranslatorsLanguages_ToLanguage");

            migrationBuilder.RenameColumn(
                name: "ToLanguageId",
                table: "Projects",
                newName: "ToLanguage");

            migrationBuilder.RenameColumn(
                name: "FromLanguageId",
                table: "Projects",
                newName: "FromLanguage");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ToLanguageId",
                table: "Projects",
                newName: "IX_Projects_ToLanguage");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Languages_ToLanguage",
                table: "Projects",
                column: "ToLanguage",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatorsLanguages_Languages_ToLanguage",
                table: "TranslatorsLanguages",
                column: "ToLanguage",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
