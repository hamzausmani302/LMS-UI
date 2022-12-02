using LMS.Authorization;
using LMS.DTOS.ClassesDTO;
using LMS.DTOS.Courses;
using LMS.Helpers.Exceptions;
using LMS.Models;
using LMS.Services.ClassesService;
using LMS.Services.Courses;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace LMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClassService _classService;
        private readonly ICourseService courseService;

        public HomeController(ILogger<HomeController> logger, IClassService _service , ICourseService courseService)
        {
            _logger = logger;
            _classService = _service;
            this.courseService = courseService;
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


        [HttpGet("user/enroll")]
        public async Task<IActionResult> addUserToClass(string code) {
            Console.WriteLine(code);
            try
            {
                if (Request.Cookies["token"] == null) {
                    return Forbid();
                }

                HttpResponseMessage response = await _classService.AddUserToClassUtils(code, Request.Cookies["token"]);
                if (response.StatusCode == HttpStatusCode.NotFound) {
                    return NotFound();
                }

                return Redirect("/user/Home");
            }
            catch (Exception err) {
                
                Console.WriteLine(err.Message);
                return NotFound();
            }
            
        
        }

        [Authorize]
        [HttpGet("class/add")]
        public async Task<IActionResult> addClassView()
        {

            //get list of courses
            List<CourseDTO> courseList = await courseService.getCourses();
            ViewBag.CourseList = courseList;





            return View();
        }
        [Authorize]
        [HttpPost("teacher/add/class")]
        public async Task<IActionResult> addClassSubmitAction(AddClassDTO dto)
        {

            string token = HttpContext.Request.Cookies["token"] as string;

            ClassDTO addedClass = await _classService.AddClass(dto, token);

            if (addedClass == null)
            {
                ViewData["showAlert"] = "";
                return View(Path.Combine("/", "Views", "Feed", "addClassView.cshtml"));
            }
            return Redirect("/teacher/Home");
        }



        [Authorize]
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
        [Authorize]
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
            //Console.WriteLine($"couynt = {res.Count} info = {res[0].Id}");
            if (res != null) {
                ViewBag.Class = res;

            }


            return View(Path.Combine("/", "Views", "Home", "Index.cshtml"));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}