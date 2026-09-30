using StudentRegistration.Models;

namespace StudentRegistration.Service
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIdAsync(Guid studentId);
        Task<Student> AddStudentAsync(StudentDto dto);
        Task<bool> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(Guid studentId);
    }
}
