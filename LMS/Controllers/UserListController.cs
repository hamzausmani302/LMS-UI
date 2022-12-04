using LMS.Models;
using LMS.Services.ClassesService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace LMS.Controllers
{
	public class UserListController : Controller
	{
        private readonly ILogger<HomeController> _logger;
        private readonly IClassService _classService;

        public UserListController(ILogger<HomeController> logger, IClassService _service)
        {
            _logger = logger;
            _classService = _service;
        }

        [HttpGet("[controller]/UserList/{id:int}")]
		public async Task<IActionResult> Index(int id)
		{
            Console.WriteLine($"in userList {id}");
            string tokenvalue = Request.Cookies["token"].ToString();
            if (tokenvalue == null)
            {
                return new ObjectResult("Teacher not authorized") { StatusCode = (int)HttpStatusCode.Forbidden };
            }

            var res = await _classService.GetUsers(tokenvalue,id);

            ViewBag.Users = res;
            return View();
		}
	}
}
