using LMS.Models;
using LMS.DTOS.Instructors;
using LMS.DTOS.Courses;


namespace LMS.DTOS.ClassesDTO
{
    public class ClassDTO
    {
        public int Id { get; set; }
        public InstructorDTO instructor { get; set; }
        public string? Section { get; set; }
        
        public CourseDTO? Course { get; set; }

        public DateTime startDate { get; set; }


        public ClassDTO(Class _class){
            Id = _class.Id;
            instructor = new InstructorDTO(_class.Instructor);
            Section = _class.Section;
            Course = null;
            startDate = _class.StartDate;
        }
        public ClassDTO() { }

    }
}
