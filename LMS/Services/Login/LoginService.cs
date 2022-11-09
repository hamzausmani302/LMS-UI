using LMS.DTOS.Users;
namespace LMS.Services.Login
{
    public class LoginService : ILoginService
    {
        private HttpClient _httpClient;

        public LoginService() { 
            _httpClient = new HttpClient();
        }

        public void teacherLogin()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> userLogin(AuthenticateRequest req)
        {
            try
            {
                string url = GlobalInfo.userLoginUrl;
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, new AuthenticateRequest() { Username = req.Username, Password = req.Password });

                return response;
            }
            catch (Exception err) {
                Console.WriteLine(err.Message);
                return null;
            }
            
        }



        public async Task<HttpResponseMessage> teacherLogin(AuthenticateRequest req)
        {
            try
            {
                string url = GlobalInfo.teacherLoginUrl;
                
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, new AuthenticateRequest() { Username = req.Username, Password = req.Password });
                Console.WriteLine(response.Content.ToString());
                return response;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }

        }

    }
}
