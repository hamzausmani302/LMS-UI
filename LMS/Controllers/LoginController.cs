using LMS.DTOS.Users;
using LMS.Services.Login;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace LMS.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService) {
            _loginService = loginService;
        }

        public IActionResult Index()
        {
           
            
            return View();
        }

        [HttpPost("[controller]/login")]
        public async Task<IActionResult> Login(AuthenticateRequest req) {
            Console.WriteLine("login called" + req.Username   + req.Password);

            HttpResponseMessage response=   await _loginService.userLogin(req);
            if (response == null || !response.IsSuccessStatusCode)
            {
                ViewData["showAlert"] = true;
                return View(Path.Combine("/", "Views", "Login", "Index.cshtml"));
            }
            AuthenticateResponse res = await response.Content.ReadFromJsonAsync<AuthenticateResponse>();
            
            Console.WriteLine(res.firstName);

            Response.Cookies.Append("token", res.token);


            
            return View(Path.Combine("/" , "Views" , "Home", "Index.cshtml"));
        }
        
    }
}
