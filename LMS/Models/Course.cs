using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    public enum CourseType { 
        Thoery,
        Lab
    }


    public partial class Course
    {

        public string? CourseID { get; set; }
     
        public string? CourseName { get; set; }
    
        public string? CourseDescription { get; set; }
        
       
        public int CreditHours { get; set; }

        public string courseType { get; set; }

        

        public virtual List<Class>? Classes { get; set; }


        //public List<Instructor_Course> InstructorCourses { get; set; }

    }
}
