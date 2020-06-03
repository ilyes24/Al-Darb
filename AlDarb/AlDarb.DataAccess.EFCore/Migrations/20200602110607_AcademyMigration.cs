using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlDarb.DataAccess.EFCore.Migrations
{
    public partial class AcademyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                schema: "starter_core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "starter_core",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                schema: "starter_core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    RedirectUrl = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "starter_core",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseSessions",
                schema: "starter_core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Capacity = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSessions_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "starter_core",
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseTasks",
                schema: "starter_core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Duration = table.Column<string>(nullable: false),
                    Difficulty = table.Column<string>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseTasks_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "starter_core",
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicationForSessions",
                schema: "starter_core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    ApplicationDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: true),
                    AcceptedDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    CourseSessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationForSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationForSessions_CourseSessions_CourseSessionId",
                        column: x => x.CourseSessionId,
                        principalSchema: "starter_core",
                        principalTable: "CourseSessions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationForSessions_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "starter_core",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProgressTasks",
                schema: "starter_core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    progress = table.Column<string>(nullable: false),
                    ProgressDate = table.Column<DateTime>(nullable: false),
                    rating = table.Column<int>(nullable: true),
                    CourseTaskId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgressTasks_CourseTasks_CourseTaskId",
                        column: x => x.CourseTaskId,
                        principalSchema: "starter_core",
                        principalTable: "CourseTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgressTasks_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "starter_core",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationForSessions_CourseSessionId",
                schema: "starter_core",
                table: "ApplicationForSessions",
                column: "CourseSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationForSessions_UserId",
                schema: "starter_core",
                table: "ApplicationForSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UserId",
                schema: "starter_core",
                table: "Courses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSessions_CourseId",
                schema: "starter_core",
                table: "CourseSessions",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTasks_CourseId",
                schema: "starter_core",
                table: "CourseTasks",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                schema: "starter_core",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressTasks_CourseTaskId",
                schema: "starter_core",
                table: "ProgressTasks",
                column: "CourseTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressTasks_UserId",
                schema: "starter_core",
                table: "ProgressTasks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationForSessions",
                schema: "starter_core");

            migrationBuilder.DropTable(
                name: "Notifications",
                schema: "starter_core");

            migrationBuilder.DropTable(
                name: "ProgressTasks",
                schema: "starter_core");

            migrationBuilder.DropTable(
                name: "CourseSessions",
                schema: "starter_core");

            migrationBuilder.DropTable(
                name: "CourseTasks",
                schema: "starter_core");

            migrationBuilder.DropTable(
                name: "Courses",
                schema: "starter_core");
        }
    }
}
