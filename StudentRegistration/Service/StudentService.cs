using Microsoft.EntityFrameworkCore;
using StudentRegistration.Data;
using StudentRegistration.Models;

namespace StudentRegistration.Service
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students
                .FromSqlInterpolated($"EXEC usp_GetAllStudents")
                .ToListAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(Guid studentId)
        {
            var students = await _context.Students
                .FromSqlInterpolated($"EXEC usp_GetStudentById {studentId}")
                .ToListAsync();

            return students.FirstOrDefault();
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            if (student.DateOfBirth > DateOnly.FromDateTime(DateTime.Now))
                throw new ArgumentException("Date of Birth cannot be in the future.");

            var rows = await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC usp_UpdateStudent {student.StudentID}, {student.Name}, {student.Gender}, {student.Department}, {student.EmailID}, {student.DateOfBirth}");

            return rows > 0;
        }

        public async Task<Student> AddStudentAsync(StudentDto dto)
        {
            if (dto.DateOfBirth > DateOnly.FromDateTime(DateTime.Now))
                throw new ArgumentException("Date of Birth cannot be in the future.");

            var student = new Student
            {
                StudentID = Guid.NewGuid(),
                Name = dto.Name,
                Gender = dto.Gender,
                Department = dto.Department,
                EmailID = dto.EmailID,
                DateOfBirth = dto.DateOfBirth
            };

            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC usp_AddStudent {student.StudentID}, {student.Name}, {student.Gender}, {student.Department}, {student.EmailID}, {student.DateOfBirth}");

            return student;
        }

        public async Task<bool> DeleteStudentAsync(Guid studentId)
        {
            var rows = await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC usp_DeleteStudent {studentId}");

            return rows > 0;
        }
    }
}