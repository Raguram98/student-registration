namespace StudentRegistration.Models
{
    public class StudentDto
    {
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; }
        public string Department { get; set; } = string.Empty;
        public string EmailID { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
    }
}
