using Microsoft.EntityFrameworkCore.Migrations;

namespace CTS_System6.Migrations
{
    public partial class TranslatorLanguages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "TranslatorsLanguages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TranslatorsLanguages");
        }
    }
}
