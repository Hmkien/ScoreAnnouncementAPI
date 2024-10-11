using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScoreAnnouncementAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConvertForms",
                columns: table => new
                {
                    ConvertFormId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentCode = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    CertificateType = table.Column<string>(type: "TEXT", nullable: false),
                    CertificateName = table.Column<string>(type: "TEXT", nullable: false),
                    SendDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                    fileDocx = table.Column<string>(type: "TEXT", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConvertForms", x => x.ConvertFormId);
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExamCode = table.Column<string>(type: "TEXT", nullable: false),
                    ExamName = table.Column<string>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatePerson = table.Column<string>(type: "TEXT", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: true),
                    IsDelete = table.Column<bool>(type: "INTEGER", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    ExamTypeId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.ExamId);
                });

            migrationBuilder.CreateTable(
                name: "ExamType",
                columns: table => new
                {
                    ExamTypeId = table.Column<string>(type: "TEXT", nullable: false),
                    ExamTypeName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamType", x => x.ExamTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ITStudent",
                columns: table => new
                {
                    IdentityNumber = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    BirthDay = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    national = table.Column<string>(type: "TEXT", nullable: true),
                    IdentificationCode = table.Column<string>(type: "TEXT", nullable: true),
                    Note = table.Column<string>(type: "TEXT", nullable: true),
                    ExamId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITStudent", x => x.IdentityNumber);
                });

            migrationBuilder.CreateTable(
                name: "ScoreFL",
                columns: table => new
                {
                    ScoreFLCode = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExamId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentCode = table.Column<string>(type: "TEXT", nullable: false),
                    SpeakingScore = table.Column<string>(type: "TEXT", nullable: false),
                    ReadingScore = table.Column<string>(type: "TEXT", nullable: false),
                    WritingScore = table.Column<string>(type: "TEXT", nullable: false),
                    ListeningScore = table.Column<string>(type: "TEXT", nullable: false),
                    TotalScore = table.Column<string>(type: "TEXT", nullable: true),
                    Result = table.Column<string>(type: "TEXT", nullable: true),
                    Note = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreFL", x => x.ScoreFLCode);
                });

            migrationBuilder.CreateTable(
                name: "ScoreIT",
                columns: table => new
                {
                    ScoreITCode = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentCode = table.Column<string>(type: "TEXT", nullable: true),
                    IdentityNumber = table.Column<string>(type: "TEXT", nullable: true),
                    examId = table.Column<int>(type: "INTEGER", nullable: false),
                    PracticalScore = table.Column<string>(type: "TEXT", nullable: false),
                    WordScore = table.Column<string>(type: "TEXT", nullable: true),
                    ExcelScore = table.Column<string>(type: "TEXT", nullable: true),
                    PowerPointScore = table.Column<string>(type: "TEXT", nullable: true),
                    TheoryScore = table.Column<string>(type: "TEXT", nullable: false),
                    TotalScore = table.Column<string>(type: "TEXT", nullable: true),
                    Result = table.Column<string>(type: "TEXT", nullable: true),
                    Note = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreIT", x => x.ScoreITCode);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentCode = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Note = table.Column<int>(type: "INTEGER", nullable: true),
                    Course = table.Column<string>(type: "TEXT", nullable: true),
                    Faculty = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsDelete = table.Column<bool>(type: "INTEGER", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentCode);
                });

            migrationBuilder.CreateTable(
                name: "StudentExam",
                columns: table => new
                {
                    StudentExamId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true),
                    Note = table.Column<string>(type: "TEXT", nullable: true),
                    ExamId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentCode = table.Column<string>(type: "TEXT", nullable: true),
                    IdentityNumber = table.Column<string>(type: "TEXT", nullable: true),
                    ITStudentIdentityNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExam", x => x.StudentExamId);
                    table.ForeignKey(
                        name: "FK_StudentExam_ITStudent_ITStudentIdentityNumber",
                        column: x => x.ITStudentIdentityNumber,
                        principalTable: "ITStudent",
                        principalColumn: "IdentityNumber");
                    table.ForeignKey(
                        name: "FK_StudentExam_Student_StudentCode",
                        column: x => x.StudentCode,
                        principalTable: "Student",
                        principalColumn: "StudentCode");
                });

            migrationBuilder.CreateTable(
                name: "RequireForms",
                columns: table => new
                {
                    RequireFormCode = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudenCode = table.Column<string>(type: "TEXT", nullable: false),
                    FileDocx = table.Column<string>(type: "TEXT", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    StudentCode = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequireForms", x => x.RequireFormCode);
                    table.ForeignKey(
                        name: "FK_RequireForms_StudentExam_StudentCode",
                        column: x => x.StudentCode,
                        principalTable: "StudentExam",
                        principalColumn: "StudentExamId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequireForms_StudentCode",
                table: "RequireForms",
                column: "StudentCode");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExam_ITStudentIdentityNumber",
                table: "StudentExam",
                column: "ITStudentIdentityNumber");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExam_StudentCode",
                table: "StudentExam",
                column: "StudentCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConvertForms");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "ExamType");

            migrationBuilder.DropTable(
                name: "RequireForms");

            migrationBuilder.DropTable(
                name: "ScoreFL");

            migrationBuilder.DropTable(
                name: "ScoreIT");

            migrationBuilder.DropTable(
                name: "StudentExam");

            migrationBuilder.DropTable(
                name: "ITStudent");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
