-- Get all students
CREATE PROCEDURE usp_GetAllStudents
AS
BEGIN
    SELECT StudentID, Name, Gender, Department, EmailID, DateOfBirth
    FROM Students
END
GO