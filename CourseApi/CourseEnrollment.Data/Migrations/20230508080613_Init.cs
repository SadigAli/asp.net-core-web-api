using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseEnrollment.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credit = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "Credit", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6534), 20, null, "Front End", new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6535) },
                    { 2, new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6536), 30, null, "Back End", new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6537) },
                    { 3, new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6538), 45, null, "Full Stack", new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6539) },
                    { 4, new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6540), 25, null, "Mobile Programming", new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6540) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Firstname", "Lastname", "StudentId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6645), null, "Sadig", "Aliyev", "STD001", new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6645) },
                    { 2, new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6647), null, "Rovshane", "Rzayeva", "STD002", new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6647) },
                    { 3, new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6648), null, "Aysel", "Hasanli", "STD003", new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6648) }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "CreatedAt", "DeletedAt", "StudentId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6690), null, 1, new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6690) },
                    { 2, 2, new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6691), null, 1, new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6691) },
                    { 3, 3, new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6692), null, 1, new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6692) },
                    { 4, 2, new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6693), null, 2, new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6693) },
                    { 5, 4, new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6694), null, 2, new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6694) },
                    { 6, 1, new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6695), null, 3, new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6695) },
                    { 7, 4, new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6695), null, 3, new DateTime(2023, 5, 8, 12, 6, 13, 424, DateTimeKind.Local).AddTicks(6696) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
