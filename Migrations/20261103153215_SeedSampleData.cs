using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Group1Blackboard.Migrations
{
    /// <inheritdoc />
    public partial class SeedSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "AppUserID", "DOB", "Email", "Name", "Role", "SSN" },
                values: new object[,]
                {
                    { 201, new DateTime(1980, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.smith@example.com", "John Smith", "Instructor", "000-00-0001" },
                    { 202, new DateTime(1985, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "mary.johnson@example.com", "Mary Johnson", "Instructor", "000-00-0002" },
                    { 203, new DateTime(1978, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "david.wilson@example.com", "David Wilson", "Instructor", "000-00-0003" },
                    { 204, new DateTime(1988, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.davis@example.com", "Emily Davis", "Instructor", "000-00-0004" }
                });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "MajorID", "College", "Name" },
                values: new object[,]
                {
                    { 101, "College of Business", "Business Administration" },
                    { 102, "College of Arts and Sciences", "Computer Science" },
                    { 103, "College of Education", "Elementary Education" },
                    { 104, "College of Health and Human Services", "Health Administration" },
                    { 105, "College of Business", "Information Systems" },
                    { 106, "College of Arts and Sciences", "Mathematics" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseID", "CourseName", "CourseNumber", "Credit", "InstructorID", "Location", "MajorID", "OfferedSemester", "ShortDescription", "Times" },
                values: new object[,]
                {
                    { 301, "Business Foundations", "BADM5000", 3, 201, "In-person", 101, "Fall", "Introduction to business management.", "Monday 6:00 PM" },
                    { 302, "Organizational Behavior", "BADM5400", 3, 202, "Online", 101, "Spring", "Study of behavior in organizations.", "Online" },
                    { 303, "Strategic Management", "BADM6000", 3, 203, "Hybrid", 101, "Fall", "Business strategy and planning.", "Wednesday 6:00 PM" },
                    { 304, "Programming Concepts", "CSPC6100", 3, 201, "In-person", 102, "Spring", "Introduction to programming concepts.", "Tuesday 5:00 PM" },
                    { 305, "Database Systems", "CSPC7300", 3, 202, "Online", 102, "Fall", "Database design and management.", "Online" },
                    { 306, "Internet Programming", "CSPC7550", 3, 203, "Hybrid", 102, "Fall", "Development of web applications.", "Thursday 6:00 PM" },
                    { 307, "Information Security", "CSPC8720", 3, 204, "Online", 102, "Spring", "Principles of information security.", "Online" },
                    { 308, "Foundations of Education", "EDUC5100", 3, 201, "In-person", 103, "Fall", "Introduction to educational practice.", "Monday 4:00 PM" },
                    { 309, "Healthcare Administration", "HLTH5200", 3, 202, "Hybrid", 104, "Spring", "Healthcare organization and management.", "Tuesday 6:00 PM" },
                    { 310, "Information Systems", "INFS6200", 3, 203, "Online", 105, "Fall", "Fundamentals of information systems.", "Online" },
                    { 311, "Systems Analysis", "INFS6400", 3, 204, "In-person", 105, "Spring", "Analysis and design of information systems.", "Wednesday 5:00 PM" },
                    { 312, "Data Management", "INFS7100", 3, 201, "Hybrid", 105, "Fall", "Managing organizational data.", "Thursday 5:00 PM" },
                    { 313, "Applied Mathematics", "MATH5100", 3, 202, "In-person", 106, "Spring", "Mathematical methods and applications.", "Monday 5:00 PM" },
                    { 314, "Statistics", "MATH5200", 3, 203, "Online", 106, "Fall", "Statistical methods and analysis.", "Online" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "AppUserID",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "AppUserID",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "AppUserID",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "AppUserID",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorID",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorID",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorID",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorID",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorID",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "MajorID",
                keyValue: 106);
        }
    }
}
