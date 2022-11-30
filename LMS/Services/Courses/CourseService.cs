using LMS.DTOS.Courses;
using System.Net.Http.Headers;

namespace LMS.Services.Courses
{
    public class CourseService : ICourseService
    {
        private readonly HttpClient _httpClient;
        public CourseService() {
            _httpClient = new HttpClient();
        }
        public async Task<List<CourseDTO>> getCourses() {
            List<CourseDTO> courses = await  _httpClient.GetFromJsonAsync<List<CourseDTO>>(GlobalInfo.getCoursesUrl);
            if (courses == null) {
                return new List<CourseDTO>();
            }
            return courses;


        }
    }
}
