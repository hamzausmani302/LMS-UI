using LMS.DTOS.Users;
using LMS.Services.Login;
using Microsoft.AspNetCore.Mvc;
using System.Buffers.Text;
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

        [HttpGet("/Login")]
        public IActionResult getUserLoginPage() {
            string page = Request.Query["role"];
            if (page == "teacher")
            {
                return View(Path.Combine("/", "Views", "Login", "TeacherIndex.cshtml"));

            }
            else {
                return View(Path.Combine("/", "Views", "Login", "Index.cshtml"));

            }
        }

        [HttpPost("user/login")]
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
            Response.Cookies.Append("sessionType", "user");


            //return View(Path.Combine("/" , "Views" , "Home", "Index.cshtml"));
            return Redirect("/user/Home");
        }



        [HttpPost("teacher/login")]
        public async Task<IActionResult> LoginTeacher(AuthenticateRequest req)
        {
            Console.WriteLine("login called" + req.Username + req.Password);

            HttpResponseMessage response = await _loginService.teacherLogin(req);
            if (response == null || !response.IsSuccessStatusCode)
            {
                ViewData["showAlert"] = true;
                return View(Path.Combine("/", "Views", "Login", "Index.cshtml"));
            }
            AuthenticateResponse res = await response.Content.ReadFromJsonAsync<AuthenticateResponse>();

            Console.WriteLine(res.firstName);

            Response.Cookies.Append("token", res.token);

            Response.Cookies.Append("sessionType", "teacher");


            //return View(Path.Combine("/" , "Views" , "Home", "Index.cshtml"));
            return Redirect("/teacher/Home");
        }
    }
}
