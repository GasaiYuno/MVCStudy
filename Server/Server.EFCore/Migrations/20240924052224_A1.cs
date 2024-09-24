using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.EFCore.Migrations
{
    public partial class A1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sys_user_info",
                columns: table => new
                {
                    _id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_name = table.Column<string>(type: "TEXT", nullable: false),
                    passwprd = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user_info", x => x._id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sys_user_info");
        }
    }
}
