using Microsoft.EntityFrameworkCore.Migrations;

namespace AlDarb.DataAccess.EFCore.Migrations
{
    public partial class AddFieldEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvgRating",
                schema: "starter_core",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FieldId",
                schema: "starter_core",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SumRating",
                schema: "starter_core",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CourseRatings",
                schema: "starter_core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Rating = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    CourseId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseRatings_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "starter_core",
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseRatings_Courses_CourseId1",
                        column: x => x.CourseId1,
                        principalSchema: "starter_core",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseRatings_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "starter_core",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                schema: "starter_core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_FieldId",
                schema: "starter_core",
                table: "Courses",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRatings_CourseId",
                schema: "starter_core",
                table: "CourseRatings",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRatings_CourseId1",
                schema: "starter_core",
                table: "CourseRatings",
                column: "CourseId1");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRatings_UserId",
                schema: "starter_core",
                table: "CourseRatings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Fields_FieldId",
                schema: "starter_core",
                table: "Courses",
                column: "FieldId",
                principalSchema: "starter_core",
                principalTable: "Fields",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Fields_FieldId",
                schema: "starter_core",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "CourseRatings",
                schema: "starter_core");

            migrationBuilder.DropTable(
                name: "Fields",
                schema: "starter_core");

            migrationBuilder.DropIndex(
                name: "IX_Courses_FieldId",
                schema: "starter_core",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "AvgRating",
                schema: "starter_core",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "FieldId",
                schema: "starter_core",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "SumRating",
                schema: "starter_core",
                table: "Courses");
        }
    }
}
