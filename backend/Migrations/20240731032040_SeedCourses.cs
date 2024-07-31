using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Course 1" },
                    { 2, "Course 2" },
                    { 3, "Course 3" },
                    { 4, "Course 4" },
                    { 5, "Course 5" },
                    { 6, "Course 6" }
                });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Id", "Name", "Year" },
                values: new object[,]
                {
                    { 1, "Sem 1 2021", 2021 },
                    { 2, "Sem 2 2021", 2021 },
                    { 3, "Sem 1 2022", 2022 }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "CourseId", "DueDate", "MaxScore", "Name", "Score", "Weighting" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Assignment 1", 0, 0 },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Assignment 2", 0, 0 },
                    { 3, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Assignment 3", 0, 0 },
                    { 4, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Assignment 4", 0, 0 },
                    { 5, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Assignment 5", 0, 0 },
                    { 6, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Assignment 6", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "CourseSemester",
                columns: new[] { "CoursesId", "SemestersId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CourseSemester",
                keyColumns: new[] { "CoursesId", "SemestersId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CourseSemester",
                keyColumns: new[] { "CoursesId", "SemestersId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CourseSemester",
                keyColumns: new[] { "CoursesId", "SemestersId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CourseSemester",
                keyColumns: new[] { "CoursesId", "SemestersId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "CourseSemester",
                keyColumns: new[] { "CoursesId", "SemestersId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "CourseSemester",
                keyColumns: new[] { "CoursesId", "SemestersId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
