using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View("/Login/Index.cshtml");
        }
    }
}
