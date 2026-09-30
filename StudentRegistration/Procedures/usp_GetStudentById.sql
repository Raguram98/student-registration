-- Get one student by ID
CREATE PROCEDURE usp_GetStudentById
    @StudentID UNIQUEIDENTIFIER
AS
BEGIN
    SELECT StudentID, Name, Gender, Department, EmailID, DateOfBirth
    FROM Students
    WHERE StudentID = @StudentID
END
GO