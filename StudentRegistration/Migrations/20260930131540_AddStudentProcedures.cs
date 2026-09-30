using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentRegistration.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE usp_GetAllStudents
                AS
                BEGIN
                    SELECT StudentID, Name, Gender, Department, EmailID, DateOfBirth
                    FROM Students
                END");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE usp_GetStudentById
                    @StudentID UNIQUEIDENTIFIER
                AS
                BEGIN
                    SELECT StudentID, Name, Gender, Department, EmailID, DateOfBirth
                    FROM Students
                    WHERE StudentID = @StudentID
                END");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE usp_AddStudent
                    @StudentID   UNIQUEIDENTIFIER,
                    @Name        NVARCHAR(100),
                    @Gender      NVARCHAR(20),
                    @Department  NVARCHAR(100),
                    @EmailID     NVARCHAR(150),
                    @DateOfBirth DATE
                AS
                BEGIN
                    INSERT INTO Students (StudentID, Name, Gender, Department, EmailID, DateOfBirth)
                    VALUES (@StudentID, @Name, @Gender, @Department, @EmailID, @DateOfBirth)
                END");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE usp_UpdateStudent
                    @StudentID   UNIQUEIDENTIFIER,
                    @Name        NVARCHAR(100),
                    @Gender      NVARCHAR(20),
                    @Department  NVARCHAR(100),
                    @EmailID     NVARCHAR(150),
                    @DateOfBirth DATE
                AS
                BEGIN
                    UPDATE Students
                    SET Name = @Name,
                        Gender = @Gender,
                        Department = @Department,
                        EmailID = @EmailID,
                        DateOfBirth = @DateOfBirth
                    WHERE StudentID = @StudentID
                END");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE usp_DeleteStudent
                    @StudentID UNIQUEIDENTIFIER
                AS
                BEGIN
                    DELETE FROM Students
                    WHERE StudentID = @StudentID
                END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE usp_GetAllStudents");
            migrationBuilder.Sql("DROP PROCEDURE usp_GetStudentById");
            migrationBuilder.Sql("DROP PROCEDURE usp_AddStudent");
            migrationBuilder.Sql("DROP PROCEDURE usp_UpdateStudent");
            migrationBuilder.Sql("DROP PROCEDURE usp_DeleteStudent");
        }
    }

}
