using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    public class FeedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
