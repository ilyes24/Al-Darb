using Microsoft.EntityFrameworkCore.Migrations;

namespace AlDarb.DataAccess.EFCore.Migrations
{
    public partial class TaskAddons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Plan",
                schema: "starter_core",
                table: "CourseTasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "starter_core",
                table: "CourseTasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plan",
                schema: "starter_core",
                table: "CourseTasks");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "starter_core",
                table: "CourseTasks");
        }
    }
}
