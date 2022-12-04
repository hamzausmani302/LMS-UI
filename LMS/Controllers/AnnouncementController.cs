using LMS.Authorization;
using LMS.DTOS.Announcements;
using LMS.DTOS.FileDto;
using LMS.Models;
using LMS.Services.Announcements;
using LMS.Services.ClassesService;
using LMS.Services.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace LMS.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService announcementService;
        public AnnouncementController(IAnnouncementService announcementService)
        {
            this.announcementService = announcementService;
        }

        [Authorize]
        [HttpGet("[controller]/Announcement/{id:int}")]
        
        public IActionResult Index(int id)
        {
            Console.WriteLine($"classID {id}");
            return View();
        }
        [Authorize]
        [HttpPost("/teacher/announcement/{id}")]
        //[ValidateAntiForgeryToken]
        public IActionResult addAnnouncement(string id, [FromForm] AddAnnouncementDTO dto, [FromForm] List<IFormFile> fileToUpload)
        {
            
            Console.WriteLine($"in announcement controller with classID {id}");
            AddAnnouncementDTO announcement = new AddAnnouncementDTO()
            {
                title = dto.title,
                description = dto.description,
                announcementType = dto.announcementType,
                dueDate = dto.dueDate,
                attachedFiles = new List<FileDTO>()

            };
            foreach (IFormFile file in fileToUpload)
            {
                MemoryStream stream = new MemoryStream();
                file.CopyTo(stream);

                announcement.attachedFiles.Add(new FileDTO() { FileName = file.FileName, MimeType = file.ContentType, Data = stream.ToArray() });

            }
            //string title = Request.Form["title"];
            //string description = Request.Form["title"];
            //var attachments = Request.Form["attachments"];
            //Console.WriteLine(Request.Query["id"]);
            //Console.WriteLine(title);
            //Console.WriteLine(obj.announcementType);
            //Console.WriteLine(obj.Description);

            string token = Request.Cookies["token"].ToString();
            Console.WriteLine(announcementService.addAnnouncementsOfClassAsync(id, token, announcement, fileToUpload));


            return Redirect($"/Feed/feed/{id}");
        }

    }
}
