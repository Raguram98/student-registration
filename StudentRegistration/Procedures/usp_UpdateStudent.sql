-- Update a student
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
END
GO