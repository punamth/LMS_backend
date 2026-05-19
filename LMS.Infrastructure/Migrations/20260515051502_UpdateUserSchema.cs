using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_CourseId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Users_UserId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Courses_CourseId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Progress_Lessons_LessonId",
                table: "Progress");

            migrationBuilder.DropForeignKey(
                name: "FK_Progress_Users_UserId",
                table: "Progress");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAttempts_Tests_TestId",
                table: "TestAttempts");

            migrationBuilder.DropForeignKey(
                name: "FK_TestAttempts_Users_UserId",
                table: "TestAttempts");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Courses_CourseId",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestAttempts",
                table: "TestAttempts");

            migrationBuilder.RenameTable(
                name: "TestAttempts",
                newName: "Test_attempts");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "password_hash");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "user_name");

            migrationBuilder.RenameColumn(
                name: "Options",
                table: "Tests",
                newName: "options");

            migrationBuilder.RenameColumn(
                name: "QuestionText",
                table: "Tests",
                newName: "question_text");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Tests",
                newName: "course_id");

            migrationBuilder.RenameColumn(
                name: "CorrectAnswer",
                table: "Tests",
                newName: "correct_answer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tests",
                newName: "test_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_CourseId",
                table: "Tests",
                newName: "IX_Tests_course_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Progress",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "Progress",
                newName: "lesson_id");

            migrationBuilder.RenameColumn(
                name: "CompletedAt",
                table: "Progress",
                newName: "completed_at");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Progress",
                newName: "progress_id");

            migrationBuilder.RenameIndex(
                name: "IX_Progress_UserId",
                table: "Progress",
                newName: "IX_Progress_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Progress_LessonId",
                table: "Progress",
                newName: "IX_Progress_lesson_id");

            migrationBuilder.RenameColumn(
                name: "VideoPath",
                table: "Lessons",
                newName: "video_path");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Lessons",
                newName: "lesson_title");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Lessons",
                newName: "course_id");

            migrationBuilder.RenameColumn(
                name: "ContentText",
                table: "Lessons",
                newName: "content_text");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Lessons",
                newName: "lesson_id");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_CourseId",
                table: "Lessons",
                newName: "IX_Lessons_course_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Enrollments",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "EnrolledAt",
                table: "Enrollments",
                newName: "enrolled_at");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Enrollments",
                newName: "course_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Enrollments",
                newName: "enrollment_id");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_UserId",
                table: "Enrollments",
                newName: "IX_Enrollments_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                newName: "IX_Enrollments_course_id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Courses",
                newName: "course_title");

            migrationBuilder.RenameColumn(
                name: "ThumbnailPath",
                table: "Courses",
                newName: "thumbnail_path");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Courses",
                newName: "course_description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Courses",
                newName: "course_id");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "Test_attempts",
                newName: "score");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Test_attempts",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "Test_attempts",
                newName: "test_id");

            migrationBuilder.RenameColumn(
                name: "SelectedAnswer",
                table: "Test_attempts",
                newName: "selected_answer");

            migrationBuilder.RenameColumn(
                name: "AttemptedAt",
                table: "Test_attempts",
                newName: "attempted_at");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Test_attempts",
                newName: "test_attempts_id");

            migrationBuilder.RenameIndex(
                name: "IX_TestAttempts_UserId",
                table: "Test_attempts",
                newName: "IX_Test_attempts_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_TestAttempts_TestId",
                table: "Test_attempts",
                newName: "IX_Test_attempts_test_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Test_attempts",
                table: "Test_attempts",
                column: "test_attempts_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_course_id",
                table: "Enrollments",
                column: "course_id",
                principalTable: "Courses",
                principalColumn: "course_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Users_user_id",
                table: "Enrollments",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Courses_course_id",
                table: "Lessons",
                column: "course_id",
                principalTable: "Courses",
                principalColumn: "course_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Progress_Lessons_lesson_id",
                table: "Progress",
                column: "lesson_id",
                principalTable: "Lessons",
                principalColumn: "lesson_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Progress_Users_user_id",
                table: "Progress",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Test_attempts_Tests_test_id",
                table: "Test_attempts",
                column: "test_id",
                principalTable: "Tests",
                principalColumn: "test_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Test_attempts_Users_user_id",
                table: "Test_attempts",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Courses_course_id",
                table: "Tests",
                column: "course_id",
                principalTable: "Courses",
                principalColumn: "course_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_course_id",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Users_user_id",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Courses_course_id",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Progress_Lessons_lesson_id",
                table: "Progress");

            migrationBuilder.DropForeignKey(
                name: "FK_Progress_Users_user_id",
                table: "Progress");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_attempts_Tests_test_id",
                table: "Test_attempts");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_attempts_Users_user_id",
                table: "Test_attempts");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Courses_course_id",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Test_attempts",
                table: "Test_attempts");

            migrationBuilder.RenameTable(
                name: "Test_attempts",
                newName: "TestAttempts");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "options",
                table: "Tests",
                newName: "Options");

            migrationBuilder.RenameColumn(
                name: "question_text",
                table: "Tests",
                newName: "QuestionText");

            migrationBuilder.RenameColumn(
                name: "course_id",
                table: "Tests",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "correct_answer",
                table: "Tests",
                newName: "CorrectAnswer");

            migrationBuilder.RenameColumn(
                name: "test_id",
                table: "Tests",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_course_id",
                table: "Tests",
                newName: "IX_Tests_CourseId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Progress",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "lesson_id",
                table: "Progress",
                newName: "LessonId");

            migrationBuilder.RenameColumn(
                name: "completed_at",
                table: "Progress",
                newName: "CompletedAt");

            migrationBuilder.RenameColumn(
                name: "progress_id",
                table: "Progress",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Progress_user_id",
                table: "Progress",
                newName: "IX_Progress_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Progress_lesson_id",
                table: "Progress",
                newName: "IX_Progress_LessonId");

            migrationBuilder.RenameColumn(
                name: "video_path",
                table: "Lessons",
                newName: "VideoPath");

            migrationBuilder.RenameColumn(
                name: "lesson_title",
                table: "Lessons",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "course_id",
                table: "Lessons",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "content_text",
                table: "Lessons",
                newName: "ContentText");

            migrationBuilder.RenameColumn(
                name: "lesson_id",
                table: "Lessons",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_course_id",
                table: "Lessons",
                newName: "IX_Lessons_CourseId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Enrollments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "enrolled_at",
                table: "Enrollments",
                newName: "EnrolledAt");

            migrationBuilder.RenameColumn(
                name: "course_id",
                table: "Enrollments",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "enrollment_id",
                table: "Enrollments",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_user_id",
                table: "Enrollments",
                newName: "IX_Enrollments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_course_id",
                table: "Enrollments",
                newName: "IX_Enrollments_CourseId");

            migrationBuilder.RenameColumn(
                name: "thumbnail_path",
                table: "Courses",
                newName: "ThumbnailPath");

            migrationBuilder.RenameColumn(
                name: "course_title",
                table: "Courses",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "course_description",
                table: "Courses",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "course_id",
                table: "Courses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "score",
                table: "TestAttempts",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "TestAttempts",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "test_id",
                table: "TestAttempts",
                newName: "TestId");

            migrationBuilder.RenameColumn(
                name: "selected_answer",
                table: "TestAttempts",
                newName: "SelectedAnswer");

            migrationBuilder.RenameColumn(
                name: "attempted_at",
                table: "TestAttempts",
                newName: "AttemptedAt");

            migrationBuilder.RenameColumn(
                name: "test_attempts_id",
                table: "TestAttempts",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Test_attempts_user_id",
                table: "TestAttempts",
                newName: "IX_TestAttempts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Test_attempts_test_id",
                table: "TestAttempts",
                newName: "IX_TestAttempts_TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestAttempts",
                table: "TestAttempts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_CourseId",
                table: "Enrollments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Users_UserId",
                table: "Enrollments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Courses_CourseId",
                table: "Lessons",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Progress_Lessons_LessonId",
                table: "Progress",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Progress_Users_UserId",
                table: "Progress",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestAttempts_Tests_TestId",
                table: "TestAttempts",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestAttempts_Users_UserId",
                table: "TestAttempts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Courses_CourseId",
                table: "Tests",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
