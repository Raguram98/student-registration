-- Delete a student
CREATE PROCEDURE usp_DeleteStudent
    @StudentID UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM Students
    WHERE StudentID = @StudentID
END
GO