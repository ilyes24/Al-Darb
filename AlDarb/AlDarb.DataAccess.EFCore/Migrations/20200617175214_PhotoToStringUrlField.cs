using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlDarb.DataAccess.EFCore.Migrations
{
    public partial class PhotoToStringUrlField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgressTasks_CourseTasks_CourseTaskId",
                schema: "starter_core",
                table: "ProgressTasks");

            migrationBuilder.DropTable(
                name: "UserPhotos",
                schema: "starter_core");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                schema: "starter_core",
                table: "Users",
                nullable: true,
                defaultValue: "https://cdn.icon-icons.com/icons2/1378/PNG/512/avatardefault_92824.png");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressTasks_CourseTasks_CourseTaskId",
                schema: "starter_core",
                table: "ProgressTasks",
                column: "CourseTaskId",
                principalSchema: "starter_core",
                principalTable: "CourseTasks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgressTasks_CourseTasks_CourseTaskId",
                schema: "starter_core",
                table: "ProgressTasks");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                schema: "starter_core",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "UserPhotos",
                schema: "starter_core",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPhotos_Users_Id",
                        column: x => x.Id,
                        principalSchema: "starter_core",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressTasks_CourseTasks_CourseTaskId",
                schema: "starter_core",
                table: "ProgressTasks",
                column: "CourseTaskId",
                principalSchema: "starter_core",
                principalTable: "CourseTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
