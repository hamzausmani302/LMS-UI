using LMS.DTOS.Users;

namespace LMS.Services.Login
{
    public interface ILoginService
    {
        public  Task<HttpResponseMessage> userLogin(AuthenticateRequest req);
        public  void teacherLogin();
        
    }
}
