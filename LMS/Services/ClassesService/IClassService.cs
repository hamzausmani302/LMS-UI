using LMS.DTOS.ClassesDTO;
using LMS.DTOS.Users;
using LMS.Models;

namespace LMS.Services.ClassesService
{
    public interface IClassService
    {
        
        public Task<List<Class>> GetClasses(string tokenvalue , bool isUser = true);

        public Task<ClassDTO> AddClass(AddClassDTO dto , string token);

        public Task<HttpResponseMessage> AddUserToClassUtils(string code, string token);
    }
}
