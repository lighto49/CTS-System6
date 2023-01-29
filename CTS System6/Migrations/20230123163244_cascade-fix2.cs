using Microsoft.EntityFrameworkCore.Migrations;

namespace CTS_System6.Migrations
{
    public partial class cascadefix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
              name: "FK_Rate_Projects_ProjectId",
              table: "Rate");

            migrationBuilder.AddForeignKey(
              name: "FK_Rate_Projects_ProjectId",
              table: "Rate",
              column: "ProjectId",
              principalTable: "Projects",
              principalColumn: "Id",
              onDelete: ReferentialAction.Restrict);

            migrationBuilder.DropForeignKey(
              name: "FK_Bids_Projects_ProjectId",
              table: "Bids");

            migrationBuilder.AddForeignKey(
              name: "FK_Bids_Projects_ProjectId",
              table: "Bids",
              column: "ProjectId",
              principalTable: "Projects",
              principalColumn: "Id",
              onDelete: ReferentialAction.Restrict);

            migrationBuilder.DropForeignKey(
              name: "FK_Bids_Projects_ProjectId",
              table: "Bids");

            migrationBuilder.AddForeignKey(
              name: "FK_Bids_Projects_ProjectId",
              table: "Bids",
              column: "ProjectId",
              principalTable: "Projects",
              principalColumn: "Id",
              onDelete: ReferentialAction.Restrict);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
