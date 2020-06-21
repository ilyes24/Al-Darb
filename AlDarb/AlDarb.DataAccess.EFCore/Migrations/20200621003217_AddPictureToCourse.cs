using Microsoft.EntityFrameworkCore.Migrations;

namespace AlDarb.DataAccess.EFCore.Migrations
{
    public partial class AddPictureToCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                schema: "starter_core",
                table: "Courses",
                nullable: true,
                defaultValue: "https://e-student.org/wp-content/uploads/2019/01/creating-an-online-course-outline-1024x539.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                schema: "starter_core",
                table: "Courses");
        }
    }
}
