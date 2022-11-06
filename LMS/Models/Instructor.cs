using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    public enum FacultyType { 
        Visiting,
        Permanent
    }

    public class Instructor
    {
        public string? Id { get; set; }
        public string? Name { get; set; }

        public string? UserName { get; set; }

        public string? PasswordHash { get; set; }

        public FacultyType FacultyType { get; set; }


        public  List<Classes> InstructorClasses { get; set; }
    }
}
