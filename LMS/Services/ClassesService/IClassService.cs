using LMS.DTOS.Users;
using LMS.Models;

namespace LMS.Services.ClassesService
{
    public interface IClassService
    {
        
        public Task<List<Class>> GetClasses(string tokenvalue , bool isUser = true);
        public Task<List<UserDTO>> GetUsers(string tokenvalue, int classId);
    }
}
