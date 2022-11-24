using LMS.Models;
using LMS.Services.Announcements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Common;
using NuGet.Protocol.Plugins;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using LMS.DTOS.FileDto;
using LMS.DTOS.Announcements;

namespace LMS.Controllers
{

  

    public class FeedController : Controller
    {

        private readonly IAnnouncementService announcementService;
        public FeedController(IAnnouncementService announcementService) {
            this.announcementService = announcementService;
        }

        [HttpPost("upload/{id}")]
        public async Task<IActionResult> TestFileUpload(string id, [FromForm] AddAnnouncementDTO dto,  [FromForm] List<IFormFile> fileToUpload  ) {
            HttpClient client = new HttpClient();

            AddAnnouncementDTO announcement = new AddAnnouncementDTO()
            {
                title = dto.title,
                description = dto.description,
                announcementType = dto.announcementType,
                dueDate = dto.dueDate,
                attachedFiles = new List<FileDTO>()

            };
            foreach (IFormFile file in fileToUpload) {
                MemoryStream stream = new MemoryStream();
                file.CopyTo(stream);

                announcement.attachedFiles.Add(new FileDTO() { FileName= file.FileName , MimeType = file.ContentType , Data= stream.ToArray() });

            }

            HttpResponseMessage response =  await client.PostAsJsonAsync(GlobalInfo.addAnnouncementUrl.Replace("[id]", id) , announcement);
            if (!response.IsSuccessStatusCode) {
                return new BadRequestResult();
            }



            return Redirect( $"/Feed/Feed/{id}" );

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
