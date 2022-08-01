using Microsoft.EntityFrameworkCore.Migrations;

namespace CTS_System6.Migrations
{
    public partial class addAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into  [UserRoles] (UserId, RoleId) values ('f7ae75aa-6cf9-49de-8b9d-895985933b12', 'a16ddd03-6695-459f-b512-d3db403c78dc')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from [UserRoles] where userid = 'f7ae75aa-6cf9-49de-8b9d-895985933b12'");
        }
    }
}
