using Microsoft.EntityFrameworkCore.Migrations;

namespace AlDarb.DataAccess.EFCore.Migrations
{
    public partial class SessionTaskDateRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SessionTaskDates_SessionId",
                schema: "starter_core",
                table: "SessionTaskDates",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionTaskDates_TaskId",
                schema: "starter_core",
                table: "SessionTaskDates",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionTaskDates_CourseSessions_SessionId",
                schema: "starter_core",
                table: "SessionTaskDates",
                column: "SessionId",
                principalSchema: "starter_core",
                principalTable: "CourseSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionTaskDates_CourseTasks_TaskId",
                schema: "starter_core",
                table: "SessionTaskDates",
                column: "TaskId",
                principalSchema: "starter_core",
                principalTable: "CourseTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionTaskDates_CourseSessions_SessionId",
                schema: "starter_core",
                table: "SessionTaskDates");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionTaskDates_CourseTasks_TaskId",
                schema: "starter_core",
                table: "SessionTaskDates");

            migrationBuilder.DropIndex(
                name: "IX_SessionTaskDates_SessionId",
                schema: "starter_core",
                table: "SessionTaskDates");

            migrationBuilder.DropIndex(
                name: "IX_SessionTaskDates_TaskId",
                schema: "starter_core",
                table: "SessionTaskDates");
        }
    }
}
