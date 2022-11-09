using LMS.Models;

namespace LMS.DTOS.Instructors
{
    public class InstructorDTO
    {
        public string? Id { get; set; }
        public string? Name { get; set; }

        public string? UserName { get; set; }

        public string? PasswordHash { get; set; }

        public string FacultyType { get; set; }

        public InstructorDTO(Instructor ins) {
            Id = ins.Id;
            Name = ins.Name;
            UserName = ins.UserName;
            PasswordHash = ins.PasswordHash;    
            FacultyType = ins.FacultyType;
        }
        public InstructorDTO() { }
    }
}
