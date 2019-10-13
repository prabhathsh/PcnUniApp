using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PcnUniApp.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "Course_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Department_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Instructor_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "semester_year_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Student_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SemesterCourse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterOfferedCourse_SemesterYearId = table.Column<int>(nullable: true),
                    SemesterOfferedCourse_CourseId = table.Column<int>(nullable: true),
                    SemesterOfferedCourse_DeprtmentId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    NumberOfCredits = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterCourse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SemesterYear",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    SemesterName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterYear", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentEnrollment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    SemesterYearId = table.Column<int>(nullable: false),
                    EnrolledDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEnrollment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    InstructorNumber = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 25, nullable: false),
                    LastName = table.Column<string>(maxLength: 25, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 25, nullable: true),
                    Email = table.Column<string>(maxLength: 25, nullable: false),
                    OfficeLocation = table.Column<string>(maxLength: 50, nullable: true),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructor_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    StudentNumber = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 25, nullable: false),
                    LastName = table.Column<string>(maxLength: 25, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 25, nullable: true),
                    Email = table.Column<string>(maxLength: 25, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseSection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(nullable: false),
                    AvailableSeats = table.Column<int>(nullable: false),
                    SemesterCourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSection_SemesterCourse_SemesterCourseId",
                        column: x => x.SemesterCourseId,
                        principalTable: "SemesterCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentSection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(nullable: false),
                    SemesterCourseId = table.Column<int>(nullable: false),
                    SectionId = table.Column<int>(nullable: false),
                    NumberOfCredits = table.Column<int>(nullable: false),
                    Grade = table.Column<string>(nullable: true),
                    Marks = table.Column<double>(nullable: true),
                    IsPass = table.Column<bool>(nullable: false),
                    EnrolleedDate = table.Column<DateTime>(nullable: false),
                    StudentEnrollmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnrollmentSection_StudentEnrollment_StudentEnrollmentId",
                        column: x => x.StudentEnrollmentId,
                        principalTable: "StudentEnrollment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoursePrerequisite",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(nullable: false),
                    PrerequisiteCourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePrerequisite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursePrerequisite_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursePrerequisite_Course_PrerequisiteCourseId",
                        column: x => x.PrerequisiteCourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SectionInstructor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorId = table.Column<int>(nullable: false),
                    CourseSectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionInstructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionInstructor_CourseSection_CourseSectionId",
                        column: x => x.CourseSectionId,
                        principalTable: "CourseSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SectionLocation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionDay = table.Column<string>(nullable: false),
                    Location = table.Column<string>(maxLength: 25, nullable: false),
                    StartTime = table.Column<string>(maxLength: 10, nullable: false),
                    EndTime = table.Column<string>(maxLength: 10, nullable: false),
                    CourseSectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionLocation_CourseSection_CourseSectionId",
                        column: x => x.CourseSectionId,
                        principalTable: "CourseSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_Code",
                table: "Course",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentId",
                table: "Course",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePrerequisite_PrerequisiteCourseId",
                table: "CoursePrerequisite",
                column: "PrerequisiteCourseId");

            migrationBuilder.CreateIndex(
                name: "UK_CourseId_PrerequisiteCourseId",
                table: "CoursePrerequisite",
                columns: new[] { "CourseId", "PrerequisiteCourseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseSection_SemesterCourseId",
                table: "CourseSection",
                column: "SemesterCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_Name",
                table: "Department",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentSection_StudentEnrollmentId",
                table: "EnrollmentSection",
                column: "StudentEnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_DepartmentId",
                table: "Instructor",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionInstructor_CourseSectionId",
                table: "SectionInstructor",
                column: "CourseSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionLocation_CourseSectionId",
                table: "SectionLocation",
                column: "CourseSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_DepartmentId",
                table: "Student",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursePrerequisite");

            migrationBuilder.DropTable(
                name: "EnrollmentSection");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "SectionInstructor");

            migrationBuilder.DropTable(
                name: "SectionLocation");

            migrationBuilder.DropTable(
                name: "SemesterYear");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "StudentEnrollment");

            migrationBuilder.DropTable(
                name: "CourseSection");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "SemesterCourse");

            migrationBuilder.DropSequence(
                name: "Course_hilo");

            migrationBuilder.DropSequence(
                name: "Department_hilo");

            migrationBuilder.DropSequence(
                name: "Instructor_hilo");

            migrationBuilder.DropSequence(
                name: "semester_year_hilo");

            migrationBuilder.DropSequence(
                name: "Student_hilo");
        }
    }
}
