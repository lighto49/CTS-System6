using Microsoft.EntityFrameworkCore.Migrations;

namespace CTS_System6.Migrations
{
    public partial class cascadefix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
              name: "FK_UserRoles_Roles_RoleId",
              table: "UserRoles");

            migrationBuilder.AddForeignKey(
              name: "FK_UserRoles_Roles_RoleId",
              table: "UserRoles",
              column: "RoleId",
              principalTable: "Roles",
              principalColumn: "Id",
              onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
