using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudentRegistration.Models
{
    public class Student
    {
        public Guid StudentID { get; set; } = Guid.NewGuid();
        [MinLength(4, ErrorMessage = "Name must be at least 4 characters long.")]
        public string Name { get; set; } = string.Empty;

        [MinLength(2, ErrorMessage = "Gender must be at least 2 characters long.")]
        public string Gender { get; set; } = string.Empty;
        [MinLength(4, ErrorMessage = "Name must be at least 4 characters long.")]
        public string Department { get; set; } = string.Empty;
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string EmailID { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
    }
}
