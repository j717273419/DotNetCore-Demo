using Microsoft.EntityFrameworkCore.Migrations;

namespace aspnet_core_efcore_demo.Migrations
{
    public partial class testsqlite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleInfors",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    roleName = table.Column<string>(nullable: true),
                    roleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleInfors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfors",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    userName = table.Column<string>(nullable: true),
                    userSex = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfors", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleInfors");

            migrationBuilder.DropTable(
                name: "UserInfors");
        }
    }
}
