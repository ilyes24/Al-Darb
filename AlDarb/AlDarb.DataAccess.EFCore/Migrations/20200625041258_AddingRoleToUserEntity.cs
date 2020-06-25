using Microsoft.EntityFrameworkCore.Migrations;

namespace AlDarb.DataAccess.EFCore.Migrations
{
    public partial class AddingRoleToUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "role",
                schema: "starter_core",
                table: "Users",
                nullable: true,
                defaultValue: "user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                schema: "starter_core",
                table: "Users");
        }
    }
}
