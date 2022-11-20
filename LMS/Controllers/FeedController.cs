using LMS.Models;
using LMS.Services.Announcements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LMS.Controllers
{
    public class FeedController : Controller
    {

        private readonly IAnnouncementService announcementService;
        public FeedController(IAnnouncementService announcementService) {
            this.announcementService = announcementService;
        }
        [HttpGet("[controller]/Feed/{id:int}")]
        public async Task<IActionResult> Index(int id)
        {
            //int.TryParse(id , out int classId);
            int classId = id;
            Console.WriteLine($"myid=  {classId}");
            if (classId == 0) {
                throw new BadHttpRequestException("Invalid arguments provided");
            }

            
            if (Request.Cookies["token"] == null || Request.Cookies["sessionType"] == null) {
                return Ok("unauthorized");
            }
            string token = Request.Cookies["token"].ToString();
            string identity = Request.Cookies["sessionType"].ToString();
            /* try
             {*/
            var announcements = await announcementService.getAnnouncementsOfClass(classId, token, identity);

                if (announcements != null && announcements.Count != 0)
                {
                    ViewBag.Announcements = announcements;
                }



                Console.WriteLine(announcements.Count);

                ViewBag.ClassID = id;
                ViewBag.Announcements = announcements;
            /*}
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return NotFound();
            }*/
            return View();
        }
    }
}
