using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.EFCore.Migrations
{
    public partial class a3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_id",
                table: "sys_user_info",
                newName: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "sys_user_info",
                newName: "_id");
        }
    }
}
