using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CTS_System6.Migrations
{
    public partial class seedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] {"Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "Admin", "admin".ToUpper(), Guid.NewGuid().ToString()}
                );
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "Translator", "Translator".ToUpper(), Guid.NewGuid().ToString() }
                );
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "Customer", "Customer".ToUpper(), Guid.NewGuid().ToString() }
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from table [Roles]");
        }
    }
}
