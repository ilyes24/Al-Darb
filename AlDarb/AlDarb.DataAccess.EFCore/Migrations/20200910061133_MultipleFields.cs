using Microsoft.EntityFrameworkCore.Migrations;

namespace AlDarb.DataAccess.EFCore.Migrations
{
    public partial class MultipleFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Fields_FieldId",
                schema: "starter_core",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_FieldId",
                schema: "starter_core",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "FieldId",
                schema: "starter_core",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "CourseFields",
                schema: "starter_core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CourseId = table.Column<int>(nullable: false),
                    FieldId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseFields_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "starter_core",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseFields_Fields_FieldId",
                        column: x => x.FieldId,
                        principalSchema: "starter_core",
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonationPostFields",
                schema: "starter_core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DonationPostId = table.Column<int>(nullable: false),
                    FieldId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationPostFields", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseFields_CourseId",
                schema: "starter_core",
                table: "CourseFields",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseFields_FieldId",
                schema: "starter_core",
                table: "CourseFields",
                column: "FieldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseFields",
                schema: "starter_core");

            migrationBuilder.DropTable(
                name: "DonationPostFields",
                schema: "starter_core");

            migrationBuilder.AddColumn<int>(
                name: "FieldId",
                schema: "starter_core",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_FieldId",
                schema: "starter_core",
                table: "Courses",
                column: "FieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Fields_FieldId",
                schema: "starter_core",
                table: "Courses",
                column: "FieldId",
                principalSchema: "starter_core",
                principalTable: "Fields",
                principalColumn: "Id");
        }
    }
}
