using LMS.Authorization;
using LMS.DTOS.Announcements;
using LMS.Helpers.Exceptions;
using LMS.Models;
using LMS.Services.Announcements;
using LMS.Services.AssignmentsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using NuGet.Protocol;
using System.Net;
using System.Security.Policy;

namespace LMS.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IAnnouncementService announcementService;
        private readonly IAssignmentService assignmentService;
        public AssignmentController(IAnnouncementService a_service , IAssignmentService as_service)
        {
            assignmentService = as_service;
            announcementService = a_service;

        }

        [Authorize]
        public async Task<IActionResult> Index(int id)
        {
            if (id == 0)
            {
                return new BadRequestResult();
            }
            Console.WriteLine(id);


            string token = Request.Cookies["token"] as string;

            string role = Request.Cookies["sessionType"] as string;

            Console.WriteLine("t" + token);
            //fetch all the submitted assignments of the user //files
            ViewData["announcementId"] = id;
            
            if (role == "user")
            {
                List<AssignmentFilesDTO> files = null;
                try
                {
                    files = await announcementService.GetAssignmentFilesDTO(id, token);

                }
                catch (Exception err) {
                    files = new List<AssignmentFilesDTO>();
                    Console.WriteLine(err.Message);
                }
 

            



            string status = (files == null || files.Count == 0) ? "Due" : "Submitted";

            ViewData["status"] = status;
            ViewData["downloadUrl"] = GlobalInfo.getSubmissionFileDownloadUrlUser.Replace("[token]", token);
            ViewBag.AssignmentFiles = files;

            return View();
            }
            List<SubmissionFile> submissions = await assignmentService.getUserSubmissions(id, token);
            ViewBag.Submissions = submissions != null ? submissions : new List<SubmissionFile>();
            string url = GlobalInfo.getSubmissionFileDownloadUrlTeacher.Replace("[token]" , token);
            ViewData["url"] = url;

            return View(Path.Combine("/" , "Views"  , "Assignment" , "TeacherIndex.cshtml"));
        }


        [HttpPost("[controller]/upload/{id}")]
        public async Task<IActionResult> submitFile(string id, [FromForm] List<IFormFile> assignmentFiles)
        {
            Console.Write("id- tet- " + id);
            bool isNumber = int.TryParse(id, out int aid);
            if (!isNumber)
            {
                return new NotFoundResult();
            }
            string token = Request.Cookies["token"] as string;

            var response = await announcementService.SubmitAssignmentFile(aid, assignmentFiles, token);
            if (response.StatusCode ==HttpStatusCode.Forbidden) {
                ViewData["showPopUp"] = "false";
                ViewData["announcementId"] = aid;
                return View(Path.Combine(Path.Combine("/", "Views", "Assignment", "Index.cshtml")));
            }
            Console.WriteLine( response.Content.ToJson());

            Console.WriteLine($"code = {response.StatusCode}");
            /*            if (!response.IsSuccessStatusCode) {
                            throw new APIError("Error occured");
            */       //     }

            //string jsonResponse = await response.Content.ReadAsStringAsync();
            
            return Redirect($"/Assignment?Id={id}");
        }
    }
}
