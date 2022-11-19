using LMS.DTOS.Announcements;
using LMS.Helpers.Exceptions;
using LMS.Services.Announcements;
using LMS.DTOS.Announcements;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace LMS.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IAnnouncementService announcementService;
        public AssignmentController(IAnnouncementService a_service) {
            
            announcementService = a_service;
            
        }

        public async  Task<IActionResult> Index(int id)
        {
            if (id ==0) {
                return new BadRequestResult();
            }
            Console.WriteLine(id);


            string token = Request.Cookies["token"] as string;
            Console.WriteLine("t"+token);
            //fetch all the submitted assignments of the user //files
            List<AssignmentFilesDTO> files =  await announcementService.GetAssignmentFilesDTO(id , token);
            

            

            ViewData["announcementId"] = id;
            string status = (files == null || files.Count == 0) ?  "Due" : "Submitted";

            ViewData["status"] = status;

            ViewBag.AssignmentFiles = files;

            return View();
        }


        [HttpPost("[controller]/upload/{id}")]
        public async  Task<IActionResult> submitFile(string id , [FromForm] List<IFormFile> assignmentFiles) {
            Console.Write(id);
            bool isNumber = int.TryParse(id , out int aid);
            if (!isNumber) {
                return new NotFoundResult();
            }
            string token = Request.Cookies["token"];

            var response = await announcementService.SubmitAssignmentFile(aid, assignmentFiles , token);

            
            Console.WriteLine(response.Content.ToString());
/*            if (!response.IsSuccessStatusCode) {
                throw new APIError("Error occured");
*/       //     }

            string jsonResponse = await response.Content.ReadAsStringAsync();

            return Redirect($"/Assignment?Id={id}");
        }
    }
}
