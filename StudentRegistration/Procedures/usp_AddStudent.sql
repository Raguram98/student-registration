-- Add a student
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
END
GO