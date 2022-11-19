using LMS.DTOS.Announcements;
using LMS.DTOS.FileDto;
using LMS.Models;
using LMS.DTOS.Announcements;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LMS.Services.Announcements { 
    public class AnnouncementService : IAnnouncementService
    {
        private readonly HttpClient httpClient;
       
        public AnnouncementService() {
            httpClient = new HttpClient();
            
        }
       
        public async Task<HttpResponseMessage> SubmitAssignmentFile(int classId, List<IFormFile> files , string token) {
           //
            string url = GlobalInfo.addSubmissionFileUrl.Replace("[id]" , classId.ToString());

            List<FileDTO> fileDTOs = new List<FileDTO>();
            foreach (IFormFile file in files) {
                MemoryStream stream = new MemoryStream();
                file.CopyTo(stream);
                fileDTOs.Add(new FileDTO {FileName = file.FileName , MimeType = file.ContentType , Data =stream.ToArray()  });
            }
            
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            httpClient.DefaultRequestHeaders
      .Accept
      .Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));

            return  await httpClient.PostAsJsonAsync(url,new SubmissionFilesDTO() { fileToUpload = fileDTOs});
            
        }

        public async Task<List<AnnouncementResponse>> getAnnouncementsOfClass(int classId , string token , string roleType)
        {

            string url = roleType != "teacher" ? GlobalInfo.getAnnouncementUrl : GlobalInfo.getAnnouncementTeacherUrl;
            url = url.Replace("[id]", classId.ToString());
            httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", token);
            List<AnnouncementResponse> response = await httpClient.GetFromJsonAsync<List<AnnouncementResponse>>(url);

            Console.WriteLine($"c = infor-1 = {response.Count}");
            if (response == null)
            {
                return new List<AnnouncementResponse>();
            }

            return response;
/*            return new List<Announcement>();
*/
            
        }
        public async Task<List<AssignmentFilesDTO>> GetAssignmentFilesDTO(int announcementId, string token) {
            string url = GlobalInfo.getSubmissionFileUrl.Replace("[id]" , announcementId.ToString());

            httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", token);
            List<AssignmentFilesDTO> files = await httpClient.GetFromJsonAsync<List<AssignmentFilesDTO>>(url);
            
            return files;

        }
    }

}
