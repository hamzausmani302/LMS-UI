using LMS.Models;
using LMS.Services.ClassesService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace LMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClassService _classService;

        public HomeController(ILogger<HomeController> logger, IClassService _service)
        {
            _logger = logger;
            _classService = _service;
        }

        [HttpGet("/")]
        public IActionResult StartPage() {

            return View(Path.Combine("/" , "Views" , "StartPage" , "StartPage.cshtml"));
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [HttpGet("teacher/Home")]
        public async Task<IActionResult> getClassesTeacher()
        {
            Console.WriteLine("hello teahcer");
            string tokenvalue = Request.Cookies["token"].ToString();
            if (tokenvalue == null)
            {
                return new ObjectResult("Teacher not authorized") { StatusCode = (int)HttpStatusCode.Forbidden };
            }
           
                var res = await _classService.GetClasses(tokenvalue , false);
           
            ViewBag.Class= res;
            return View(Path.Combine("/", "Views", "Home", "Index.cshtml"));
        }

        [HttpGet("user/Home")]
        public async Task<IActionResult> getClassesUser()
        {
            Console.WriteLine("hello user");
            string tokenvalue = Request.Cookies["token"].ToString();
            if (tokenvalue == null)
            {
                return new ObjectResult("User not authorized") { StatusCode = (int)HttpStatusCode.Forbidden };
            }
            var res = await _classService.GetClasses(tokenvalue);
            Console.WriteLine($"couynt = {res.Count} info = {res[0].Id}");
            ViewBag.Class = res;
            

            return View(Path.Combine("/", "Views", "Home", "Index.cshtml"));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}