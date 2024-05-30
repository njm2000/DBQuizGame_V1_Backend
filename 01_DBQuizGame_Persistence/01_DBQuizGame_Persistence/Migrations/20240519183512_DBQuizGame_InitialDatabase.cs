using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _01_DBQuizGame_Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DBQuizGame_InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjectStates",
                columns: table => new
                {
                    IdObjectState = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectStates", x => x.IdObjectState);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    IdAdmin = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdObjectState = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.IdAdmin);
                    table.ForeignKey(
                        name: "FK_Admins_ObjectStates_IdObjectState",
                        column: x => x.IdObjectState,
                        principalTable: "ObjectStates",
                        principalColumn: "IdObjectState");
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    IdCertificate = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IdObjectState = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.IdCertificate);
                    table.ForeignKey(
                        name: "FK_Certificates_ObjectStates_IdObjectState",
                        column: x => x.IdObjectState,
                        principalTable: "ObjectStates",
                        principalColumn: "IdObjectState");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    IdPlayer = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MatricsNo = table.Column<long>(type: "bigint", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalPoints = table.Column<long>(type: "bigint", nullable: false),
                    IdObjectState = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.IdPlayer);
                    table.ForeignKey(
                        name: "FK_Players_ObjectStates_IdObjectState",
                        column: x => x.IdObjectState,
                        principalTable: "ObjectStates",
                        principalColumn: "IdObjectState");
                });

            migrationBuilder.CreateTable(
                name: "QuestionTypes",
                columns: table => new
                {
                    IdQuestionType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TotalOption = table.Column<int>(type: "int", nullable: false),
                    IdObjectState = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTypes", x => x.IdQuestionType);
                    table.ForeignKey(
                        name: "FK_QuestionTypes_ObjectStates_IdObjectState",
                        column: x => x.IdObjectState,
                        principalTable: "ObjectStates",
                        principalColumn: "IdObjectState");
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    IdQuiz = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TotalQuestion = table.Column<int>(type: "int", nullable: false),
                    MaxScore = table.Column<int>(type: "int", nullable: false),
                    ExpectedCompletionTime = table.Column<int>(type: "int", nullable: false),
                    IdObjectState = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.IdQuiz);
                    table.ForeignKey(
                        name: "FK_Quizzes_ObjectStates_IdObjectState",
                        column: x => x.IdObjectState,
                        principalTable: "ObjectStates",
                        principalColumn: "IdObjectState");
                });

            migrationBuilder.CreateTable(
                name: "PlayerCertificates",
                columns: table => new
                {
                    IdPlayerCertificate = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TotalAttempt = table.Column<int>(type: "int", nullable: false),
                    TimeTaken = table.Column<int>(type: "int", nullable: false),
                    PointsAcquired = table.Column<int>(type: "int", nullable: false),
                    IdPlayer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCertificate = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdObjectState = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCertificates", x => x.IdPlayerCertificate);
                    table.ForeignKey(
                        name: "FK_PlayerCertificates_Certificates_IdCertificate",
                        column: x => x.IdCertificate,
                        principalTable: "Certificates",
                        principalColumn: "IdCertificate");
                    table.ForeignKey(
                        name: "FK_PlayerCertificates_ObjectStates_IdObjectState",
                        column: x => x.IdObjectState,
                        principalTable: "ObjectStates",
                        principalColumn: "IdObjectState");
                    table.ForeignKey(
                        name: "FK_PlayerCertificates_Players_IdPlayer",
                        column: x => x.IdPlayer,
                        principalTable: "Players",
                        principalColumn: "IdPlayer");
                });

            migrationBuilder.CreateTable(
                name: "PlayerQuizzes",
                columns: table => new
                {
                    IdPlayerQuiz = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TotalScore = table.Column<int>(type: "int", nullable: false),
                    TimeTaken = table.Column<int>(type: "int", nullable: false),
                    PointsAcquired = table.Column<int>(type: "int", nullable: false),
                    IdPlayer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdQuiz = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdObjectState = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerQuizzes", x => x.IdPlayerQuiz);
                    table.ForeignKey(
                        name: "FK_PlayerQuizzes_ObjectStates_IdObjectState",
                        column: x => x.IdObjectState,
                        principalTable: "ObjectStates",
                        principalColumn: "IdObjectState");
                    table.ForeignKey(
                        name: "FK_PlayerQuizzes_Players_IdPlayer",
                        column: x => x.IdPlayer,
                        principalTable: "Players",
                        principalColumn: "IdPlayer");
                    table.ForeignKey(
                        name: "FK_PlayerQuizzes_Quizzes_IdQuiz",
                        column: x => x.IdQuiz,
                        principalTable: "Quizzes",
                        principalColumn: "IdQuiz");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    IdQuestion = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Difficulty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdQuiz = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdQuestionType = table.Column<int>(type: "int", nullable: false),
                    IdObjectState = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.IdQuestion);
                    table.ForeignKey(
                        name: "FK_Questions_ObjectStates_IdObjectState",
                        column: x => x.IdObjectState,
                        principalTable: "ObjectStates",
                        principalColumn: "IdObjectState");
                    table.ForeignKey(
                        name: "FK_Questions_QuestionTypes_IdQuestionType",
                        column: x => x.IdQuestionType,
                        principalTable: "QuestionTypes",
                        principalColumn: "IdQuestionType");
                    table.ForeignKey(
                        name: "FK_Questions_Quizzes_IdQuiz",
                        column: x => x.IdQuiz,
                        principalTable: "Quizzes",
                        principalColumn: "IdQuiz");
                });

            migrationBuilder.CreateTable(
                name: "QuizCertificates",
                columns: table => new
                {
                    IdQuizCertificate = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IdQuiz = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCertificate = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdObjectState = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizCertificates", x => x.IdQuizCertificate);
                    table.ForeignKey(
                        name: "FK_QuizCertificates_Certificates_IdCertificate",
                        column: x => x.IdCertificate,
                        principalTable: "Certificates",
                        principalColumn: "IdCertificate");
                    table.ForeignKey(
                        name: "FK_QuizCertificates_ObjectStates_IdObjectState",
                        column: x => x.IdObjectState,
                        principalTable: "ObjectStates",
                        principalColumn: "IdObjectState");
                    table.ForeignKey(
                        name: "FK_QuizCertificates_Quizzes_IdQuiz",
                        column: x => x.IdQuiz,
                        principalTable: "Quizzes",
                        principalColumn: "IdQuiz");
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    IdOption = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: true),
                    CorrectSlot = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CorrectSlotGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdObjectState = table.Column<int>(type: "int", nullable: false),
                    IdQuestion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.IdOption);
                    table.ForeignKey(
                        name: "FK_Options_ObjectStates_IdObjectState",
                        column: x => x.IdObjectState,
                        principalTable: "ObjectStates",
                        principalColumn: "IdObjectState");
                    table.ForeignKey(
                        name: "FK_Options_Questions_IdQuestion",
                        column: x => x.IdQuestion,
                        principalTable: "Questions",
                        principalColumn: "IdQuestion");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_IdObjectState",
                table: "Admins",
                column: "IdObjectState");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Name",
                table: "Admins",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_IdObjectState",
                table: "Certificates",
                column: "IdObjectState");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_Name",
                table: "Certificates",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ObjectStates_Name",
                table: "ObjectStates",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Options_IdObjectState",
                table: "Options",
                column: "IdObjectState");

            migrationBuilder.CreateIndex(
                name: "IX_Options_IdQuestion",
                table: "Options",
                column: "IdQuestion");

            migrationBuilder.CreateIndex(
                name: "IX_Options_Name",
                table: "Options",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCertificates_IdCertificate",
                table: "PlayerCertificates",
                column: "IdCertificate");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCertificates_IdObjectState",
                table: "PlayerCertificates",
                column: "IdObjectState");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCertificates_IdPlayer",
                table: "PlayerCertificates",
                column: "IdPlayer");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerQuizzes_IdObjectState",
                table: "PlayerQuizzes",
                column: "IdObjectState");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerQuizzes_IdPlayer",
                table: "PlayerQuizzes",
                column: "IdPlayer");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerQuizzes_IdQuiz",
                table: "PlayerQuizzes",
                column: "IdQuiz");

            migrationBuilder.CreateIndex(
                name: "IX_Players_IdObjectState",
                table: "Players",
                column: "IdObjectState");

            migrationBuilder.CreateIndex(
                name: "IX_Players_Name",
                table: "Players",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_IdObjectState",
                table: "Questions",
                column: "IdObjectState");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_IdQuestionType",
                table: "Questions",
                column: "IdQuestionType");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_IdQuiz",
                table: "Questions",
                column: "IdQuiz");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Name",
                table: "Questions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTypes_IdObjectState",
                table: "QuestionTypes",
                column: "IdObjectState");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTypes_Name",
                table: "QuestionTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizCertificates_IdCertificate",
                table: "QuizCertificates",
                column: "IdCertificate");

            migrationBuilder.CreateIndex(
                name: "IX_QuizCertificates_IdObjectState",
                table: "QuizCertificates",
                column: "IdObjectState");

            migrationBuilder.CreateIndex(
                name: "IX_QuizCertificates_IdQuiz",
                table: "QuizCertificates",
                column: "IdQuiz");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_IdObjectState",
                table: "Quizzes",
                column: "IdObjectState");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_Name",
                table: "Quizzes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "PlayerCertificates");

            migrationBuilder.DropTable(
                name: "PlayerQuizzes");

            migrationBuilder.DropTable(
                name: "QuizCertificates");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "QuestionTypes");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "ObjectStates");
        }
    }
}
