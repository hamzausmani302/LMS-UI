using LMS.DTOS.Courses;

namespace LMS.Services.Courses
{
    public interface ICourseService
    {
        public Task<List<CourseDTO>> getCourses();
    }
}
