using LMS.Models;
using LMS.Services.Announcements;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    public class FeedController : Controller
    {

        private readonly IAnnouncementService announcementService;
        public FeedController(IAnnouncementService announcementService) {
            this.announcementService = announcementService;
        }
        [HttpGet("[controller]/Test")]
        public async Task<IActionResult> Index(string id)
        {
            Console.WriteLine(id);
            string token = Request.Cookies["token"].ToString();
            List<Announcement> announcements = await announcementService.getAnnouncementsOfClass(2 , token);
            
            



            Console.WriteLine(announcements.Count);
            //ViewBag.Announcements = announcements;
            ViewBag.Announcements = announcements;
            return View();
        }
    }
}
