using LMS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LMS.DTOS.Courses
{
    public class CourseDTO
    {

        public string? CourseID { get; set; }

        public string? CourseName { get; set; }

        public string? CourseDescription { get; set; }


        public int CreditHours { get; set; }

        public string CourseType { get; set; }


     
    }
}
