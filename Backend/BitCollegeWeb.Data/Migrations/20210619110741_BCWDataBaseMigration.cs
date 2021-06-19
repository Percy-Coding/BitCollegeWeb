using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BitCollegeWeb.Data.Migrations
{
    public partial class BCWDataBaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "calification_assignment",
                columns: table => new
                {
                    calification_assignment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    note = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    comment_published = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calification_assignment", x => x.calification_assignment_id);
                });

            migrationBuilder.CreateTable(
                name: "calification_exam",
                columns: table => new
                {
                    calification_exam_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    note = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calification_exam", x => x.calification_exam_id);
                });

            migrationBuilder.CreateTable(
                name: "calification_system",
                columns: table => new
                {
                    calification_system_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number_percentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calification_system", x => x.calification_system_id);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    company_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.company_id);
                });

            migrationBuilder.CreateTable(
                name: "day",
                columns: table => new
                {
                    day_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_day", x => x.day_id);
                });

            migrationBuilder.CreateTable(
                name: "external_tool",
                columns: table => new
                {
                    external_tool_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_external_tool", x => x.external_tool_id);
                });

            migrationBuilder.CreateTable(
                name: "institution",
                columns: table => new
                {
                    institution_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_institution", x => x.institution_id);
                });

            migrationBuilder.CreateTable(
                name: "teacher_forum",
                columns: table => new
                {
                    teacher_forum_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    problem_description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_forum", x => x.teacher_forum_id);
                });

            migrationBuilder.CreateTable(
                name: "topic",
                columns: table => new
                {
                    topic_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topic", x => x.topic_id);
                });

            migrationBuilder.CreateTable(
                name: "type_calification",
                columns: table => new
                {
                    type_calification_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type_calification", x => x.type_calification_id);
                });

            migrationBuilder.CreateTable(
                name: "type_programming_class",
                columns: table => new
                {
                    type_programming_class_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type_programming_class", x => x.type_programming_class_id);
                });

            migrationBuilder.CreateTable(
                name: "type_section",
                columns: table => new
                {
                    type_section_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type_section", x => x.type_section_id);
                });

            migrationBuilder.CreateTable(
                name: "type_study",
                columns: table => new
                {
                    type_study_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type_study", x => x.type_study_id);
                });

            migrationBuilder.CreateTable(
                name: "teacher_experience",
                columns: table => new
                {
                    teacher_experience_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_start_programming = table.Column<DateTime>(type: "datetime2", nullable: false),
                    position = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    company_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_experience", x => x.teacher_experience_id);
                    table.ForeignKey(
                        name: "FK_company_id",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student_experience",
                columns: table => new
                {
                    student_experience_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_start_programming = table.Column<DateTime>(type: "datetime2", nullable: false),
                    institution_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_experience", x => x.student_experience_id);
                    table.ForeignKey(
                        name: "FK_institution_id",
                        column: x => x.institution_id,
                        principalTable: "institution",
                        principalColumn: "institution_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "evidence",
                columns: table => new
                {
                    evidence_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    evidence_link = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    teacher_forum_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evidence", x => x.evidence_id);
                    table.ForeignKey(
                        name: "FK_teacher_forum_id",
                        column: x => x.teacher_forum_id,
                        principalTable: "teacher_forum",
                        principalColumn: "teacher_forum_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "url",
                columns: table => new
                {
                    url_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url_link = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    external_tool_id = table.Column<int>(type: "int", nullable: false),
                    topic_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_url", x => x.url_id);
                    table.ForeignKey(
                        name: "FK_external_tool_id",
                        column: x => x.external_tool_id,
                        principalTable: "external_tool",
                        principalColumn: "external_tool_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_topic_id",
                        column: x => x.topic_id,
                        principalTable: "topic",
                        principalColumn: "topic_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "calification_system_type_calification",
                columns: table => new
                {
                    type_calification_id = table.Column<int>(type: "int", nullable: false),
                    calification_system_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calification_system_type_calification", x => new { x.calification_system_id, x.type_calification_id });
                    table.ForeignKey(
                        name: "FK_calification_system_id",
                        column: x => x.calification_system_id,
                        principalTable: "calification_system",
                        principalColumn: "calification_system_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_type_calification_id",
                        column: x => x.type_calification_id,
                        principalTable: "type_calification",
                        principalColumn: "type_calification_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "programming_study",
                columns: table => new
                {
                    programming_study_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    type_study_id = table.Column<int>(type: "int", nullable: false),
                    calification_system_id = table.Column<int>(type: "int", nullable: false),
                    type_programming_class_id = table.Column<int>(type: "int", nullable: false),
                    CalificationSystemId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programming_study", x => x.programming_study_id);
                    table.ForeignKey(
                        name: "FK_calification_system_id",
                        column: x => x.calification_system_id,
                        principalTable: "calification_system",
                        principalColumn: "calification_system_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_programming_study_calification_system_CalificationSystemId1",
                        column: x => x.CalificationSystemId1,
                        principalTable: "calification_system",
                        principalColumn: "calification_system_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_type_programming_class_id",
                        column: x => x.type_programming_class_id,
                        principalTable: "type_programming_class",
                        principalColumn: "type_programming_class_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_type_study_id",
                        column: x => x.type_study_id,
                        principalTable: "type_study",
                        principalColumn: "type_study_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacher_experience_id = table.Column<int>(type: "int", nullable: false),
                    TeacherExperienceId1 = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher", x => x.teacher_id);
                    table.ForeignKey(
                        name: "FK_teacher_experience_id",
                        column: x => x.teacher_experience_id,
                        principalTable: "teacher_experience",
                        principalColumn: "teacher_experience_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacher_teacher_experience_TeacherExperienceId1",
                        column: x => x.TeacherExperienceId1,
                        principalTable: "teacher_experience",
                        principalColumn: "teacher_experience_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_experience_id = table.Column<int>(type: "int", nullable: false),
                    StudentExperienceId1 = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.student_id);
                    table.ForeignKey(
                        name: "FK_student_experience_id",
                        column: x => x.student_experience_id,
                        principalTable: "student_experience",
                        principalColumn: "student_experience_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_student_experience_StudentExperienceId1",
                        column: x => x.StudentExperienceId1,
                        principalTable: "student_experience",
                        principalColumn: "student_experience_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "general_information",
                columns: table => new
                {
                    topic_id = table.Column<int>(type: "int", nullable: false),
                    programming_study_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_general_information", x => new { x.topic_id, x.programming_study_id });
                    table.ForeignKey(
                        name: "FK_programming_study_id",
                        column: x => x.programming_study_id,
                        principalTable: "programming_study",
                        principalColumn: "programming_study_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_topic_id",
                        column: x => x.topic_id,
                        principalTable: "topic",
                        principalColumn: "topic_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "section",
                columns: table => new
                {
                    section_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    section_code = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    programming_study_id = table.Column<int>(type: "int", nullable: false),
                    number_recordings = table.Column<int>(type: "int", nullable: false),
                    number_students_enroll = table.Column<int>(type: "int", nullable: false),
                    vacancies = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_section", x => x.section_id);
                    table.ForeignKey(
                        name: "FK_programming_study_id",
                        column: x => x.programming_study_id,
                        principalTable: "programming_study",
                        principalColumn: "programming_study_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inscription",
                columns: table => new
                {
                    inscription_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    programming_study_id = table.Column<int>(type: "int", nullable: false),
                    date_inscription = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inscription", x => x.inscription_id);
                    table.ForeignKey(
                        name: "FK_programming_study_id",
                        column: x => x.programming_study_id,
                        principalTable: "programming_study",
                        principalColumn: "programming_study_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_id",
                        column: x => x.student_id,
                        principalTable: "student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notification",
                columns: table => new
                {
                    notification_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    teacher_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification", x => x.notification_id);
                    table.ForeignKey(
                        name: "FK_student_id",
                        column: x => x.student_id,
                        principalTable: "student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "registration",
                columns: table => new
                {
                    registration_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    email = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    password = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    teacher_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registration", x => x.registration_id);
                    table.ForeignKey(
                        name: "FK_student_id",
                        column: x => x.student_id,
                        principalTable: "student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "schedule",
                columns: table => new
                {
                    schedule_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type_programming_class_id = table.Column<int>(type: "int", nullable: false),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    TypeProgrammingClassId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedule", x => x.schedule_id);
                    table.ForeignKey(
                        name: "FK_schedule_type_programming_class_TypeProgrammingClassId1",
                        column: x => x.TypeProgrammingClassId1,
                        principalTable: "type_programming_class",
                        principalColumn: "type_programming_class_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_student_id",
                        column: x => x.student_id,
                        principalTable: "student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_type_programming_class_id",
                        column: x => x.type_programming_class_id,
                        principalTable: "type_programming_class",
                        principalColumn: "type_programming_class_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "announcement",
                columns: table => new
                {
                    announcement_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    date_limit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    section_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_announcement", x => x.announcement_id);
                    table.ForeignKey(
                        name: "FK_section_id",
                        column: x => x.section_id,
                        principalTable: "section",
                        principalColumn: "section_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assignment",
                columns: table => new
                {
                    assignment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    date_limit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    section_id = table.Column<int>(type: "int", nullable: false),
                    document_link = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    shipping_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pending_complete = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    sent_notsent = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    calification_assignment_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignment", x => x.assignment_id);
                    table.ForeignKey(
                        name: "FK_calification_assignment_id",
                        column: x => x.calification_assignment_id,
                        principalTable: "calification_assignment",
                        principalColumn: "calification_assignment_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_section_id",
                        column: x => x.section_id,
                        principalTable: "section",
                        principalColumn: "section_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "classroom",
                columns: table => new
                {
                    classroom_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    name = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    section_id = table.Column<int>(type: "int", nullable: false),
                    teacher_forum_id = table.Column<int>(type: "int", nullable: false),
                    TeacherForumId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classroom", x => x.classroom_id);
                    table.ForeignKey(
                        name: "FK_classroom_teacher_forum_TeacherForumId1",
                        column: x => x.TeacherForumId1,
                        principalTable: "teacher_forum",
                        principalColumn: "teacher_forum_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_section_id",
                        column: x => x.section_id,
                        principalTable: "section",
                        principalColumn: "section_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacher_forum_id",
                        column: x => x.teacher_forum_id,
                        principalTable: "teacher_forum",
                        principalColumn: "teacher_forum_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exam",
                columns: table => new
                {
                    exam_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    date_start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    start_time = table.Column<int>(type: "int", nullable: false),
                    finish_time = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    section_id = table.Column<int>(type: "int", nullable: false),
                    calification_exam_id = table.Column<int>(type: "int", nullable: false),
                    pending_complete = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    sent_notsent = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exam", x => x.exam_id);
                    table.ForeignKey(
                        name: "FK_calification_exam_id",
                        column: x => x.calification_exam_id,
                        principalTable: "calification_exam",
                        principalColumn: "calification_exam_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_section_id",
                        column: x => x.section_id,
                        principalTable: "section",
                        principalColumn: "section_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "section_type_section",
                columns: table => new
                {
                    section_id = table.Column<int>(type: "int", nullable: false),
                    type_section_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_section_type_section", x => new { x.section_id, x.type_section_id });
                    table.ForeignKey(
                        name: "FK_section_id",
                        column: x => x.section_id,
                        principalTable: "section",
                        principalColumn: "section_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_type_section_id",
                        column: x => x.type_section_id,
                        principalTable: "type_section",
                        principalColumn: "type_section_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student_section",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false),
                    section_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_section", x => new { x.student_id, x.section_id });
                    table.ForeignKey(
                        name: "FK_section_id",
                        column: x => x.section_id,
                        principalTable: "section",
                        principalColumn: "section_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_id",
                        column: x => x.student_id,
                        principalTable: "student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacher_section",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int", nullable: false),
                    section_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_section", x => new { x.teacher_id, x.section_id });
                    table.ForeignKey(
                        name: "FK_section_id",
                        column: x => x.section_id,
                        principalTable: "section",
                        principalColumn: "section_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "schedule_day",
                columns: table => new
                {
                    day_id = table.Column<int>(type: "int", nullable: false),
                    schedule_id = table.Column<int>(type: "int", nullable: false),
                    start_time = table.Column<int>(type: "int", nullable: false),
                    finish_time = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedule_day", x => new { x.schedule_id, x.day_id });
                    table.ForeignKey(
                        name: "FK_day_id",
                        column: x => x.day_id,
                        principalTable: "day",
                        principalColumn: "day_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_schedule_id",
                        column: x => x.schedule_id,
                        principalTable: "schedule",
                        principalColumn: "schedule_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chat",
                columns: table => new
                {
                    chat_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    classroom_id = table.Column<int>(type: "int", nullable: false),
                    teacher_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chat", x => x.chat_id);
                    table.ForeignKey(
                        name: "FK_classroom_id",
                        column: x => x.classroom_id,
                        principalTable: "classroom",
                        principalColumn: "classroom_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "classroom_external_tool",
                columns: table => new
                {
                    external_tool_id = table.Column<int>(type: "int", nullable: false),
                    classroom_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classroom_external_tool", x => new { x.external_tool_id, x.classroom_id });
                    table.ForeignKey(
                        name: "FK_classroom_id",
                        column: x => x.classroom_id,
                        principalTable: "classroom",
                        principalColumn: "classroom_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_external_tool_id",
                        column: x => x.external_tool_id,
                        principalTable: "external_tool",
                        principalColumn: "external_tool_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_announcement_section_id",
                table: "announcement",
                column: "section_id");

            migrationBuilder.CreateIndex(
                name: "IX_assignment_calification_assignment_id",
                table: "assignment",
                column: "calification_assignment_id");

            migrationBuilder.CreateIndex(
                name: "IX_assignment_section_id",
                table: "assignment",
                column: "section_id");

            migrationBuilder.CreateIndex(
                name: "IX_calification_system_type_calification_type_calification_id",
                table: "calification_system_type_calification",
                column: "type_calification_id");

            migrationBuilder.CreateIndex(
                name: "IX_chat_classroom_id",
                table: "chat",
                column: "classroom_id");

            migrationBuilder.CreateIndex(
                name: "IX_chat_teacher_id",
                table: "chat",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_classroom_section_id",
                table: "classroom",
                column: "section_id");

            migrationBuilder.CreateIndex(
                name: "IX_classroom_teacher_forum_id",
                table: "classroom",
                column: "teacher_forum_id");

            migrationBuilder.CreateIndex(
                name: "IX_classroom_TeacherForumId1",
                table: "classroom",
                column: "TeacherForumId1",
                unique: true,
                filter: "[TeacherForumId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_classroom_external_tool_classroom_id",
                table: "classroom_external_tool",
                column: "classroom_id");

            migrationBuilder.CreateIndex(
                name: "IX_evidence_teacher_forum_id",
                table: "evidence",
                column: "teacher_forum_id");

            migrationBuilder.CreateIndex(
                name: "IX_exam_calification_exam_id",
                table: "exam",
                column: "calification_exam_id");

            migrationBuilder.CreateIndex(
                name: "IX_exam_section_id",
                table: "exam",
                column: "section_id");

            migrationBuilder.CreateIndex(
                name: "IX_general_information_programming_study_id",
                table: "general_information",
                column: "programming_study_id");

            migrationBuilder.CreateIndex(
                name: "IX_inscription_programming_study_id",
                table: "inscription",
                column: "programming_study_id");

            migrationBuilder.CreateIndex(
                name: "IX_inscription_student_id",
                table: "inscription",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_notification_student_id",
                table: "notification",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_notification_teacher_id",
                table: "notification",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_programming_study_calification_system_id",
                table: "programming_study",
                column: "calification_system_id");

            migrationBuilder.CreateIndex(
                name: "IX_programming_study_CalificationSystemId1",
                table: "programming_study",
                column: "CalificationSystemId1",
                unique: true,
                filter: "[CalificationSystemId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_programming_study_type_programming_class_id",
                table: "programming_study",
                column: "type_programming_class_id");

            migrationBuilder.CreateIndex(
                name: "IX_programming_study_type_study_id",
                table: "programming_study",
                column: "type_study_id");

            migrationBuilder.CreateIndex(
                name: "IX_registration_student_id",
                table: "registration",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_registration_teacher_id",
                table: "registration",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_student_id",
                table: "schedule",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_type_programming_class_id",
                table: "schedule",
                column: "type_programming_class_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_TypeProgrammingClassId1",
                table: "schedule",
                column: "TypeProgrammingClassId1",
                unique: true,
                filter: "[TypeProgrammingClassId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_day_day_id",
                table: "schedule_day",
                column: "day_id");

            migrationBuilder.CreateIndex(
                name: "IX_section_programming_study_id",
                table: "section",
                column: "programming_study_id");

            migrationBuilder.CreateIndex(
                name: "IX_section_type_section_type_section_id",
                table: "section_type_section",
                column: "type_section_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_student_experience_id",
                table: "student",
                column: "student_experience_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_StudentExperienceId1",
                table: "student",
                column: "StudentExperienceId1",
                unique: true,
                filter: "[StudentExperienceId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_student_experience_institution_id",
                table: "student_experience",
                column: "institution_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_section_section_id",
                table: "student_section",
                column: "section_id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_teacher_experience_id",
                table: "teacher",
                column: "teacher_experience_id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_TeacherExperienceId1",
                table: "teacher",
                column: "TeacherExperienceId1",
                unique: true,
                filter: "[TeacherExperienceId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_experience_company_id",
                table: "teacher_experience",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_section_section_id",
                table: "teacher_section",
                column: "section_id");

            migrationBuilder.CreateIndex(
                name: "IX_url_external_tool_id",
                table: "url",
                column: "external_tool_id");

            migrationBuilder.CreateIndex(
                name: "IX_url_topic_id",
                table: "url",
                column: "topic_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "announcement");

            migrationBuilder.DropTable(
                name: "assignment");

            migrationBuilder.DropTable(
                name: "calification_system_type_calification");

            migrationBuilder.DropTable(
                name: "chat");

            migrationBuilder.DropTable(
                name: "classroom_external_tool");

            migrationBuilder.DropTable(
                name: "evidence");

            migrationBuilder.DropTable(
                name: "exam");

            migrationBuilder.DropTable(
                name: "general_information");

            migrationBuilder.DropTable(
                name: "inscription");

            migrationBuilder.DropTable(
                name: "notification");

            migrationBuilder.DropTable(
                name: "registration");

            migrationBuilder.DropTable(
                name: "schedule_day");

            migrationBuilder.DropTable(
                name: "section_type_section");

            migrationBuilder.DropTable(
                name: "student_section");

            migrationBuilder.DropTable(
                name: "teacher_section");

            migrationBuilder.DropTable(
                name: "url");

            migrationBuilder.DropTable(
                name: "calification_assignment");

            migrationBuilder.DropTable(
                name: "type_calification");

            migrationBuilder.DropTable(
                name: "classroom");

            migrationBuilder.DropTable(
                name: "calification_exam");

            migrationBuilder.DropTable(
                name: "day");

            migrationBuilder.DropTable(
                name: "schedule");

            migrationBuilder.DropTable(
                name: "type_section");

            migrationBuilder.DropTable(
                name: "teacher");

            migrationBuilder.DropTable(
                name: "external_tool");

            migrationBuilder.DropTable(
                name: "topic");

            migrationBuilder.DropTable(
                name: "teacher_forum");

            migrationBuilder.DropTable(
                name: "section");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "teacher_experience");

            migrationBuilder.DropTable(
                name: "programming_study");

            migrationBuilder.DropTable(
                name: "student_experience");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "calification_system");

            migrationBuilder.DropTable(
                name: "type_programming_class");

            migrationBuilder.DropTable(
                name: "type_study");

            migrationBuilder.DropTable(
                name: "institution");
        }
    }
}
