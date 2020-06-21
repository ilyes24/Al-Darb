using Microsoft.EntityFrameworkCore.Migrations;

namespace AlDarb.DataAccess.EFCore.Migrations
{
    public partial class PhotoDefaultValueToNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                schema: "starter_core",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "https://cdn.icon-icons.com/icons2/1378/PNG/512/avatardefault_92824.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                schema: "starter_core",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "https://cdn.icon-icons.com/icons2/1378/PNG/512/avatardefault_92824.png",
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
